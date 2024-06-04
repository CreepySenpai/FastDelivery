using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_gameWinMenu;

    [SerializeField]
    private GameObject m_gameOverMenu;

    [SerializeField]
    private GameObject m_timeCounter;

    [SerializeField]
    private GameObject m_selectLevelPanel;

    [SerializeField]
    private GameObject m_pauseButton;

    [SerializeField]
    private GameObject m_remainTimePanel;

    [SerializeField]
    private GameObject m_backPackPanel;

    private static MenuController instance = null;

    public static MenuController GetInstance() {
        if (instance == null)
        {
            instance = GameObject.Find("MenuController").GetComponent<MenuController>();
        }
        return instance;
    }

    public void ActiveWinMenu() => m_gameWinMenu.SetActive(true);
    public void DisableWinMenu() => m_gameWinMenu.SetActive(false);

    public void ActiveGameOverMenu() => m_gameOverMenu.SetActive(true);
    public void DisableGameOverMenu() => m_gameOverMenu.SetActive(true);

    public void ActiveTimeCounter() => m_timeCounter.SetActive(true);
    public void DisableTimeCounter() => m_timeCounter.SetActive(false);

    public void ActiveLevelMenu() => m_selectLevelPanel.SetActive(true);
    public void DisableLevelMenu() => m_selectLevelPanel.SetActive(false);


    public void ActivePauseButton() => m_pauseButton.SetActive(true);
    public void DisablePauseButton() => m_pauseButton.SetActive(false);

    public void ActiveRemainTime() => m_remainTimePanel.SetActive(true);
    public void DisableRemainTime() => m_remainTimePanel.SetActive(false);

    public void ActivePlayerBackPack() => m_backPackPanel.SetActive(true);
    public void DisablePlayerBackPack() => m_backPackPanel.SetActive(false);
}
