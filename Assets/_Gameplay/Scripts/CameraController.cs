using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speedCamera;
    

    public void CameraFollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, speedCamera);
    }
    private void LateUpdate()
    {
        CameraFollowPlayer();
    }
}
