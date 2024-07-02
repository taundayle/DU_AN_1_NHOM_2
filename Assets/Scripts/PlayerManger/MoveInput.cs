using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInput : MonoBehaviour
{
    [SerializeField] public float HorizontalInput;
    [SerializeField] public float VerticalInput;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
