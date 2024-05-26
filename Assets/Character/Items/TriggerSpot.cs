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
        ItemGenerator.AddItem(new Item(ItemType.APPLE, "Item_Delivery/Book"));
        ItemGenerator.AddItem(new Item(ItemType.BOOK, "Item_Delivery/Book"));
        ItemGenerator.AddItem(new Item(ItemType.MAP, "Item_Delivery/Book"));
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
