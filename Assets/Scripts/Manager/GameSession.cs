using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    public int playerlives = 3;
    public int shell = 0;
    public int score = 0;
    public int bullet = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI bulletText;
    public Slider liveSlider;
    public Slider liveSliderhe;
    public GameObject gameOverUI; // Thêm biến tham chiếu đến UI "You Lose"

    private void Start()
    {
        scoreText.text = score.ToString();
        liveSlider.value = playerlives;
        liveSliderhe.value = shell;
    }

    private void Update()
    {
        bulletText.text = bullet.ToString();
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

    public void PlayerDeath()
    {
        if (shell > 0)
        {
            TakeShell(1);
        }
        else
        {
            if (playerlives > 0)
            {
                TakeLife(1);
            }
            else
            {
                GameOver(); // Gọi phương thức GameOver ngay khi hết mạng
            }
        }
    }

    //đoạt giáp
    public void TakeShell(int num)
    {
        shell -= num; // giảm mạng
        liveSliderhe.value = shell;
    }
    //đoạt mạng
    public void TakeLife(int num)
    {
        playerlives -= num; // giảm mạng
        liveSlider.value = playerlives;

        if (playerlives <= 0)
        {
            GameOver(); // Đảm bảo gọi GameOver khi mạng về 0
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0; // Dừng game
        gameOverUI.SetActive(true); // Hiển thị màn hình "You Lose"
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }

    public void AddBullet(int num)
    {
        if (bullet < 10)
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
}
