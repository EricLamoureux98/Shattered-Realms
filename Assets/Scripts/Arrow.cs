using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float lifeSpan = 2f;
    [SerializeField] float speed;

    Vector2 direction = Vector2.right;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = direction * speed;
        Destroy(gameObject, lifeSpan);
    }
}
