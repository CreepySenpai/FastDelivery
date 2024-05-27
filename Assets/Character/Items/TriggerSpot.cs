using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSpot : MonoBehaviour
{
    private CircleCollider2D m_CircleCollider;

    [SerializeField]
    private GameObject m_player;

    private bool m_isPlayerContact = false;

    // Note(Creepy): Call Awake because it call before Start() -> GetRandomItem()
    void Awake(){
        ItemGenerator.AddItem(new Item(ItemType.APPLE, "Item_Delivery/red_apple_p"));
        ItemGenerator.AddItem(new Item(ItemType.BOOK, "Item_Delivery/Book"));
        ItemGenerator.AddItem(new Item(ItemType.BANANA, "Item_Delivery/banana"));
        ItemGenerator.AddItem(new Item(ItemType.EGG, "Item_Delivery/egg_brown_p"));
        ItemGenerator.AddItem(new Item(ItemType.CABBAGE, "Item_Delivery/cabbage_p"));
        ItemGenerator.AddItem(new Item(ItemType.FLOUR, "Item_Delivery/flour"));
        ItemGenerator.AddItem(new Item(ItemType.MILK, "Item_Delivery/milk_plastic"));
        ItemGenerator.AddItem(new Item(ItemType.MEAT, "Item_Delivery/meat2_p"));
        ItemGenerator.AddItem(new Item(ItemType.CHOCOLATE, "Item_Delivery/milk_chocolate"));
        ItemGenerator.AddItem(new Item(ItemType.OIL, "Item_Delivery/olive_oil"));
        ItemGenerator.AddItem(new Item(ItemType.POTATO_CHIP, "Item_Delivery/potatochip_blue"));
        ItemGenerator.AddItem(new Item(ItemType.COKE, "Item_Delivery/soft_drink_red"));
        ItemGenerator.AddItem(new Item(ItemType.GLOVES, "Item_Delivery/cleaning_gloves"));
        ItemGenerator.AddItem(new Item(ItemType.DUCK, "Item_Delivery/rubber_duck"));
        ItemGenerator.AddItem(new Item(ItemType.POTATO_BAG, "Item_Delivery/potato_p"));
    }

    private void Update() {
        if(!m_isPlayerContact) return;

        if(Input.GetKeyDown(KeyCode.Space)){
            var playerComp = m_player.GetComponent<PlayerMovement>();

            if(playerComp.CurrentItem.Type == ItemType.NONE){
                playerComp.CurrentItem = ItemGenerator.GetRandomItem();
                Debug.Log($"Random: {playerComp.CurrentItem.Type}");
            }
            else {
                Debug.Log("Current Hold");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        m_isPlayerContact = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        m_isPlayerContact = false;
    }
}
