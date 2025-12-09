using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatsUI : MonoBehaviour
{
    [SerializeField] GameObject[] statsSlots;
    [SerializeField] CanvasGroup statsCanvas;

    bool statsOpen = false;

    void Start()
    {
        UpdateAllStats();
    }

    public void UpdateDamage()
    {
        statsSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage: " + StatsManager.Instance.damage;
    }

    public void UpdateSpeed()
    {
        statsSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed: " + StatsManager.Instance.speed;
    }

    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }

    public void ToggleStats(InputAction.CallbackContext context)
    {
        if (context.performed && statsOpen)
        {
            UpdateAllStats();
            Time.timeScale = 1;
            statsCanvas.alpha = 0;
            statsCanvas.blocksRaycasts = false;
            statsOpen = false;
        }
        else if (context.performed && !statsOpen)
        {
            UpdateAllStats();
            Time.timeScale = 0;
            statsCanvas.alpha = 1;
            statsCanvas.blocksRaycasts = true;
            statsOpen = true;
        }
    }
}
