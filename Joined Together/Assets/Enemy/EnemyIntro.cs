using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntro : StateMachineBehaviour
{
    public float timeTillIdle = 1;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if(timeTillIdle > 0)
        {
            timeTillIdle -= Time.deltaTime;
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
