using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool m_isPlayerEnter = false;

    private bool m_isPlayerOpen = false;

    private PlayerInteract m_hideObj;

    private void Update() {
        if (!m_isPlayerEnter) {
            return;
        }

        if(m_isPlayerOpen){
            return;
        }

        if(Input.GetKeyDown(KeyCode.E)){
            AudioController.GetInstance().PlayMusic("OpenDoor");
            m_isPlayerOpen = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            m_hideObj.HideInteract();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        m_isPlayerEnter = true;
        if(!m_isPlayerOpen){
            m_hideObj = other.gameObject.GetComponent<PlayerInteract>();
            m_hideObj.ShowInteract(transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        m_isPlayerEnter = false;
        m_hideObj.HideInteract();
    }
}
