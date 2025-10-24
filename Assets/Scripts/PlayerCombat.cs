using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float weaponRange;
    [SerializeField] int damage = 1;
    [SerializeField] float attackCooldown = 1f;
    [SerializeField] LayerMask enemyLayer;

    Animator anim;
    float timer;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            timer = attackCooldown;
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<Health>().UpdateHealth(-damage);
        }
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
