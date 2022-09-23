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

    private bool isAttacking;
    private float countTimeAttack;
    public float timeAttack;

    private void Start()
    {
        isAttacking = false;
        countTimeAttack = 0;
    }
    public void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            playAnimator.SetTrigger(Constant.ANIM_ISRUN);
            CanThrow = true;
            isAttacking = false;
            countTimeAttack = 0;
        }
    }

    public void StopMove()
    {
        if(joystick.Horizontal == 0 || joystick.Vertical == 0)
        {
            if (isAttacking)
            {
                countTimeAttack += Time.deltaTime;
                if (countTimeAttack > timeAttack)
                {
                    isAttacking = false;
                    countTimeAttack = 0;
                }
            }

            Transform closestObj = sight.CheckDistanceClosestBot();
            if (closestObj != null && weapon != null)
            {
                playAnimator.SetTrigger(Constant.ANIM_ISATTACK);
                if (CanThrow)
                {
                    transform.LookAt(closestObj);
                    weapon.Throw(closestObj, this.transform);
                    CanThrow = false;
                    isAttacking = true;
                }
            }
            else
            {
                if (isAttacking) return;
                playAnimator.SetTrigger(Constant.ANIM_ISIDLE);
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
