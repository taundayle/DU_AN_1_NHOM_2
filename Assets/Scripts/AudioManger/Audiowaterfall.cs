using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiowaterfall : MonoBehaviour
{
    [SerializeField] AudioClip watersound;
    private AudioSource watersoundSource;  //nhảy

    // Start is called before the first frame update
    void Start()
    {
        watersoundSource = GetComponent<AudioSource>();
    }

    private AudioClip WaterSound()
    {
        return watersound;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            watersoundSource.clip = watersound;
            watersoundSource.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            watersoundSource.clip = watersound;
            watersoundSource.Stop();
        }
    }
}
