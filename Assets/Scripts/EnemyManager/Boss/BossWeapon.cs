using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class BossWeapon : MonoBehaviour
{
    public Vector3 attackAreaOffSet;
    public float attackRange = 1f;
    public LayerMask attackMaskPlayer;
    public void AttackPlayer()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackAreaOffSet.x;
        pos += transform.up * attackAreaOffSet.y;

        Collider2D collBoss = Physics2D.OverlapCircle(pos, attackRange, attackMaskPlayer);
        if (collBoss != null)
        {
            FindAnyObjectByType<GameSession>().PlayerDeath();
            FindAnyObjectByType<GameSession>().TakeLife(1);
            FindAnyObjectByType<GameSession>().TakeShell(2);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackAreaOffSet.x;
        pos += transform.up * attackAreaOffSet.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
