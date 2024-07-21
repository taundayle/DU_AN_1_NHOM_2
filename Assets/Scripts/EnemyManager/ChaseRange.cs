using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseRange : MonoBehaviour
{
    public EnemyFlying[] flyingEnemyArray;
    private void OnTriggerEnter2D(Collider2D followP1)
    {
        if (followP1.CompareTag("Player"))
        {
            foreach (EnemyFlying enemy in flyingEnemyArray)
            {
                enemy.chase = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D followP2)
    {
        if (followP2.CompareTag("Player"))
        {
            foreach (EnemyFlying enemy in flyingEnemyArray)
            {
                enemy.chase = false;
            }
        }
    }
}
