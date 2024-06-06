using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject m_levelPanel;

    public void PlayGame()
    {
        m_levelPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
