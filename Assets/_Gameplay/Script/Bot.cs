using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{

    public Animator botAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BULLET))
        {
            botAnimator.SetTrigger(Constant.ANIM_ISDEAD);
        }
    }
}
