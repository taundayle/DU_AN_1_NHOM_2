using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    private bool isActive = false;

    public void ActivateGhost(Transform playerTransform)
    {
        player = playerTransform;
        isActive = true;
    }

    private void Update()
    {
        if (isActive)
        {
            // Di chuyển bóng ma về phía người chơi
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Kiểm tra khoảng cách giữa bóng ma và người chơi
            if (Vector3.Distance(transform.position, player.position) < 0.1f)
            {
                // Bóng ma biến mất
                Destroy(gameObject);
            }
        }
    }
}
