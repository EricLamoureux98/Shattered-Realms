using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBow : MonoBehaviour
{    
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject arrowPrefab;


    // void Update()
    // {
    //     Shoot();
    // }

    public void FireArrow()
    {
        Instantiate(arrowPrefab, firepoint.position, Quaternion.identity);
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            FireArrow();
        }
    }
}
