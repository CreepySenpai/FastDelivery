using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeSpot : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;

    [SerializeField]
    private bool m_isPlayerContact = false;

    private Item m_currentItem = new(ItemType.NONE);

    [SerializeField]
    private SpriteRenderer m_consumerSprite;

    void Start(){
        Item.QuestionMaskSprite = Resources.Load<Sprite>("Item_Delivery/Question_Mark");

        m_currentItem = ItemGenerator.GetRandomItem();
        Debug.Log($"Gonna Create Random Item: ${m_currentItem.Type.ToString()}");
    }

    private void Update() {

        if(!m_isPlayerContact) {
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)){

            var playerItem = m_player.GetComponent<PlayerItem>();
            var playerScore = m_player.GetComponent<PlayerScore>();

            if(playerItem.IsValidItem()){

                Debug.Log($"Gonna Consume: {playerItem.GetCurrentType()}");

                if(playerItem.GetCurrentType() == m_currentItem.Type) {
                    playerScore.AddScore((int)playerItem.GetCurrentType());
                }
                else {
                    playerScore.AddScore(-((int)playerItem.GetCurrentType() / 10));
                }

                playerItem.ResetItem();
                m_currentItem = ItemGenerator.GetRandomItem();
            }
            else {
                Debug.Log("Not thing to consume");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            m_consumerSprite.sprite = m_currentItem.Sprite;
            m_isPlayerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player"){
            m_consumerSprite.sprite = Item.QuestionMaskSprite;
            m_isPlayerContact = false;
        }
    }
}
