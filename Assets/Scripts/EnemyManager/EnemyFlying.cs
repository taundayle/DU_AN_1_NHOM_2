using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    public float speed = 5f;
    private GameObject player;
    public Transform startPoint;
    public bool chase = false;  
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return; 

        if (chase == true) 
            ChasePlayer();
        else 
            ResetStartPoint();

        FlipX();
    }
    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            player.transform.position, speed * Time.deltaTime);
    }
    private void ResetStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, 
            speed * Time.deltaTime);
    }
    private void FlipX()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
