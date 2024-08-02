using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class Gun : MonoBehaviour
{
    public int bullets = 0;
    Player pl;
    [SerializeField] Transform bulletspawn;
    [SerializeField] Transform attackspawn;
    [SerializeField] Transform ultitspawn;
    public GameObject attackprefabs;
    public GameObject bulletprefabs;
    public GameObject ultitsprefabs;
    public bool isShooting;
    [SerializeField] bool ban;
    [SerializeField] bool chem;
    [SerializeField] bool ulti;
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
        if (bullets < 20)
        {
            bullets += num;
        }

    }
    void Attack()
    {
        if(Input.GetKeyUp(KeyCode.J))
        {
            Instantiate(attackprefabs, attackspawn.position, transform.rotation);
        }

    }
    void Ban()
    {
        if (Input.GetKeyUp(KeyCode.J))
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
                Debug.Log("Không đủ năng lượng");
            }
        }
    }
    void Ulti()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            if (bullets >= 3)
            {
                Instantiate(ultitsprefabs, ultitspawn.position, transform.rotation);
                isShooting = true;
                bullets = bullets - 3;
                FindObjectOfType<GameSession>().BulletCount(3);
            }
            else
            {
                isShooting = false;
                Debug.Log("Không đủ năng lượng");
            }
        }
    }
    void Shoot()
    {
        if (Time.timeScale == 0)
        {
            isShooting = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) //Chiêu cuối kích hoạt
        {
            if (bullets >= 3)
            {
                ulti = true;
                ban = false;
                chem = false;
                if (ulti == true)
                {
                    Ulti();
                    Debug.Log("Đã đổi chiêu 3");
                }
            }
            else
            {
                ulti = false;
                chem = true;
                ban = false;
                Debug.Log("Không đủ năng lượng");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) //Bắn kích hoạt
        {
            if (bullets >= 1)
            {
                ban = true;
                chem = false;
                ulti = false;
                Debug.Log("Đã đổi chiêu 2");
            }
            else
            {
                ban = false;
                chem = true;
                ulti = false;
                Debug.Log("Không đủ năng lượng");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) //Chém kích hoạt
        {
            ban = false;
            chem = true;
            ulti = false;
            Debug.Log("Đã đổi chiêu 1");
        }
        if(ban == true)
        {
            Ban();
        }
        else if (chem == true)
        {
            Attack();
        }
        else if(ulti == true)
        {
            Ulti();
        }
    }

}
