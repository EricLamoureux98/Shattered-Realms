using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float weaponRange;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask playerLayer;

    public void Attack()
    {
        //Creates a circle around attackPoint with a radius of weaponRange
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        // If we hit the player
        if (hits.Length > 0)
        {
            hits[0].GetComponent<Health>().UpdateHealth(-damage);
        }
    }
}
