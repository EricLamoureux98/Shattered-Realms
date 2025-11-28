using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{


    private EnemyHealth health;

    void Start()
    {
        health = GetComponent<EnemyHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //health.UpdateHealth(1);
        }
    }
}
