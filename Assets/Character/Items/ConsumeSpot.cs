using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeSpot : MonoBehaviour
{

    // TODO(Creepy): Move to another file
    public static Sprite QuestionMaskSprite;

    [SerializeField]
    private CircleCollider2D m_CircleCollider;

    private Item m_currentItem = new Item(ItemType.NONE);

    void Start(){
        QuestionMaskSprite = Resources.Load<Sprite>("Item_Delivery/Question_Mark");
        m_CircleCollider = GetComponent<CircleCollider2D>();

        m_currentItem = ItemGenerator.GetRandomItem();
        Debug.Log($"Gonna Create Random Item: ${m_currentItem.Type.ToString()}");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = m_currentItem.Sprite;
    }

    private void OnTriggerStay2D(Collider2D other) {

        if(Input.GetKeyDown(KeyCode.Space)){
            var playerComp = other.GetComponent<PlayerMovement>();
            var playerScore = other.GetComponent<PlayerScore>();
            if(playerComp.CurrentItem.Type != ItemType.NONE){
                
                Debug.Log($"Gonna Consume: {playerComp.CurrentItem.Type}");
                playerScore.Score += (int)playerComp.CurrentItem.Type;
                
                playerComp.CurrentItem.Type = ItemType.NONE;
                
                m_currentItem = ItemGenerator.GetRandomItem();
            }
            else {
                Debug.Log("Not thing to consume");
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = QuestionMaskSprite;
    }
}
