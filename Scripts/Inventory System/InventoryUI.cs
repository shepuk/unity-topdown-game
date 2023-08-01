using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryBox;
    public RectTransform ItemSlots;
    public RectTransform ItemSlotTemplate;

    [SerializeField]
    public FollowPlayer playerFollow;
    public bool inventoryOpen = false;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            inventoryOpen = !inventoryOpen;
            openCloseInventory();
        }
    }

    void openCloseInventory()
    {
        if (inventoryOpen == true)
        {
            inventoryBox.SetActive(true);
            playerFollow.inventoryOffset = 0.33f;
        }
        else
        {
            inventoryBox.SetActive(false);
            playerFollow.inventoryOffset = 0.5f;
        }
    }

    public void updateInventoySlots(ItemObject item)
    {
        GameObject inventoryItem = Instantiate(ItemSlotTemplate.gameObject, ItemSlots);
        inventoryItem.GetComponent<ItemLogic>().item = item;
        inventoryItem.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite =
            item.icon;
        inventoryItem.SetActive(true);
    }
}
