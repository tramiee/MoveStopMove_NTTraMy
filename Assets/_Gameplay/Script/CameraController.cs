using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    [SerializeField] private float speedCamera;
    [SerializeField] private Vector3 offset;
   public void CameraFollowPlayer()
    {
        camera.position = Vector3.Lerp(camera.position, player.position + offset, speedCamera);
    }

    private void LateUpdate()
    {
        CameraFollowPlayer();
    }
}
