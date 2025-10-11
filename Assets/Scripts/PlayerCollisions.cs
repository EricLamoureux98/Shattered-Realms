using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{


    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth.UpdateHealth(1);
        }
    }
}
