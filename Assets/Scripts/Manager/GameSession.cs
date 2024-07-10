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
    public int score = 0;
    public int bullet = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI bulletText;
    public Slider liveSlider;

    private void Start()
    {
        scoreText.text = score.ToString();
        liveSlider.value = playerlives;

    }
    private void Update()
    {
        bulletText.text = bullet.ToString();
        ResetGame();
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
        if (playerlives >= 1)
        {
            TakeLife(1);
        }
        else
        {
            ResetGame();
        }
    }
    //đoạt mạng
    public void TakeLife(int num)
    {
        playerlives -= num; // giảm mạng
                            //Lấy index của scene hiện tại
        liveSlider.value = playerlives;
    }
    public void ResetGame()
    {
        if (playerlives < 1)
        {
            int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
            //Load lại scene hiện tại
            SceneManager.LoadScene(currentsceneindex);
            SceneManager.LoadScene(0); //load lại scene 0
            Time.timeScale = 1;
            Debug.Log("Load lai scene");
            Destroy(gameObject); //destroy gamesession luôn
        }
    }
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0); //load lại scene 0
        Time.timeScale = 1;
        Debug.Log("Load lai scene");
        Destroy(gameObject); //destroy gamesession luôn
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

    public void AddHealth(int num)
    {
        if (playerlives < 5)
        {
            playerlives += num;
            liveSlider.value = playerlives;
        }
    }
}
