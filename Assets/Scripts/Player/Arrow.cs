using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] Sprite buriedSprite;

    [Header("Arrow Stats")]
    [SerializeField] float lifeSpan = 2f;
    [SerializeField] float speed;
    [SerializeField] int damage;

    [Header("Knockback")]
    [SerializeField] float knockbackForce;
    [SerializeField] float knockbackTime;
    [SerializeField] float stunTime;

    [HideInInspector] public Vector2 direction = Vector2.right;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb.linearVelocity = direction * speed;
        RotateArrow();
        Destroy(gameObject, lifeSpan);
    }

    void RotateArrow()
    {
        // Atan2 used to find angle between 2 points, --- Then convert that to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // If the object we hit is on one of the layers marked as "enemy"
        // This is better than comparing a tag
        if ((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<EnemyHealth>().UpdateHealth(-damage);
            collision.gameObject.GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce, knockbackTime, stunTime);
            AttachToTarget(collision.gameObject.transform);
        }

        // Bury the arrow
        else if ((obstacleLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            AttachToTarget(collision.gameObject.transform);
        }
    }

    void AttachToTarget(Transform target)
    {
        spriteRenderer.sprite = buriedSprite;

        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;

        transform.SetParent(target);
    }
}
