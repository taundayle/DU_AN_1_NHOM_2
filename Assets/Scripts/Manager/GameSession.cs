using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] public bool countcoin = true;
    public GameObject Ui;
    // Âm thanh và animation nhân vật bị đánh
    [SerializeField] AudioClip oofsound;
    private AudioSource oofsoundSource; //bị đánh
    private AudioClip GetOofsound()
    {
        return oofsound;
    }
    //
    public TMPro.TextMeshProUGUI scoreEnemy;
    public int enemy = 0;
    //
    public int playerlives = 3;
    public int shell = 0;
    public int score = 0;
    public int bullet = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI scoreeeText;
    public TMPro.TextMeshProUGUI scoreeText;
    public TMPro.TextMeshProUGUI bulletText;
    public Slider liveSlider;
    public Slider liveSliderhe;
    public GameObject gameOverUI; // Thêm biến tham chiếu đến UI "You Lose"
    [SerializeField] bool takedamage = false;
    public GameObject endgame;
    public GameObject scoregame;
    public GameObject dame;
    public int damege = 0;
    public TMPro.TextMeshProUGUI dameText;
    
    private void Start()
    {
        oofsoundSource = GetComponent<AudioSource>(); //âm thanh
        scoreText.text = score.ToString();
        scoreEnemy.text = enemy.ToString();
        dameText.text = dame.ToString();
        liveSlider.value = playerlives;
        liveSliderhe.value = shell;
    }

    private void Update()
    {
        bulletText.text = bullet.ToString();
        scoreeText.text = scoreText.text;
        scoreeeText.text = scoreText.text;
    }

    private void Awake()
    {
        int number = FindObjectsOfType<GameSession>().Length;
        if (number > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void Anim_playerdeath()
    {
        if (takedamage == true)
        {
            oofsoundSource.PlayOneShot(oofsound);
            takedamage = false;
        }
        else
        {
            oofsoundSource.Stop();
        }
    }
    public void EndGame()
    {
        Time.timeScale = 0;
        Ui.SetActive(false);
        scoregame.SetActive(false); 
        endgame.SetActive(true);
    }

    public void PlayerDeath()
    {
        if (shell > 0)
        {
            TakeShell(1);
            takedamage = true;
            Anim_playerdeath();
        }
        else
        {
            if (playerlives > 0)
            {
                TakeLife(1);
                takedamage = true;
                Anim_playerdeath();
            }
            else
            {
                GameOver(); // Gọi phương thức GameOver ngay khi hết mạng
            }
        }
    }
    public void DamegePlayer(int num)
    {
        damege += num;
        dameText.text = damege.ToString();
    }
    public void TakeEnemy(int num)
    {
        enemy += num;
        scoreEnemy.text = enemy.ToString();
    }
    //đoạt giáp
    public void TakeShell(int num)
    {
        shell -= num; // giảm mạng
        liveSliderhe.value = shell;
        DamegePlayer(1);
        takedamage = false;
    }
    //đoạt mạng
    public void TakeLife(int num)
    {
        playerlives -= num; // giảm mạng
        liveSlider.value = playerlives;
        DamegePlayer(1);

        if (playerlives <= 0)
        {
            GameOver(); // Đảm bảo gọi GameOver khi mạng về 0
        }
        takedamage = false;
    }

    public void GameOver()
    {
        Time.timeScale = 0; // Dừng game
        gameOverUI.SetActive(true); // Hiển thị màn hình "You Lose"
        Ui.SetActive(false);
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }

    public void AddBullet(int num)
    {
        if (bullet < 20)
        {
            bullet += num;
            bulletText.text = bullet.ToString();
        }
    }

    public void BulletCount(int num)
    {
        bullet -= num;
        bulletText.text = bullet.ToString();
    }

    public void AddShell(int num) //Thêm giáp
    {
        if (shell < 5)
        {
            shell += num;
            liveSliderhe.value = shell;
        }
    }
    public void AddHealth(int num) //thêm máu
    {
        if (playerlives < 5)
        {
            playerlives += num;
            liveSlider.value = playerlives;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ResetGame()
    {
            int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
            //Load lại scene hiện tại
            SceneManager.LoadScene(currentsceneindex);
            SceneManager.LoadScene(1); //load lại scene 0
            Time.timeScale = 1;
            Debug.Log("Load lai scene");
            Destroy(gameObject); //destroy gamesession luôn
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
