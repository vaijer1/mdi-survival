using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public float speed = 0.5f;
    public float rayDistance = 4f;
    public int hp = 5;
    public Transform platformCheck;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D platform = Physics2D.Raycast(platformCheck.position, Vector2.down, rayDistance);
        if (!platform.collider)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;
        if (hp == 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
            thing.GetComponent<MainHero>().Damage(10);
    }
}
