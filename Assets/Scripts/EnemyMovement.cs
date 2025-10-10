using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private Rigidbody2D rb;
    private Transform playerPosition;
    private bool chasingPlayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (chasingPlayer)
        {
            ChasePlayer();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (playerPosition == null)
            {
                playerPosition = collision.gameObject.transform;
            }
            chasingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            chasingPlayer = false;
        }
    }
    
    void ChasePlayer()
    {
        Vector2 direction = (playerPosition.transform.position - transform.position).normalized;
        rb.linearVelocity = direction * moveSpeed;
    }

}
