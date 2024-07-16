using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTrap : MonoBehaviour
{
    Player pl;
    public float xoaySpeed = 5f;
    public float moveSpeed = 5f;
    public Transform diemA;
    public Transform diemB;
    private Vector3 diemMucTieu;
    // Start is called before the first frame update
    void Start()
    {
        diemMucTieu = diemA.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, diemMucTieu, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, diemMucTieu) < Mathf.Epsilon)
        {
            if (transform.position == diemA.position)
            {
                diemMucTieu = diemB.position;
            }
            else
            {
                diemMucTieu = diemA.position;
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        if(pl.isDashing == false)
    //        {
    //            FindObjectOfType<GameSession>().PlayerDeath();
    //        }
    //    }
    //}
    private void FixedUpdate()
    {
        transform.Rotate(1, 1, xoaySpeed);
    }
    
}