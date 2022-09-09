using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletPoint;
    public Bullet bulletPrefab;
    public void Throw()
    {
        gameObject.SetActive(false);
        SimplePool.Spawn(bulletPrefab.gameObject, bulletPoint.position, Quaternion.identity);
        //TODO: fix late
    }
}
