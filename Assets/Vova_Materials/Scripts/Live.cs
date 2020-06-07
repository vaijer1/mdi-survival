using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    public float health = 10f;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            panel.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn")
        {
            health = 0;
        }
    }
}
