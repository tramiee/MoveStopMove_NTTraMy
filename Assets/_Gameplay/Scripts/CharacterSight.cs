using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSight : MonoBehaviour
{
    public Transform player;
    public List<Transform> nearPlayer = new List<Transform>();
    public float oldDistance;
    private float distance;
    Transform closetObject;
   
    
    public Transform CheckDistance()
    {
       closetObject = null;
       oldDistance = 5;
       foreach (Transform bot in nearPlayer)
        {
            distance = Vector3.Distance(player.position, bot.transform.position);
            if(distance < oldDistance)
            {
                closetObject = bot;
                oldDistance = distance;
            }
        }
        return closetObject;
    }
}
