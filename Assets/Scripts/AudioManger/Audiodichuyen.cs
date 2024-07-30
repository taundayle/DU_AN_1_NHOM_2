using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;

public class Audiodichuyen : MonoBehaviour
{
    Anim_Player anim;
    Player player;
    MoveInput input;
    Player_Attack attackPlayer;

    private bool attack = false;
    private bool shoot = false;
    private bool ulti = false;
    private bool isWalking = false;
    private bool isJumping = false;
    //private bool isShooting = false;
    //private bool isoofing = false;

    [SerializeField] AudioClip jumpsound;
    [SerializeField] AudioClip walksound;
    [SerializeField] AudioClip shootsound;
    [SerializeField] AudioClip ultisound;
    [SerializeField] AudioClip oofsound;
    [SerializeField] AudioClip chemsound;
    private AudioSource jumpsoundSource;  //nhảy
    private AudioSource walksoundSource; //walk
    private AudioSource shootsoundSource; //bắn chiêu 2
    private AudioSource ultisoundSource; //chiêu cuối
    private AudioSource oofsoundSource; //bị đánh
    private AudioSource chemsoundSource;

    void Start()
    {
        anim = GetComponent<Anim_Player>();
        player = GetComponent<Player>();
        input = GetComponent<MoveInput>();
        attackPlayer = GetComponent<Player_Attack>();
        jumpsoundSource = GetComponent<AudioSource>();
        walksoundSource = GetComponent<AudioSource>();
        shootsoundSource = GetComponent<AudioSource>();
        oofsoundSource = GetComponent<AudioSource>();
        ultisoundSource = GetComponent<AudioSource>();
        chemsoundSource = GetComponent<AudioSource>();
    }
    private AudioClip ChemSound()
    {
        return chemsound;
    }
    private AudioClip Ultisound()
    {
        return ultisound;
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
        return shootsound;
    }
    private AudioClip GetOofsound()
    {
        return oofsound;
    }

    // Update is called once per frame
    void Update()
    {
        //trapDamageSound();
        Jump();
        Walk();
        Shoot();
        Change();
        //Oofing();
        if (Input.GetKey(KeyCode.Alpha1))
        {
            attack = true;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            shoot = true;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            ulti = true;
        }
        else
        {
            attack = false;
            shoot = false;
            ulti = false;
        }

    }
    void Change()
    {
        if (attack == true)
        {
            chemsoundSource.clip = chemsound;
            chemsoundSource.Play();
            attack = false;
        }
        else if (shoot == true)
        {
            shootsoundSource.clip = shootsound;
            shootsoundSource.Play();
            shoot = false;
        }
        else if (ulti == true)
        {
            ultisoundSource.clip = ultisound;
            ultisoundSource.Play();
            shoot = false;
        }
        else
        {
            attack = false;
            shoot = false;
            ulti = false;
        }

    }
/*    void Oofing()
    {
        if (gss.takedamage == true)
        {
            oofsoundSource.PlayOneShot(oofsound);
            //isoofing = true;
        }
        else
        {
            oofsoundSource.Stop();
            //isoofing = false;
        }
    }*/
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
        float moveInput = input.HorizontalInput;
        if (moveInput > 0 && player.isGrounded || moveInput < 0 && player.isGrounded)
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
        if (anim.chem == true && Input.GetKeyUp(KeyCode.J))
        {
            // Kiểm tra xem âm thanh đã được phát chưa
            //if (!isShooting)
            //{
            chemsoundSource.PlayOneShot(chemsound);
            //isShooting = true; // Đánh dấu là đang phát âm thanh
            //}
        }
        else if (anim.ban == true && Input.GetKeyUp(KeyCode.J))
        {
            //if (isShooting)
            //{
            shootsoundSource.PlayOneShot(shootsound);
            //isShooting = true; // Đánh dấu là không còn phát âm thanh nữa
            //}
        }
        else if (anim.ulti == true && Input.GetKeyUp(KeyCode.J))
        {
            ultisoundSource.PlayOneShot(ultisound);
            //isShooting = true;
        }
        else if(Input.GetKey(KeyCode.J))
        {
            chemsoundSource.Stop();
            ultisoundSource.Stop();
            shootsoundSource.Stop();
            //isShooting= false;
        }
    }
}