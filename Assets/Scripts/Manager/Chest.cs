using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Transform spawn1;
    [SerializeField] Transform spawn2;
    [SerializeField] Transform spawn3;
    public GameObject spawn1prefabs;
    public GameObject spawn2prefabs;
    public GameObject spawn3prefabs;
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
                Instantiate(spawn1prefabs, spawn1.position, transform.rotation);
                Instantiate(spawn2prefabs, spawn2.position, transform.rotation);
                Instantiate(spawn3prefabs, spawn3.position, transform.rotation);
            }

        }
    }
}
