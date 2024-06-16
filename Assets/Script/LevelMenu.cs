using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private Button[] m_levelButtons;

    [SerializeField]
    private LevelLoader m_levelLoader;

    private const int m_maxLevelPerPage = 6;
    private int m_maxPage = 0;
    private int m_currentPage = 0;

    private int m_levelCount = 0;

    // NOTE(Creepy): Reset When Play Test
    private void Awake() {
        PlayerPrefs.SetInt("UnlockedLevel", 1);

        m_levelCount = gameObject.transform.childCount;

        m_maxPage = m_levelCount / m_maxLevelPerPage;

        if(m_levelCount % m_maxLevelPerPage != 0){
            ++m_maxPage;
        }

        m_levelButtons = new Button[m_levelCount];
        
        for (int i = 0; i < m_levelCount; ++i) {
            m_levelButtons[i] = gameObject.transform.GetChild(i).GetComponent<Button>();
        }

        for(int i = 0; i < m_levelCount; ++i) {
            m_levelButtons[i].interactable = false;
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for(int i = 0; i < unlockedLevel; ++i) {
            m_levelButtons[i].interactable = true;
        }

    }

    private void Update() {

        for(int i = 0; i < m_levelCount; ++i) {
            m_levelButtons[i].gameObject.SetActive(false);
        }

        for(int i = 0; i < m_maxLevelPerPage; ++i){

            int activePageLevelIndex = (m_maxLevelPerPage * m_currentPage) + i;

            if(activePageLevelIndex < m_levelCount){
                m_levelButtons[activePageLevelIndex].gameObject.SetActive(true);
            }
            
        }
    }

    public void OpenLevel(int level) {
        m_levelLoader.LoadLevel(level);
    }

    public void NextPage(){
        if(m_currentPage < m_maxPage - 1){
            ++m_currentPage;
        }
    }

    public void PrevPage(){
        if(m_currentPage > 0){
            --m_currentPage;
        }
    }
}
