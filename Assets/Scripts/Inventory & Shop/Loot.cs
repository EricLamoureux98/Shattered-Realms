using UnityEngine;

public class Loot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ItemSO itemSO;
    [SerializeField]SpriteRenderer sr;
    [SerializeField]Animator anim;

    [SerializeField] int quantity;

    void OnValidate()
    {
        if (itemSO == null) return;

        sr.sprite = itemSO.icon;
        this.name = itemSO.itemName;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            anim.Play("Loot_Pickup");
            Destroy(gameObject, 0.5f);
        }
    }
}
