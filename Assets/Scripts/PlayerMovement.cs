using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private int facingDirection = 1;
    private bool isKnockedBack;

    private PlayerCombat playerCombat;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerCombat = GetComponent<PlayerCombat>();
    }

    void FixedUpdate()
    {
        if (isKnockedBack == false)
        {
            rb.linearVelocity = moveInput * moveSpeed;

            // Checks direction player is facing in contrast to movement direction
            if (moveInput.x > 0 && transform.localScale.x < 0 || moveInput.x < 0 && transform.localScale.x > 0)
            {
                Flip();
            }

            anim.SetFloat("horizontal", Mathf.Abs(moveInput.x)); //MathF.Abs turns all numbers into positive
            anim.SetFloat("vertical", Mathf.Abs(moveInput.y)); //Required to run animate in both directions
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void KnockBack(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerCombat.Attack();
        }
    }
}
