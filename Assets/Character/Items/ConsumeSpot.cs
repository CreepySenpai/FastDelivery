using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumeSpot : MonoBehaviour
{
    private CircleCollider2D m_CircleCollider;

    private void OnTriggerEnter2D(Collider2D other) => gameObject.transform.GetChild(0).gameObject.SetActive(true);

    private void OnTriggerStay2D(Collider2D other) {

        if(Input.GetKeyDown(KeyCode.Space)){
            var playerComp = other.GetComponent<PlayerMovement>();
            if(playerComp.CurrentItem.Type != ItemType.NONE){

                Debug.Log($"Gonna Consume: {playerComp.CurrentItem.Type}");
                
                playerComp.CurrentItem.Type = ItemType.NONE;
            }
            else {
                Debug.Log("Not thing to consume");
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) => gameObject.transform.GetChild(0).gameObject.SetActive(false);
}
