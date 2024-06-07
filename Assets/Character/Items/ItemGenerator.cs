using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ItemGenerator{
    private static List<Item> s_itemList = new();

    public static void AddItem(Item item) => s_itemList.Add(item);

    // Note(Creepy): Hate it
    public static Item GetRandomItem(){
        var temp = s_itemList[Random.Range(0, s_itemList.Count)];
        return new(temp.Type, temp.Sprite);
    }
}
