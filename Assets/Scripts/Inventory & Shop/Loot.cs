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
}
