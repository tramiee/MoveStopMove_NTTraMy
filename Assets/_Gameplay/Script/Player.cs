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

    public bool CanThrow = true;

    public Sight sight;

    public Weapon weapon;

    public void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            playAnimator.SetTrigger(Constant.ANIM_ISRUN);
            CanThrow = true;
        }
    }

    public void StopMove()
    {
        if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            playAnimator.SetTrigger(Constant.ANIM_ISIDLE);
            if (!CanThrow)
            {
                return;
            }
            Transform closestObj = sight.CheckDistanceClosestBot();
            if(closestObj != null && weapon != null)
            {
                playAnimator.SetTrigger(Constant.ANIM_ISATTACK);
                transform.LookAt(closestObj);
                weapon.Throw(closestObj, this.transform);
                CanThrow = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Move();
        StopMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BULLET))
        {
            playAnimator.SetTrigger(Constant.ANIM_ISDEAD);
        }
    }
}
