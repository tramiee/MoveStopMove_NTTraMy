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

    public GameObject target;

    public Transform CheckDistanceClosestBot()
    {
        closestBot = null;
        distanceToCloseBot = 5;
        foreach(Transform currentBot in bots)
        {
            if (currentBot == null) continue;
            distanceToBot = Vector3.Distance(currentBot.position, player.position);
            if(distanceToBot < distanceToCloseBot)
            {
                distanceToCloseBot = distanceToBot;
                closestBot = currentBot;
            }
        }
        return closestBot;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BOT))
        {
            Debug.Log("Bot");
            target.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Constant.TAG_BOT))
        {
            Debug.Log("Not bot");
            target.SetActive(false);
        }
    }
}
