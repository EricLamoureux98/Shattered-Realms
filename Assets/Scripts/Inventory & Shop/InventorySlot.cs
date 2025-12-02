using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text quantityText;
    
    public int quantity;
    public ItemSO itemSO;

    public void UpdateUI()
    {
        if (itemSO != null)
        {
            itemImage.sprite = itemSO.icon;
            itemImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else
        {
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }
}
