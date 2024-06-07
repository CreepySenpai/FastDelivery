using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    [SerializeField]
    private Item m_currentItem = new(ItemType.NONE);

    public ItemType GetCurrentType() => m_currentItem.Type;

    [SerializeField]
    private GameObject m_itemInBackPack;

    public void ResetItem(){
        m_currentItem.Type = ItemType.NONE;
        m_currentItem.Sprite = Item.QuestionMaskSprite;
        setItemImage();
    }

    public bool IsValidItem() => m_currentItem.Type != ItemType.NONE;

    public void SetCurrentItem(Item item){
        m_currentItem = item;
        setItemImage();
    }

    public Item GetCurrentItem() => m_currentItem;

    private void setItemImage() {
        m_itemInBackPack.GetComponent<Image>().sprite = m_currentItem.Sprite;
    }
}
