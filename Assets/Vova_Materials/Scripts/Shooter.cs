using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bullet;
    public Transform shotPoint;

    private float timebtwShts;
    public float startTimebtwShts;


    void Update()
    {
        if (timebtwShts <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, shotPoint.position, transform.rotation);
                timebtwShts = startTimebtwShts;
            }
        }
        else
        {
            timebtwShts -= Time.deltaTime;
        }
    }
}
