using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private Animator playAnimator;

    public Sight sight;

    public Weapon weapon;
    public void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            playAnimator.SetTrigger(Constant.ANIM_ISRUN);
        }
    }

    public void StopMove()
    {
        if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            playAnimator.SetTrigger(Constant.ANIM_ISIDLE);
            Transform closestObj = sight.CheckDistanceClosestBot();
            if(closestObj != null)
            {
                transform.LookAt(closestObj);
            }
        }
    }



    private void FixedUpdate()
    {
        Move();
        StopMove();
    }
}
