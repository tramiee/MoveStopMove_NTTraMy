using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private float speed;
    [SerializeField] private Animator playAnimator;
    [SerializeField] private LayerMask tableLayer;

    public bool CanThrow = true;

    public Sight sight;

    public Weapon weapon;

    private bool IsAttacking;
    private float countTimeAttack;
    public float timeAttack;

    private void Start()
    {
        IsAttacking = false;
        countTimeAttack = 0;
    }
    public void Move()
    {
        rb.velocity = new Vector3(variableJoystick.Horizontal * speed, rb.velocity.y, variableJoystick.Vertical * speed);
        if(variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            playAnimator.SetTrigger(Constant.ANIM_ISRUN);
            CanThrow = true;
            IsAttacking = false;
            countTimeAttack = 0;
        }
    }

    /*public bool CheckTable()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 0.5f, tableLayer);
        if(hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

    public void StopMove()
    {
        if(variableJoystick.Horizontal == 0 || variableJoystick.Vertical == 0)
        {
            if (IsAttacking)
            {
                countTimeAttack += Time.deltaTime;
                if (countTimeAttack > timeAttack)
                {
                    IsAttacking = false;
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
                    IsAttacking = true;
                }
            }
            else
            {
                if (IsAttacking) return;
                playAnimator.SetTrigger(Constant.ANIM_ISIDLE);
            }
        }
    }

    private void Update()
    {
        Debug.DrawLine(transform.position, Vector3.down, Color.red, 100);
    }
    private void FixedUpdate()
    {
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 4f, Color.red);
        Move();
        StopMove();
        //Debug.Log(CheckTable());
    }

    public void Dead()
    {
        playAnimator.SetTrigger(Constant.ANIM_ISDEAD);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BULLET))
        {
            Debug.Log("Hit");
            Dead();
        }
    }
}
