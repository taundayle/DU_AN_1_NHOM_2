using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Gun : MonoBehaviour
{
    public int bullets = 0;
    Player pl;
    [SerializeField] Transform bulletspawn;
    public GameObject bulletprefabs;
    public bool isShooting;

    void Start()
    {
        pl = GetComponent<Player>();
    }
    void Update()
    {
        Shoot();
    }
    public void AddBullet(int num)
    {
        if (bullets < 5)
        {
            bullets += num;
        }

    }
    void Shoot()
    {
        if (Time.timeScale == 0)
        {
            isShooting = false;
        }
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

}
