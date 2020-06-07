using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon : MonoBehaviour
{
    public Transform firePoint1;
    public GameObject clockPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(clockPrefab, firePoint1.position, firePoint1.rotation);
    }
}
