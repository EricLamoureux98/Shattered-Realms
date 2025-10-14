using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform aim;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private int facingDirection = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        // Checks direction player is facing in contrast to movement direction
        if (moveInput.x > 0 && transform.localScale.x < 0 || moveInput.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        // Aim direction while walking
        Vector3 aimDirection = Vector3.right * moveInput.x + Vector3.up * moveInput.y;
        aim.rotation = Quaternion.LookRotation(Vector3.forward, aimDirection);


        anim.SetFloat("horizontal", Mathf.Abs(moveInput.x)); //MathF.Abs turns all numbers into positive
        anim.SetFloat("vertical", Mathf.Abs(moveInput.y)); //Required to run animate in both directions
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
