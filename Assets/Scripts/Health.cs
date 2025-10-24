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
        currentHealth += amount;

        // Prevents your currentHealth from going above maxHealth or below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + "Health left: " + currentHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
