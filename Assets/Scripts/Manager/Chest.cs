using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float timer;
    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            anim.SetBool("Hit", true);
            timer += Time.deltaTime;
            if (timer >= 0.04)
            {
                Destroy(gameObject);
            }

        }
    }
}
