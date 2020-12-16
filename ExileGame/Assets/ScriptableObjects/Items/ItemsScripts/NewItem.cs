using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items/New Item")]
public class NewItem : ItemSO
{
    private void Awake()
    {
        itemType = ItemType.NewItem;
    }
}
