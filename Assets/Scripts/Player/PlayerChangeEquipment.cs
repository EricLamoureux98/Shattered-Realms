using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChangeEquipment : MonoBehaviour
{
    
    [SerializeField] PlayerCombat combat;
    [SerializeField] PlayerBow bow;

    public void ChangeEquipment (InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            combat.enabled = !combat.enabled;
            bow.enabled = !bow.enabled;
        }
    }

}
