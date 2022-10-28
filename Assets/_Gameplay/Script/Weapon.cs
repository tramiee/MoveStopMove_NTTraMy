using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletPoint;
    public Bullet bulletPrefab; 
    public void Throw(Transform target, Transform owner)
    {
        StartCoroutine(spawnBullet(target, owner));
    }

    IEnumerator spawnBullet(Transform target, Transform owner)
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        //TO DO
        Bullet newBullet = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        newBullet.gameObject.SetActive(true);
        newBullet.SetTarget(target);
        newBullet.SetOwner(owner);
        newBullet.SetMovevec();
        newBullet.SetWeaponObj(gameObject);
    }
}
