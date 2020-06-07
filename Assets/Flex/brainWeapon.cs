using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brainWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lightningPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(lightningPrefab, firePoint.position, firePoint.rotation);
    }
}
