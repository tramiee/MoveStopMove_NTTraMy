using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public Transform player;
    private float distanceToCloseBot;
    public List<Transform> bots = new List<Transform>();
    Transform closestBot;
    private float distanceToBot;

    public Transform CheckDistanceClosestBot()
    {
        closestBot = null;
        distanceToCloseBot = 5;
        foreach(Transform currentBot in bots)
        {
            distanceToBot = Vector3.Distance(currentBot.position, player.position);
            if(distanceToBot < distanceToCloseBot)
            {
                distanceToCloseBot = distanceToBot;
                closestBot = currentBot;
            }
        }
        return closestBot;
    }
}
