using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBow : MonoBehaviour
{    
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float shootCooldown = 0.5f;

    Vector2 aimDirection = Vector2.right;
    float shootTimer;


    void Update()
    {
        shootTimer -= Time.deltaTime;
        HandleAiming();
    }

    public void FireArrow()
    {
        Arrow arrow = Instantiate(arrowPrefab, firepoint.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.direction = aimDirection;
        shootTimer = shootCooldown;
    }

    void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed && shootTimer <= 0)
        {
            FireArrow();
        }
    }
}
