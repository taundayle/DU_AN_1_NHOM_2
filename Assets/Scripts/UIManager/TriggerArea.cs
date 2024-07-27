using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public GameObject ghostPrefab;
    public Transform spawnPoint;
    private bool hasSpawnedGhost = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSpawnedGhost && other.CompareTag("Player"))
        {
            // Tạo bóng ma tại điểm spawn
            GameObject ghostInstance = Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity);
            GhostController ghostController = ghostInstance.GetComponent<GhostController>();

            if (ghostController != null)
            {
                ghostController.ActivateGhost(other.transform);
            }

            // Đặt trạng thái đã kích hoạt
            hasSpawnedGhost = true;
        }
    }
}
