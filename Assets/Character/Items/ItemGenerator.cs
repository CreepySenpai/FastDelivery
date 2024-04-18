using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemGenerator{
    private static List<Item> s_itemList = new List<Item>(){
        new Item(ItemType.APPLE),
        new Item(ItemType.WAIFU),
        new Item(ItemType.ONICHAN),
        new Item(ItemType.DDD)
    };

    public static Item GetRandomItem() => s_itemList[Random.Range(0, s_itemList.Count)];
}
