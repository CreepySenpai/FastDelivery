using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private Button[] m_levelButtons;

    [SerializeField]
    private LevelLoader m_levelLoader;

    private void Awake() {
        int levelCount = gameObject.transform.childCount;
        
        m_levelButtons = new Button[levelCount];
        
        for (int i = 0; i < levelCount; ++i) {
            m_levelButtons[i] = gameObject.transform.GetChild(i).GetComponent<Button>();
        }

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for(int i = 0; i < levelCount; ++i) {
            m_levelButtons[i].interactable = false;
        }

        for(int i = 0; i < unlockedLevel; ++i) {
            m_levelButtons[i].interactable = true;
        }
        
    }

    public void OpenLevel(int level) {
        // SceneManager.LoadScene($"Level_{level}");
        m_levelLoader.LoadLevel(level);
    }
}
