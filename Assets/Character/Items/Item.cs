using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType : int {
    NONE = 0, APPLE = 10, BOOK = 12, BANANA = 14, EGG = 16, CABBAGE = 18, FLOUR = 20, MILK = 22, MEAT = 24
    , CHOCOLATE = 20, OIL = 20, POTATO_CHIP = 10, COKE = 10, GLOVES = 20, DUCK = 10, POTATO_BAG = 20

}

[Serializable]
public class Item
{
    public ItemType Type{get; set;}
    public Sprite Sprite{get; set;}

    public string SpritePath{get; set;}

    public Item() {
        
    }

    public Item(ItemType type) => Type = type;

    public Item(ItemType type, string path) : this(type) {
        SpritePath = path;
        Sprite = Resources.Load<Sprite>(path);
    }

    public Item(ItemType type, Sprite sprite) : this(type) {
        Sprite = sprite;
    }


    public static Sprite QuestionMaskSprite;
}
