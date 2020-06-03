using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private float timebtwShts;
    public float startTimebtwShts;
    public int damage;

    public int health;
    public float speed;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;

    public Transform player;
    public GameObject enemyBullet;
    public Transform shotPoint;
    public float dist;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        normalSpeed = speed;
    }


    private void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (timebtwShts <= 0)
        {
            if (Vector2.Distance(transform.position, player.position) < dist)
            {
                Instantiate(enemyBullet, shotPoint.position, transform.rotation);
                timebtwShts = startTimebtwShts;
            }
        }
        else
        {
            timebtwShts -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
    }
}
