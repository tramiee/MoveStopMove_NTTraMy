using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletHolder;

    private void Awake()
    {
        SimplePool.Preload(bulletPrefab, 1, bulletHolder);
    }
}
