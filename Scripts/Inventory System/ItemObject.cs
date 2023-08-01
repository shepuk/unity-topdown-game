using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/ItemObject")]
public class ItemObject : ScriptableObject
{
    [SerializeField]
    public string Name;

    [TextArea]
    public string Description;

    public Sprite icon;
}
