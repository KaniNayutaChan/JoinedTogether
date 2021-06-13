using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2 : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        Ball.instance.destination = animator.transform.position;

        if(Vector2.Distance(Ball.instance.destination, Ball.instance.transform.position) < 0.5f)
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