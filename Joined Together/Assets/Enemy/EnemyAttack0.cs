using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack0 : StateMachineBehaviour
{
    Vector2 destination;
    public int speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        destination.Set(PlayerManager.instance.currentTargetedPlayer.transform.position.x, PlayerManager.instance.currentTargetedPlayer.transform.position.y);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        animator.transform.position = Vector2.MoveTowards(animator.transform.position, destination, speed * Time.deltaTime);

        if(Vector2.Distance(animator.transform.position, destination) < 0.5f)
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
