using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType : int {
    NONE = 0, APPLE = 100, BOOK = 200, MAP = 300
}

public class Item
{
    public ItemType Type{get; set;}
    public Sprite Sprite{get; set;}

    public Item() {
        
    }

    public Item(ItemType type) => Type = type;

    public Item(ItemType type, string path) : this(type) {
        Sprite = Resources.Load<Sprite>(path);
    }
}
