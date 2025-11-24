using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleSkillTree : MonoBehaviour
{
    [SerializeField] CanvasGroup skillsCanvas;

    bool skillTreeOpen = false;

    public void ToggleSkills(InputAction.CallbackContext context)
    {
        if (context.performed && skillTreeOpen)
        {
            Time.timeScale = 1;
            skillsCanvas.alpha = 0;
            skillsCanvas.blocksRaycasts = false;
            skillTreeOpen = false;
        }
        else if (context.performed && !skillTreeOpen)
        {
            Time.timeScale = 0;
            skillsCanvas.alpha = 1;
            skillsCanvas.blocksRaycasts = true;
            skillTreeOpen = true;
        }
    }
}
