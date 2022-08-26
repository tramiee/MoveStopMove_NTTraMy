using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private Animator playerAnimator;

    public void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            playerAnimator.SetTrigger(Constant.ANIM_ISRUN);
        }
        else
        {
            playerAnimator.SetTrigger(Constant.ANIM_ISIDLE);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }
}
