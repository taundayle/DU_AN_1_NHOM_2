using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCoin : MonoBehaviour
{
    private Rigidbody2D Bullett;
    private bool isBullet = true;
    public int bullet = 1;
    void Start()
    {
        Bullett = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Destroybullet();
    }
    private void Destroybullet()
    {
        if (isBullet == false)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameSession>().AddBullet(bullet);
            FindObjectOfType<Gun>().AddBullet(bullet);
            Destroy(gameObject);
        }
    }
}
