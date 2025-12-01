using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBow : MonoBehaviour
{   
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform firepoint;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float shootCooldown = 0.5f;

    Vector2 aimDirection = Vector2.right;
    float shootTimer;

    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void OnEnable()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1,1);
    }

    void OnDisable()
    {
        anim.SetLayerWeight(0, 1);
        anim.SetLayerWeight(1, 0);
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
        HandleAiming();
    }

    public void FireArrow()
    {
        if (shootTimer <= 0)
        {
            Arrow arrow = Instantiate(arrowPrefab, firepoint.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = aimDirection;
            shootTimer = shootCooldown;
        }
        anim.SetBool("isShooting", false);
        playerMovement.isShooting = false;
    }

    void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
            anim.SetFloat("aimX", aimDirection.x);
            anim.SetFloat("aimY", aimDirection.y);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed && shootTimer <= 0)
        {
            playerMovement.isShooting = true;
            anim.SetBool("isShooting", true);
            //FireArrow();
        }
    }
}
