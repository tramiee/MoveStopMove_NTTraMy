using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public Sight sight;
    public Weapon weapon;
    NavMeshAgent agent;
    public Animator botAnimator;
    public  Vector3 targetPos;
    public float timer;
    public float speed;
    public int newTargetPos;
    public GameObject sightTarget;

    public bool IsDead;
    private void Start()
    {
        IsDead = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > newTargetPos)
        {
            
            MoveTargetRanDom();
            timer = 0;
        }
        else
        {
            
            botAnimator.SetTrigger(Constant.ANIM_ISIDLE);
            //StopMove();
        }
    }

    public void MoveTargetRanDom()
    {
        float myX = gameObject.transform.position.x;
        float myZ = gameObject.transform.position.z;

        float posX = myX + Random.Range(myX - 20f, myX + 20f);
        float posZ = myZ + Random.Range(myZ - 20f, myZ + 20f);

        targetPos = new Vector3(posX, transform.position.y, posZ);

        agent.SetDestination(targetPos);
        botAnimator.SetTrigger(Constant.ANIM_ISRUN);
    }

    public void StopMove()
    {
        Transform closestObj = sight.CheckDistanceClosestBot();
        if(closestObj != null && weapon != null)
        {
            botAnimator.SetTrigger(Constant.ANIM_ISATTACK);
            transform.LookAt(closestObj);
            weapon.Throw(closestObj, this.transform);
        }
    }

    public void Death()
    {
        IsDead = true;
        StartCoroutine(DelayDead());
    }
    IEnumerator DelayDead()
    {
        yield return new WaitForSeconds(2f);
        botAnimator.SetTrigger(Constant.ANIM_ISDEAD);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BULLET))
        {
            Death();
            //TO DO
            Destroy(gameObject);
        }
    }
}
