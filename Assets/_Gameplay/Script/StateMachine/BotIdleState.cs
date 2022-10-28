using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotIdleState : BotBaseState
{
    private float timeCount;

    public override void EnterState(BotStateMachine bot)
    {
        timeCount = 0;
    }

    public override void UpdateState(BotStateMachine bot)
    {
        bot.animator.SetTrigger(Constant.ANIM_ISIDLE);
        timeCount += Time.deltaTime;
        // target found => switch attack
        Transform closestObj = bot.sight.CheckDistanceClosestBot();
        if (closestObj != null && bot.weapon != null)
        {
            bot.transform.LookAt(closestObj);
            bot.SwitchState(bot.attackState);
            bot.weapon.Throw(closestObj, bot.transform);

        }
        // end idle time
        if (timeCount > bot.idleTime)
        {
            bot.SwitchState(bot.runState);
        }
    }

    public override void ExitState(BotStateMachine bot)
    {
    }


}
