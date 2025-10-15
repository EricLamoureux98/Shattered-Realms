using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{


    private Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //health.UpdateHealth(1);
        }
    }
}
