using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOctopus : MonoBehaviour
{
    [SerializeField] float start, end, speed;
    Rigidbody2D rig;
    int isRight = 1;
    GameObject player;
    Animator anim;

    [SerializeField] private float timer = 0f;
    [SerializeField] public float cooldown = 0.65f;

    //public Vector3 attackAreaOffSet;
    //public float attackRange = 1f;
    //public LayerMask attackMaskPlayer;

    //public Animator enemy2;
    //public Animator enemy3;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Run()
    {
        var x_enemy = transform.position.x;
        if (x_enemy < start)
            isRight = 1;
        if (x_enemy > end)
            isRight = -1;
        transform.Translate(new Vector3(isRight * speed * Time.deltaTime, 0, 0));
        var y_enemy = transform.position.y;
        var x_player = player.transform.position.x;
        var y_player = player.transform.position.y;
        if ((x_player > start && x_player < end) &
            (y_player < y_enemy + 1 && y_player > y_enemy - 1))   //y khong lech nhau
        {
            if (x_player < x_enemy)
                isRight = -1;
            if (x_player > x_enemy)
                isRight = 1;
        }
    }
    void Flip()
    {
        transform.localScale = new Vector2(isRight, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Flip();
    }
    private void OnTriggerStay2D(Collider2D other1)
    {

        if (other1.CompareTag("Player"))
        {
            speed = 0f;
            timer += Time.deltaTime; // Tăng biến đếm thời gian

            if (anim != null)
                anim.SetBool("AttackP1", true);
            if (timer >= cooldown)
            {
                FindAnyObjectByType<GameSession>().PlayerDeath(); // Gọi phương thức PlayerDeath
                timer = 0f; // Đặt lại biến đếm thời gian

            }
        }
    }
    private void OnTriggerExit2D(Collider2D other2)
    {
        if (other2.gameObject.CompareTag("Player"))
        {
            speed = 5.5f;
            if (anim != null)
            {
                anim.SetBool("AttackP1", false);
                timer = 0f;
            }
        }
    }
    /*    public void AttackPlayer()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackAreaOffSet.x;
            pos += transform.up * attackAreaOffSet.y;

            Collider2D collBoss = Physics2D.OverlapCircle(pos, attackRange, attackMaskPlayer);
            if (collBoss != null)
            {
                FindAnyObjectByType<GameSession>().PlayerDeath();
            }
        }
        void OnDrawGizmosSelected()
        {
            Vector3 pos = transform.position;
            pos += transform.right * attackAreaOffSet.x;
            pos += transform.up * attackAreaOffSet.y;

            Gizmos.DrawWireSphere(pos, attackRange);
        }*/
}
