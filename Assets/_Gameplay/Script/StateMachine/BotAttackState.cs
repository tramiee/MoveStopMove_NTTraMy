using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAttackState : BotBaseState
{
    private float timeCounter;
    public override void EnterState(BotStateMachine bot)
    {
        timeCounter = 0;
    }

    public override void UpdateState(BotStateMachine bot)
    {
        bot.animator.SetTrigger(Constant.ANIM_ISATTACK);
        timeCounter += Time.deltaTime;
        if (timeCounter > bot.attackTime)
        {
            bot.weapon.gameObject.SetActive(true);
            bot.SwitchState(bot.runState);
        }
    }
    public override void ExitState(BotStateMachine bot)
    {
    }

}
