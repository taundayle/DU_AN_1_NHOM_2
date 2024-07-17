using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddShell(1);
        }
    }
}
