using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cup2 : MonoBehaviour
{
    public GameObject endGame;
    public float moveSpeed = 0.000000000002f;        // Tốc độ di chuyển của cúp
    public float scaleSpeed = 5f;       // Tốc độ phóng to của cúp
    public float targetScale = 3f;      // Kích thước mục tiêu

    private Vector3 targetPosition;     // Vị trí mục tiêu (giữa màn hình)

    void Update()
    {
        // Đặt vị trí mục tiêu là giữa màn hình
        targetPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        // Chuyển đổi vị trí từ màn hình sang thế giới
        targetPosition = Camera.main.ScreenToWorldPoint(targetPosition);
        // Đặt z về 0 để cúp không bị dịch chuyển trên trục z
        targetPosition.z = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(MoveAndScale());
        }
    }

    IEnumerator MoveAndScale()
    {
        // Di chuyển và phóng to cúp
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f || transform.localScale.x < targetScale)
        {
            

            // Phóng to cúp
            if (transform.localScale.x < targetScale)
            {
                transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            }
            // Di chuyển cúp tới vị trí mục tiêu
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.time);


            yield return null;

        }
        // Hiện panel kết thúc trò chơi sau khi cúp đã di chuyển và phóng to xong
        endGame.SetActive(true);

        // Dừng trò chơi
        Time.timeScale = 0;

    }
}
