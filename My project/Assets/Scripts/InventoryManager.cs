using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item> ();
    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] InventoryItemControllers;

    private void Awake()
    {
        Instance = this;
    }
    
    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        //Clean content before open
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            var obj = Instantiate(InventoryItem, ItemContent);

            obj.transform.Find("RemoveButton").gameObject.SetActive(true);

            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.icon;

            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            itemName.text = item.itemName;
        }

        setInventoryItemControllers();
    }

    public void setInventoryItemControllers()
    {
        InventoryItemControllers = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for(int i = 0; i<Items.Count; i++)
        {
            InventoryItemControllers[i].SetItem(Items[i]);
        }

    }
}
