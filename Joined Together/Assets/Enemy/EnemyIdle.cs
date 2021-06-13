using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : StateMachineBehaviour
{
    public string[] attackList;
    int attackToUse;
    float timeTillAttack;
    public float minTimeTillAttack;
    public float maxTimeTillAttack;
    int lastUsedAttack;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        int random = Random.Range(0, 2);
        if(random == 0)
        {
            PlayerManager.instance.currentTargetedPlayer = PlayerManager.instance.player1;
        }
        else
        {
            PlayerManager.instance.currentTargetedPlayer = PlayerManager.instance.player2;
        }

        attackToUse = Random.Range(0, attackList.Length);
        while(attackToUse == lastUsedAttack)
        {
            attackToUse = Random.Range(0, attackList.Length);
        }

        lastUsedAttack = attackToUse;

        timeTillAttack = Random.Range(minTimeTillAttack, maxTimeTillAttack);

#if UNITY_EDITOR
        attackToUse = 5;
#endif
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        animator.transform.up = PlayerManager.instance.currentTargetedPlayer.transform.position - animator.transform.position;

        if(timeTillAttack > 0)
        {
            timeTillAttack -= Time.deltaTime;
        }
        else
        {
            animator.Play(attackList[attackToUse]);
        }
    }
}
