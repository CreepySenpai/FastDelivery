using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerSpot : MonoBehaviour
{
    private CircleCollider2D m_CircleCollider;

    private void OnTriggerEnter2D(Collider2D other) => gameObject.transform.GetChild(0).gameObject.SetActive(true);

    private void OnTriggerStay2D(Collider2D other) {
        
        if(Input.GetKeyDown(KeyCode.Space)){
            var playerComp = other.GetComponent<PlayerMovement>();
            if(playerComp.CurrentItem.Type == ItemType.NONE){
                playerComp.CurrentItem = ItemGenerator.GetRandomItem();
                Debug.Log($"Random: {playerComp.CurrentItem.Type}");
            }
            else {
                Debug.Log("Current Hold");
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) => gameObject.transform.GetChild(0).gameObject.SetActive(false);
}
