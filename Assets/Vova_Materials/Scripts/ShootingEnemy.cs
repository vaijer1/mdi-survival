using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public float speed;
    public float distance;
    private bool moovingRight = true;
    public Transform GroundChecking;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D isGround = Physics2D.Raycast(GroundChecking.position, Vector2.down, distance);
        if (isGround.collider == false)
        {
            if (moovingRight == true)
            {
                transform.localRotation = Quaternion.Euler(0, -180, 0);
                moovingRight = false;
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                moovingRight = true;
            }
        }
    }
}
