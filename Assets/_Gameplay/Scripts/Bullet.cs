using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10f;
    public Transform player;

    private void OnEnable()
    {
        rb.velocity = player.forward * speed;
    }
}
