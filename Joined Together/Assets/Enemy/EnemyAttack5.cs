using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack5 : StateMachineBehaviour
{
    public float timeTillAttack;
    float currentTimeTillAttack;
    bool hasUsedAttack;
    public int speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentTimeTillAttack = timeTillAttack;
        hasUsedAttack = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (currentTimeTillAttack > 0)
        {
            currentTimeTillAttack -= Time.deltaTime;
        }
        else if (!hasUsedAttack)
        {
            hasUsedAttack = true;
            Ball.instance.destination = new Vector3(Random.Range(-7, 7), Random.Range(-4, 4), 0);
        }

        if (hasUsedAttack)
        {
            if (Vector2.Distance(Ball.instance.transform.position, Ball.instance.destination) < 0.3f)
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, Ball.instance.transform.position, speed * Time.deltaTime);
            }

            if(Vector2.Distance(animator.transform.position, Ball.instance.destination) < 0.3f)
            {
                animator.Play("Idle");
            }
        }       

        if(Ball.instance.hasCollided)
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
