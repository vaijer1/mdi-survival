using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifes : MonoBehaviour
{
    public int health = 10;
    public int numLives;

    public Image[] lives;

    public Sprite FullLive;
    public Sprite HalfLive;
    public Sprite EmptyLive;
    private int p;
    private int pp;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            lives[0].sprite = EmptyLive;
            Destroy(gameObject);
            panel.SetActive(true);
        }
        for (int i = 0; i < health; i++)
        {
            if (i < 2)
            {
                p = 0;
                pp = 1;
            }
            else
            {
                p = i / 2;
                pp = p + 1;
            }

            if (i % 2 == 1)
            {
                lives[p].sprite = FullLive;
                if ((pp < 5 && pp > 1) | health == 2)
                {
                    lives[pp].sprite = EmptyLive;
                }
            }
            else
            {
                lives[p].sprite = HalfLive;
            }

            lives[p].enabled = true;

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            health = 0;
        }
    }

}

