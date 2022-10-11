using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    Item item;

    public Button RemoveButton;

    public void SetItem(Item newItem)
    {
        item = newItem;
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    

    public void UseItem()
    {
        Player.instance.IncreasePoint(item.value);
        RemoveItem();
    }
}
