using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType : int {
    NONE = 0, APPLE = 10, BOOK = 12, BANANA = 14, EGG = 16, CABBAGE = 18, FLOUR = 20, MILK = 22, MEAT = 24
    , CHOCOLATE = 26, OIL = 28, POTATO_CHIP = 30, COKE = 32, GLOVES = 34, DUCK = 36, POTATO_BAG = 38

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
