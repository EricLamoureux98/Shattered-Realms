using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float weaponRange;
    [SerializeField] float knockbackForce;
    [SerializeField] float knockbackTime;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask playerLayer;

    public void Attack()
    {
        //Creates a circle around attackPoint with a radius of weaponRange
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        // If we hit the player
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().UpdateHealth(-damage);
            hits[0].GetComponent<PlayerMovement>().KnockBack(transform, knockbackForce, knockbackTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
