using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack4 : StateMachineBehaviour
{
    bool hasReachedBoss;
    Vector3 destination;
    public float timeTillIdle;
    float currentTimeTillIdle;
    float amplitude;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        hasReachedBoss = false;
        Ball.instance.destination = animator.transform.position;
        currentTimeTillIdle = timeTillIdle;
        amplitude = 0;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(Vector2.Distance(Ball.instance.transform.position, Ball.instance.destination) < 0.5f)
        {
            hasReachedBoss = true;
        }

        if(hasReachedBoss)
        {
            amplitude += 0.01f;
            destination.Set(animator.transform.position.x + amplitude * Mathf.Cos(Mathf.PI * Time.time), animator.transform.position.y + amplitude * Mathf.Sin(Mathf.PI * Time.time), 0);
            Ball.instance.transform.position = destination;
            animator.transform.up = animator.transform.up - Ball.instance.transform.position;

            if(currentTimeTillIdle > 0)
            {
                currentTimeTillIdle -= Time.deltaTime;
            }
            else
            {
                animator.Play("Idle");
            }
        }

        if (Ball.instance.hasCollided)
        {
            animator.Play("Idle");
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        Ball.instance.hasCollided = false;
    }
}