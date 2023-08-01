using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemObject> Items = new();
    public List<ItemObject> Spells = new();
    public List<ItemObject> Weapons = new();
    public List<ItemObject> Upgrades = new();

    public InventoryUI inventoryUI;
    public Notification notification;

    public void AddItem(ItemObject itemToAdd)
    {
        Items.Add(itemToAdd);
        inventoryUI.updateInventoySlots(itemToAdd);

        notification.sendNotification("Obtained " + itemToAdd.Name + "!");

        // foreach (var x in Items)
        // {
        //     Debug.Log(x.Name.ToString());
        // }
    }

    public void RemoveItem(ItemObject itemToRemove)
    {
        Items.Remove(itemToRemove);
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
}
