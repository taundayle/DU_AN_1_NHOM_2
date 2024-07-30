using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cup2 : MonoBehaviour
{
    public float moveSpeed = 2f;        // Tốc độ di chuyển của cúp
    public float scaleSpeed = 3f;       // Tốc độ phóng to của cúp
    public Vector3 targetPosition;      // Vị trí mục tiêu (giữa màn hình)
    public float targetScale = 3f;      // Kích thước mục tiêu

    private bool isMoving = false;

    void Start()
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
        if (other.CompareTag("Player") && !isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveAndScale());
        }
    }

    IEnumerator MoveAndScale()
    {
        // Di chuyển và phóng to cúp
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f || transform.localScale.x < targetScale)
        {
            // Di chuyển cúp tới vị trí mục tiêu
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Phóng to cúp
            if (transform.localScale.x < targetScale)
            {
                transform.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
            }

            yield return null;
        }

        // Chuyển đến cảnh "Win" sau khi cúp đã di chuyển và phóng to xong
        SceneManager.LoadScene("Win");
    }
}
