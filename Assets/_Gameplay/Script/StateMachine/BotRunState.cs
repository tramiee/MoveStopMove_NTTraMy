using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotRunState : BotBaseState
{
    public override void EnterState(BotStateMachine bot)
    {
        MoveTargetRanDom(bot);
    }

    public override void UpdateState(BotStateMachine bot)
    {
        bot.animator.SetTrigger(Constant.ANIM_ISRUN);
        if (bot.agent.hasPath == false || bot.agent.remainingDistance < 1f)
        {
            bot.SwitchState(bot.idleState);
        }

    }

    public override void ExitState(BotStateMachine bot)
    {
    }

    public void MoveTargetRanDom(BotStateMachine bot)
    {
        float posX = Random.Range(bot.bounds.min.x, bot.bounds.max.x);
        float posZ = Random.Range(bot.bounds.min.z, bot.bounds.max.z);
        Vector3 targetPos = new Vector3(posX, bot.transform.position.y, posZ);
        bot.agent.SetDestination(targetPos);
    }

}
