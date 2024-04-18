using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    NONE, APPLE, WAIFU, ONICHAN, DDD
}

public class Item
{
    public ItemType Type{get; set;}

    public Item() {}

    public Item(ItemType type) => Type = type;
}
