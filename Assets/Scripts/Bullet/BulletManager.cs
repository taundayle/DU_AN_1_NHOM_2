using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletManager : MonoBehaviour
{
    public int damage;
    public float speedbullet;
    protected Rigidbody2D Bullett;
    protected Transform player; //Tham chiếu tới player
    public bool isBullet = true;
    public float timer;
}
