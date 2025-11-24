using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] PlayerCombat combat; 

    void OnEnable()
    {
        SkillSlot.OnAbilityPointSpent += HandleAbilitySpent;
    }

    void OnDisable()
    {
        SkillSlot.OnAbilityPointSpent -= HandleAbilitySpent;
    }

    void HandleAbilitySpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;

        switch (skillName)
        {
            case "Max Health Boost":
                StatsManager.Instance.UpdateMaxHealth(1);
                break;

            case "Sword Slash":
                combat.enabled = true;
                break;

            default:
                Debug.LogWarning("Unknown skill: " + skillName);
                break;
        }
    }
}
