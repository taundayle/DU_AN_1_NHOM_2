using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Player : MonoBehaviour
{
    private Player pl;
    private MoveInput gameInput;
    Animator anim;
    private bool change;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pl = GetComponent<Player>();
        gameInput = GetComponent<MoveInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Shoot();
        Attack();
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            change = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            change = false;
        }
    }
    void Run()
    {
        float moveInput = gameInput.HorizontalInput;
        anim.SetBool("Run", Mathf.Abs(moveInput) > Mathf.Epsilon);
    }
    void Jump()
    {
        if (pl.isGrounded == false /*&& pl.isClimbing == false*/ && !Input.GetKey(KeyCode.J) && !Input.GetMouseButton(0))
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
    void Attack()
    {
        if (change == false)
        {
            if(Input.GetKey(KeyCode.J) || Input.GetMouseButton(0))
            {
                anim.SetBool("Gun", true);
            }
            else
            {
                anim.SetBool("Gun", false);
            }
        }
    }
    void Shoot()
    {
        if (change == true)
        {
            if(Input.GetKey(KeyCode.J) || Input.GetMouseButton(0))
            {
                anim.SetBool("Gun2", true);
            }
            else
            {
                anim.SetBool("Gun2", false);
            }
        }

    }
}
