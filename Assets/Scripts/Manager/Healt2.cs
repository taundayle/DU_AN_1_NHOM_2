using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Health2 : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxhealth = 10;
    [SerializeField] float health = 10;
    private float lerpSpeed = 0.05f;
    // Start is called before the first frame update
    public void TakeLife(int num)
    {
        health -= num;
    }

    void Start()
    {
        health = maxhealth;
    }
    // Update is called once per frame
    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (healthSlider.value != easeHealthSlider.value)
        {
            healthSlider.value = Mathf.Lerp(healthSlider.value, health, lerpSpeed);
        }
    }
}
