using System.Collections;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    private MoveInput gameInput;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rig;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundRadius = 0.2f; //Bán kính
    //Jump
    public bool isGrounded = true;
    //Climb
    public float climbspeed = 3f;
    public bool isClimbing = false;
    //Flipx
    [SerializeField] private bool IsRightFace = true;
    //Player Die
    public float timer; //kiểm tra time



    void Start()
    {
        anim = GetComponent<Animator>();
        gameInput = GetComponent<MoveInput>();
        rig = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Climb();
        RightFace();
    }
    void Move()
    {
        //Kiểm tra mặt đất
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
        //Điều kiện di chuyển
        float moveInput = gameInput.HorizontalInput;
        rig.velocity = new Vector2(moveInput * moveSpeed, rig.velocity.y);

        //RightFace //Lật mặt
        if (moveInput > 0)
        {
            IsRightFace = true;
        }
        else if (moveInput < 0)
        {
            IsRightFace = false;
        }


        //Xử lý Jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            isGrounded = false;
        }
        else if (isGrounded == false)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y);
            isGrounded = true;
        }
    }
    void RightFace() //Lật mặt
    {
        if (IsRightFace == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (IsRightFace == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void Jump()
    {
         //nhảy
        rig.velocity = new Vector2(rig.velocity.x, jumpForce);
    }
    void Climb()
    {
        //Leo cầu thang
        if (isClimbing)
        {
            float climbInput = Input.GetAxisRaw("Vertical");                        //Ấn phím để leo cầu thang
            rig.velocity = new Vector2(rig.velocity.x, climbInput * climbspeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) //Chạm cầu thang
        {
            isClimbing = true;
            rig.gravityScale = 0f;
        }
        if (collision.CompareTag("Gai,Axit") || collision.gameObject.CompareTag("XoayTrap") || collision.gameObject.CompareTag("Enemy"))
        {
            FindAnyObjectByType<GameSession>().PlayerDeath();
            anim.SetBool("HitPlayer", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) //Rời khỏi cầu thang
        {
            isClimbing = false;
            rig.gravityScale = 4f;
        }
        if (collision.CompareTag("Gai,Axit") || collision.gameObject.CompareTag("XoayTrap") || collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("HitPlayer", false);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("XoayTrap") || collision.gameObject.CompareTag("Enemy"))
    //    {
    //        FindObjectOfType<GameSession>().PlayerDeath();
    //    }
    //}
    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Slime")) //Va chạm
            {
                    Debug.Log("Kich hoat anim");
                    //anim.SetBool("PlayerHit", true);
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Slime")) //Huỷ va chạm
            {
                    Debug.Log("Huy anim");
                    //anim.SetBool("PlayerHit", false);
            }
        }*/
}
