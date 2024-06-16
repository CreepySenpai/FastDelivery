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
        List<Item> levelGenList = new();
        levelGenList.Add(new(ItemType.APPLE, "Item_Delivery/red_apple_p"));
        levelGenList.Add(new(ItemType.APPLE, "Item_Delivery/red_apple_p"));
        levelGenList.Add(new(ItemType.BANANA, "Item_Delivery/banana"));
        levelGenList.Add(new(ItemType.EGG, "Item_Delivery/egg_brown_p"));
        levelGenList.Add(new(ItemType.CABBAGE, "Item_Delivery/cabbage_p"));
        levelGenList.Add(new(ItemType.FLOUR, "Item_Delivery/flour"));
        levelGenList.Add(new(ItemType.MILK, "Item_Delivery/milk_plastic"));
        levelGenList.Add(new(ItemType.MEAT, "Item_Delivery/meat2_p"));
        //levelGenList.Add(new(ItemType.CHOCOLATE, "Item_Delivery/milk_chocolate"));
        //levelGenList.Add(new(ItemType.OIL, "Item_Delivery/olive_oil"));
        //levelGenList.Add(new(ItemType.POTATO_CHIP, "Item_Delivery/potatochip_blue"));
        //levelGenList.Add(new(ItemType.COKE, "Item_Delivery/soft_drink_red"));
        //levelGenList.Add(new(ItemType.GLOVES, "Item_Delivery/cleaning_gloves"));
        //levelGenList.Add(new(ItemType.DUCK, "Item_Delivery/rubber_duck"));
        //levelGenList.Add(new(ItemType.POTATO_BAG, "Item_Delivery/potato_p"));

        for(int i = 0; i < m_queueMaxSize; ++i){
            var item = levelGenList[Random.Range(0, levelGenList.Count)];
            ItemGenerator.AddItem(new(item.Type, item.Sprite));
        }

        // Note(Creepy): Because OnTriggerEnter2D call first Update so we need to ensure queue has at least 1 item
        m_randomQueue.Enqueue(ItemGenerator.GetRandomItem());
    }

    private void Update() {
        if(!m_isPlayerContact) return;

        // Note(Creepy): Ensure Random Queue Alway Have Value
        while(m_randomQueue.Count < m_queueMaxSize){
            m_randomQueue.Enqueue(ItemGenerator.GetRandomItem());
        }

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
