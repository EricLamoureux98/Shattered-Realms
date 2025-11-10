using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int expReward = 3;

    // Observer pattern
    public delegate void EnemyDefeated(int exp);
    public static event EnemyDefeated OnEnemyDefeated;

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

        if (currentHealth <= 0)
        {
            OnEnemyDefeated(expReward);
            Destroy(gameObject);
        }
    }
}
