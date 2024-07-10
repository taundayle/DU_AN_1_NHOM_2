using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coineffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            GameObject hieuung = Instantiate(coineffect, transform.position, transform.localRotation);
            Destroy(hieuung, 4);
            FindObjectOfType<GameSession>().AddScore(1);
        }
    }
}
