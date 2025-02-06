using UnityEngine;

public class ItemData
{
    public string itemName;
    [TextArea] public string itemDescription;

    public ItemData()
    {
    }

    public ItemData(string itemName, string itemDescription)
    {
        this.itemName = itemName;
        this.itemDescription = itemDescription;
    }
}
