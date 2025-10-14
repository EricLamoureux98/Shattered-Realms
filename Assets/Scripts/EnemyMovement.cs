using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private Animator anim;
    private Rigidbody2D rb;
    private Transform playerPosition;
    private int facingDirection = 1;
    private EnemyState enemyState;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(EnemyState.Idle);
    }

    void FixedUpdate()
    {
        if (enemyState == EnemyState.Chasing)
        {
            ChasePlayer();
        }

        // Checks direction of player compared to enemy to determin movement direction
        if (playerPosition != null && playerPosition.position.x > transform.position.x && facingDirection == -1 || playerPosition.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerPosition == null)
            {
                playerPosition = collision.gameObject.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (playerPosition.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void ChangeState(EnemyState newState)
    {
        //Exit current animation
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }

        //Update current state
        enemyState = newState;

        //Update to new animation
        if (enemyState == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (enemyState == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }
    }
}

public enum EnemyState
{
    Idle,
    Chasing
}
