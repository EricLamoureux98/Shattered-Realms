using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;

    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        if (currentHealth > 0)
        {
            currentHealth -= amount;
            Debug.Log("Health left: " + currentHealth);
        }
        else if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
