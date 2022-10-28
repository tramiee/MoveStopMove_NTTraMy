using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Bot : MonoBehaviour
{
    public Animator botAnimator;
    public Vector3 targetPos;
    public Bounds bounds;
    public GameObject Table;
    NavMeshAgent agent;

    private bool IsRun = false;
    private bool IsDead;
    private bool IsSearch;

    private void Start()
    {
        IsRun = false;
        IsDead = false;
        IsSearch = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
        bounds = Table.GetComponent<Renderer>().bounds;
    }

    private void Update()
    {
        if (IsRun && !IsDead)
        {
            botAnimator.SetTrigger(Constant.ANIM_ISRUN);
        }

        // Reach Destination
        if((agent.hasPath == false || agent.remainingDistance < 1f) && !IsDead)
        {
            IsRun = false;
            botAnimator.SetTrigger(Constant.ANIM_ISIDLE);
            if (!IsSearch)
            {
                IsSearch = true;
                Invoke(nameof(MoveTargetRanDom), 5);
            }
        }
    }

    public void MoveTargetRanDom()
    {
        float posX = Random.Range(bounds.min.x, bounds.max.x);
        float posZ = Random.Range(bounds.min.z, bounds.max.z);
        targetPos = new Vector3(posX, transform.position.y, posZ);
        agent.SetDestination(targetPos);
        IsRun = true;
        IsSearch = false;
    }

    public void Death()
    {
        IsDead = true;
        agent.isStopped = true;
        botAnimator.SetTrigger(Constant.ANIM_ISDEAD);
        StartCoroutine(DelayDead());
    }
    IEnumerator DelayDead()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BULLET))
        {
            Debug.Log("Hit");
            Death();
        }
    }
}
