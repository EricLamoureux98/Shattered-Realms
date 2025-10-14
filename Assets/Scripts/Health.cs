using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Health left: " + currentHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
