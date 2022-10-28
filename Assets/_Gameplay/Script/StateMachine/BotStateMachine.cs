using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotStateMachine : MonoBehaviour
{
    public BotStateMachine bot;

    private BotBaseState currentState;
    public BotIdleState idleState = new BotIdleState();
    public BotRunState runState = new BotRunState();
    public BotDeathState deathState = new BotDeathState();
    public BotAttackState attackState = new BotAttackState();

    public NavMeshAgent agent;
    public Bounds bounds;

    public Animator animator;

    public float idleTime = 5f;
    public float deathTime = 4f;
    public float attackTime = 1f;


    public Weapon weapon;
    public Sight sight;

    private void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        currentState = idleState;
        currentState.EnterState(bot);
    }
    private void Update()
    {
        currentState.UpdateState(bot);
    }

    public void SwitchState(BotBaseState newState)
    {
        if (currentState != newState)
        {
            currentState.ExitState(bot);
            currentState = newState;
            newState.EnterState(bot);
        }
    }

    public void DestroyBot()
    {
        Destroy(bot.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BULLET))
        {
            SwitchState(deathState);
        }
    }

}
