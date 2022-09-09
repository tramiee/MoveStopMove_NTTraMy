using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolControlller : MonoBehaviour
{
    public Transform bulletHolder;
    public GameObject bulletPrefab;
    private void Awake()
    {
        SimplePool.Preload(bulletPrefab, 1, bulletHolder);
    }
}
