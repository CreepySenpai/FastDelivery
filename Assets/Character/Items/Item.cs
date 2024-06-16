using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType : int {
    NONE = 0, APPLE = 10, BOOK = 12, BANANA = 14, EGG = 16, CABBAGE = 18, FLOUR = 20, MILK = 22, MEAT = 24
    , CHOCOLATE = 10, OIL = 12, POTATO_CHIP = 14, COKE = 16, GLOVES = 18, DUCK = 20, POTATO_BAG = 22

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
