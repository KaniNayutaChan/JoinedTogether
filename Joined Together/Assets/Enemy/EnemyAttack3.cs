using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack3 : StateMachineBehaviour
{
    public int speed;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, Ball.instance.transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(animator.transform.position, Ball.instance.transform.position) < 0.5f)
        {
            animator.Play("Idle");
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