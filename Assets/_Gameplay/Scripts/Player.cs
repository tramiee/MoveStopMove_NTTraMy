using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private Animator playerAnimator;
    public CharacterSight characterSight;
    public Gun gun;

    public void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            playerAnimator.SetTrigger(Constant.ANIM_ISRUN);
        }
    }

    public void StopMove()
    {
        if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            playerAnimator.SetTrigger(Constant.ANIM_ISIDLE);
            Transform closetObj = characterSight.CheckDistance();
            if (closetObj != null && gun != null)
            {
                transform.LookAt(closetObj);
                gun.Throw();
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
        StopMove();
    }
}
