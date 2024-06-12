using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private GameObject m_showInteract;

    public void ShowInteract(Vector3 loc) {
        m_showInteract.SetActive(true);
        m_showInteract.transform.position = loc;
    }

    public void HideInteract() => m_showInteract.SetActive(false);
}
