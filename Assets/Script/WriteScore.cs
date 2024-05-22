using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteScore : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;

    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text = $"Your Score {m_player.GetComponent<PlayerScore>().Score.ToString()}";
    }
}