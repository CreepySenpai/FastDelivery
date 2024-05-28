using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemGenerator{
    private static List<Item> s_itemList = new();

    public static void AddItem(Item item) => s_itemList.Add(item);

    public static Item GetRandomItem() => s_itemList[Random.Range(0, s_itemList.Count)];
}
