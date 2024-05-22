using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public long Score;

    // TODO(Creepy): Move to level manager
    public long LevelScore;

    [SerializeField]
    private GameObject m_gameWinMenu;

    void Update()
    {
        if(Score >= LevelScore) {
            m_gameWinMenu.SetActive(true);
        }
    }

    public void ResetScore() => Score = 0;
}