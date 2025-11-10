using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    [SerializeField] Slider expSlider;
    [SerializeField] TMP_Text currentLevelText;
    [SerializeField] float expGrowthMultiplier = 1.2f;

    int level;
    int currentExp;
    int expToLevel = 10;

    void Start()
    {
        UpdateUI();
    }

    // += adds GainExperience to the event's subscriber list
    void OnEnable()
    {
        Health.OnEnemyDefeated += GainExperience;
    }

    // -= removes it when the object is disabled (prevents memory leaks)
    void OnDisable()
    {
        Health.OnEnemyDefeated -= GainExperience;
    }

    public void GainExperience(int amount)
    {
        currentExp += amount;
        if (currentExp >= expToLevel)
        {
            LevelUp();
        }

        UpdateUI();
    }

    void LevelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
    }
    
    void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }
}
