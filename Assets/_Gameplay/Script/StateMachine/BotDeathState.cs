using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotDeathState : BotBaseState
{
    private float timeCounter;
    public override void EnterState(BotStateMachine bot)
    {
        timeCounter = 0;
        bot.agent.isStopped = true;
    }

    public override void UpdateState(BotStateMachine bot)
    {
        bot.animator.SetTrigger(Constant.ANIM_ISDEAD);
        timeCounter += Time.deltaTime;
        if (timeCounter > bot.deathTime)
        {
            bot.DestroyBot();
        }
    }

    public override void ExitState(BotStateMachine bot)
    {
    }

}
