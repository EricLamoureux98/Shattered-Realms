using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float lifeSpan = 2f;
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] float knockbackForce;
    [SerializeField] float knockbackTime;
    [SerializeField] float stunTime;

    [HideInInspector] public Vector2 direction = Vector2.right;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        }
    }
}
