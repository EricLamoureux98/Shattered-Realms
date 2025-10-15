using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float attackRange;
    [SerializeField] float attackCooldown = 2f;
    [SerializeField] float playerDetectRange = 5f;
    [SerializeField] Transform detectionPoint;
    [SerializeField] LayerMask playerLayer;

    private float attackCooldownTimer;
    private int facingDirection = 1;
    private EnemyState enemyState;

    private Transform playerPosition;
    private Animator anim;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        ChangeState(EnemyState.Idle);
    }

    void Update()
    {
        CheckForPlayer();

        if(attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        if (enemyState == EnemyState.Chasing && playerPosition != null)
        {
            ChasePlayer();
        }
        else if (enemyState == EnemyState.Attacking && playerPosition != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    // Instead of TriggerEnter
    void CheckForPlayer()
    {
        //Creates a circle around detectionPoint with a radius of playerDetectRange
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        // If player is detected
        if (hits.Length > 0)
        {
            // Player position is first hit
            playerPosition = hits[0].transform;

            // If player is in attack range and cooldown is ready
            if (Vector2.Distance(transform.position, playerPosition.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, playerPosition.position) > attackRange)
            {
                rb.linearVelocity = Vector2.zero;
                ChangeState(EnemyState.Chasing);
            }
        }
        // If nothing is detected, then be idle
        else
        {
            ChangeState(EnemyState.Idle);
        }
    }

    void ChasePlayer()
    {
        // Checks direction of player compared to enemy to determin movement direction
        if (playerPosition.position.x > transform.position.x && facingDirection == -1 ||
            playerPosition.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }

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
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", false);
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
        else if (enemyState == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", true);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking
}
