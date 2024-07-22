using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class audioLoot : MonoBehaviour
{
    private Animator ani;
    [SerializeField] AudioClip coinclip;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinclip, Camera.main.transform.position);
        }
    }
}
