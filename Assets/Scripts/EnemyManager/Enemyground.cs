using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyground : MonoBehaviour
{
    [SerializeField] float start, end, speed;
    Rigidbody2D rig;
    int isRight = 1;
    GameObject player;

    private float timer = 0f;
    private float cooldown = 1.2f;

    public Animator enemy2;
    public Animator enemy3;

    // Start is called before the first frame update
    void Start()
    {
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
        timer += Time.deltaTime; // Tăng biến đếm thời gian
        if (other1.CompareTag("Player"))
        {
            speed = 0f;
            if (timer >= cooldown)
            {
                if (enemy2 != null)
                    enemy2.SetBool("AttackP", true);

                if (enemy3 != null)
                    enemy3.SetBool("AttackP1", true);
                timer = 0f; // Đặt lại biến đếm thời gian
                FindAnyObjectByType<GameSession>().PlayerDeath(); // Gọi phương thức PlayerDeath
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other2)
    {
        if (other2.CompareTag("Player"))
        {
            speed = 5.5f;
            if (enemy2 != null)
                enemy2.SetBool("AttackP", false);

            if (enemy3 != null)
                enemy3.SetBool("AttackP1", false);
        }
    }
}
