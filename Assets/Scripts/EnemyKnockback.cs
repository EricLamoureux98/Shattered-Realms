using System.Collections;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Knockback(Transform playerTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        enemyMovement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
    }

    IEnumerator StunTimer(float knockbackTime, float StunTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(StunTime);
        enemyMovement.ChangeState(EnemyState.Idle);
    }
}
