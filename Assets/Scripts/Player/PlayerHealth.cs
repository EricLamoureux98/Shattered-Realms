using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] TMP_Text healthText;
    [SerializeField] Animator anim;


    void Start()
    {
        StatsManager.Instance.currentHealth = StatsManager.Instance.maxHealth;
        healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;
    }

    public void UpdateHealth(int amount)
    {
        StatsManager.Instance.currentHealth += amount;

        // Prevents your currentHealth from going above maxHealth or below 0
        StatsManager.Instance.currentHealth = Mathf.Clamp(StatsManager.Instance.currentHealth, 0, StatsManager.Instance.maxHealth);

        healthText.text = "HP: " + StatsManager.Instance.currentHealth + " / " + StatsManager.Instance.maxHealth;
        anim.Play("TextUpdate");

        if (StatsManager.Instance.currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
