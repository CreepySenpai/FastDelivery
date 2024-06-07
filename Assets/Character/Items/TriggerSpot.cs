using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSpot : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;

    [SerializeField]
    private SpriteRenderer m_triggerSprite;

    private bool m_isPlayerContact = false;

    [SerializeField]
    private Queue<Item> m_randomQueue = new();

    private const int m_queueMaxSize = 3;

    // Note(Creepy): Call Awake because it call before Start() -> GetRandomItem()
    void Awake(){
        
        // ItemGenerator.AddItem(new(ItemType.APPLE, "Item_Delivery/red_apple_p"));
        // ItemGenerator.AddItem(new(ItemType.BOOK, "Item_Delivery/Book"));
        // ItemGenerator.AddItem(new(ItemType.BANANA, "Item_Delivery/banana"));
        // ItemGenerator.AddItem(new(ItemType.EGG, "Item_Delivery/egg_brown_p"));
        // ItemGenerator.AddItem(new(ItemType.CABBAGE, "Item_Delivery/cabbage_p"));
        // ItemGenerator.AddItem(new(ItemType.FLOUR, "Item_Delivery/flour"));
        // ItemGenerator.AddItem(new(ItemType.MILK, "Item_Delivery/milk_plastic"));
        // ItemGenerator.AddItem(new(ItemType.MEAT, "Item_Delivery/meat2_p"));
        // ItemGenerator.AddItem(new(ItemType.CHOCOLATE, "Item_Delivery/milk_chocolate"));
        // ItemGenerator.AddItem(new(ItemType.OIL, "Item_Delivery/olive_oil"));
        // ItemGenerator.AddItem(new(ItemType.POTATO_CHIP, "Item_Delivery/potatochip_blue"));
        // ItemGenerator.AddItem(new(ItemType.COKE, "Item_Delivery/soft_drink_red"));
        ItemGenerator.AddItem(new(ItemType.GLOVES, "Item_Delivery/cleaning_gloves"));
        ItemGenerator.AddItem(new(ItemType.DUCK, "Item_Delivery/rubber_duck"));
        ItemGenerator.AddItem(new(ItemType.POTATO_BAG, "Item_Delivery/potato_p"));

        // Note(Creepy): Because OnTriggerEnter2D call first Update so we need to ensure queue has at least 1 item
        m_randomQueue.Enqueue(ItemGenerator.GetRandomItem());
    }

    private void Update() {
        if(!m_isPlayerContact) return;

        // Note(Creepy): Ensure Random Queue Alway Have Value
        while(m_randomQueue.Count < m_queueMaxSize){
            m_randomQueue.Enqueue(ItemGenerator.GetRandomItem());
        }

        // foreach(Item item in m_randomQueue){
        //     Debug.Log("It :" + item.Type.ToString());
        // }

        if(Input.GetKeyDown(KeyCode.Space)){
            var playerItem = m_player.GetComponent<PlayerItem>();

            if(!playerItem.IsValidItem()){

                playerItem.SetCurrentItem(m_randomQueue.Dequeue()); // Get Item From Random Queue
                
                m_triggerSprite.sprite = m_randomQueue.Peek().Sprite;
                Debug.Log($"Random: {playerItem.GetCurrentType()}");
            }
            else {
                Debug.Log("Current Hold");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.name == "Player"){
            var generatedBox = gameObject.transform.GetChild(0).gameObject;
            generatedBox.SetActive(true);

            m_triggerSprite.sprite = m_randomQueue.Peek().Sprite;
            m_isPlayerContact = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            var generatedBox = gameObject.transform.GetChild(0).gameObject;
            generatedBox.SetActive(false);

            m_triggerSprite.sprite = Item.QuestionMaskSprite;

            m_isPlayerContact = false;
        }
    }
}
