using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField]
    private string Name;
    [SerializeField]
    private string KeyID;
    [SerializeField]
    private Color ItemColor;
    [SerializeField]
    private Sprite Sprite;

    public void PickUp()
    {
        Inventory.Instance.AddItem(new InventoryItem(Name, KeyID, ItemColor, Sprite));
        gameObject.SetActive(false);
    }
}
