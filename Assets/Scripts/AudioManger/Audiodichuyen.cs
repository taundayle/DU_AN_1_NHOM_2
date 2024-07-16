﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class Audiodichuyen : MonoBehaviour
{
    Player player;
    MoveInput input;
    Player_Attack attackPlayer;

    private bool isWalking = false;
    private bool isJumping = false;
    private bool isShooting = false;

    [SerializeField] AudioClip jumpsound;
    [SerializeField] AudioClip walksound;
    [SerializeField] AudioClip Shootsound;
    private AudioSource jumpsoundSource;
    private AudioSource walksoundSource;
    private AudioSource shootsoundSource;

    void Start()
    {
        player = GetComponent<Player>();
        input = GetComponent<MoveInput>();
        attackPlayer = GetComponent<Player_Attack>();
        jumpsoundSource = GetComponent<AudioSource>();
        walksoundSource = GetComponent<AudioSource>();
        shootsoundSource = GetComponent<AudioSource>();
    }

    private AudioClip GetJumpsound()
    {
        return jumpsound;
    }
    private AudioClip GetWakksound()
    {
        return walksound;
    }
    private AudioClip GetShootsound()
    {
        return Shootsound;
    }

    // Update is called once per frame
    void Update()
    {
        //trapDamageSound();
        Jump();
        Walk();
        Shoot();

    }
    void Jump()
    {
        if (player.isGrounded == true)
        {
            // Kiểm tra xem âm thanh đã được phát chưa
            if (!isJumping)
            {
                jumpsoundSource.PlayOneShot(jumpsound);
                isJumping = true; // Đánh dấu là đang phát âm thanh
            }
        }
        else
        {
            if (isJumping || player.isGrounded == false && isJumping)
            {
                jumpsoundSource.Stop();
                isJumping = false; // Đánh dấu là không còn phát âm thanh nữa
            }
        }
    }
    void Walk()
    {
        float gameInput = input.HorizontalInput;

        if (gameInput > Mathf.Epsilon && player.isGrounded)
        {
            if (!isWalking)
            {

                walksoundSource.PlayOneShot(walksound);
                isWalking = true; // Đánh dấu là đang phát âm thanh

            }

        }
        else
        {
            if (isWalking)
            {
                walksoundSource.Stop();
                isWalking = false; // Đánh dấu là không còn phát âm thanh nữa
            }
        }
    }

    void Shoot()
    {
        if (/*attackPlayer.ShootInput == true && attackPlayer.canShoot  */Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
        {
            // Kiểm tra xem âm thanh đã được phát chưa
            //if (!isShooting)
            //{
            shootsoundSource.PlayOneShot(Shootsound);
            isShooting = true; // Đánh dấu là đang phát âm thanh
            //}
        }
        else if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.J))
        {
            //if (isShooting)
            //{
            shootsoundSource.Stop();
            isShooting = false; // Đánh dấu là không còn phát âm thanh nữa
            //}
        }
    }
}