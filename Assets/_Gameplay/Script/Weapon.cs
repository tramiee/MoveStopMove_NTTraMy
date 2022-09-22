using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletPoint;
    public Bullet bulletPrefab;
    public void Throw(Transform target, Transform owner)
    {
        gameObject.SetActive(false);
        Bullet newBullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        newBullet.SetTarget(target);
        newBullet.SetOwner(owner);
        newBullet.SetMovevec();
    }
}
