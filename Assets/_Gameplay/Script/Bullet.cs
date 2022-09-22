using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bot;
    public Transform player;
    public Vector3 moveVec;
    public float speedBullet;

    private void Update()
    {
        transform.position += moveVec * speedBullet * Time.deltaTime;
    }

    public void SetTarget(Transform target)
    {
        bot = target;
    }

    public void SetOwner(Transform owner)
    {
        player = owner;
    }

    public void SetMovevec()
    {
        moveVec = bot.position - player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constant.TAG_BOT))
        {
            Destroy(gameObject);
        }
    }
}
