using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Gun : MonoBehaviour
{
    public int bullets = 0;
    Player pl;
    [SerializeField] Transform bulletspawn;
    [SerializeField] Transform attackspawn;
    public GameObject attackprefabs;
    public GameObject bulletprefabs;
    public bool isShooting;
    public bool change = false;
    private float timer;

    void Start()
    {
        pl = GetComponent<Player>();
    }
    void Update()
    {
        Shoot();
        timer = Time.deltaTime;
        if (timer > 1)
        {
            Destroy(attackprefabs);
        }
    }
    public void AddBullet(int num)
    {
        if (bullets < 5)
        {
            bullets += num;
        }

    }
    void Attack()
    {
        if(Input.GetKeyUp(KeyCode.J) || Input.GetMouseButtonUp(0))
        {
            Instantiate(attackprefabs, attackspawn.position, transform.rotation);
        }

    }
    void Shoot()
    {
        if (Time.timeScale == 0)
        {
            isShooting = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            change = true;
            Debug.Log("Đã đổi chiêu 2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            change = false;
            Debug.Log("Đã đổi chiêu 1");
        }
        if(change == true)
        {
            if (Input.GetKeyUp(KeyCode.J) || Input.GetMouseButtonUp(0))
            {
                if (bullets >= 1)
                {
                    Instantiate(bulletprefabs, bulletspawn.position, transform.rotation);
                    isShooting = true;
                    bullets--;
                    FindObjectOfType<GameSession>().BulletCount(1);
                }
                else
                {
                    isShooting = false;
                }
            }
        }
        else
        {
            Attack();
        }
    }

}
