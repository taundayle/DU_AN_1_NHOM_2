using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Player : MonoBehaviour
{
    //Gun gun;
    private Player pl;
    private MoveInput gameInput;
    Animator anim;
    public bool ban;
    public bool chem;
    public bool ulti;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pl = GetComponent<Player>();
        gameInput = GetComponent<MoveInput>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (pl.gameObject.CompareTag("Enemy") || pl.gameObject.CompareTag("Gai,Axit") || pl.gameObject.CompareTag("XoayTrap"))
        {
            anim.SetBool("HitPlayer", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (pl.gameObject.CompareTag("Enemy") || pl.gameObject.CompareTag("Gai,Axit") || pl.gameObject.CompareTag("XoayTrap"))
        {
            anim.SetBool("HitPlayer", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        Shoot();
        Attack();
        Ulti();
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ulti = false;
            ban = true;
            chem = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            chem = true;
            ulti = false;
            ban = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            ulti = true;
            chem = false;
            ban = false;
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
        if (chem == true)
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
        if (ban == true)
        {
            if (Input.GetKey(KeyCode.J) || Input.GetMouseButton(0))
            {     
                anim.SetBool("Gun2", true);
            }
            else
            {
                anim.SetBool("Gun2", false);
            }
        }
    }
    void Ulti()
    {
        if (ulti == true)
        {
            if (Input.GetKey(KeyCode.J) || Input.GetMouseButton(0))
            {
                anim.SetBool("Gun3", true);
            }
            else
            {
                anim.SetBool("Gun3", false);
            }
        }
    }
}
