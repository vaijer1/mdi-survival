using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float stopping = 1.5f;
    public Vector2 view = new Vector2(2f, 1f);
    public bool Left;
    private Transform player;
    private int checkX;

    private void Start()
    {
        view = new Vector2(Mathf.Abs(view.x), view.y);
        FindPlayer(Left);
    }

    private void Update()
    {
        if (player)
        {
            int currX = Mathf.RoundToInt(player.position.x);
            if (currX > checkX)
            {
                Left = false;
            }
            else if (currX < checkX)
            {
                Left = true;
            }

            Vector3 target;
            if(Left)
            {
                target = transform.position = new Vector3(player.position.x - stopping, player.position.y - stopping, transform.position.z);
            }
            else
            {
                target = transform.position = new Vector3(player.position.x + stopping, player.position.y + stopping, transform.position.z);
            }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, stopping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }

    public void FindPlayer(bool playerLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        checkX = Mathf.RoundToInt(player.position.x);
        if (playerLeft)
        {
            transform.position = new Vector3(player.position.x - stopping, player.position.y - stopping, transform.position.z); 
        }
        else
        {
            transform.position = new Vector3(player.position.x + stopping, player.position.y + stopping, transform.position.z);
        }
    }
}
