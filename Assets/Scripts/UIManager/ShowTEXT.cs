using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTEXT : MonoBehaviour
{
    public Text displayText;  

    void Start()
    {
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false);  
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            if (displayText != null)
            {
                displayText.gameObject.SetActive(true);  
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            if (displayText != null)
            {
                displayText.gameObject.SetActive(false);  
            }
        }
    }
}
