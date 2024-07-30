using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Ki?m tra xem va ch?m c� ph?i t? player hay kh�ng
        if (other.CompareTag("Player"))
        {
            // Chuy?n ??n c?nh "Win"
            SceneManager.LoadScene("Win");
        }
    }
}
