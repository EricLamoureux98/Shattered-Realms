using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    void Start()
    {
        StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;

        // Prevents your currentHealth from going above maxHealth or below 0
        StatsManager.Instance.currentHealth = Mathf.Clamp(StatsManager.Instance.currentHealth, 0, StatsManager.Instance.maxHealth);

        Debug.Log(gameObject.name + "Health left: " + StatsManager.Instance.currentHealth);

        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
