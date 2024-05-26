using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    [SerializeField]
    private Button[] m_levelButtons;
    

    private void Awake() {
        int levelCount = gameObject.transform.childCount;
        
        m_levelButtons = new Button[levelCount];
        for (int i = 0; i < levelCount; ++i) {
            m_levelButtons[i] = gameObject.transform.GetChild(i).GetComponent<Button>();
        }
    }

    public void OpenLevel(int level) {
        SceneManager.LoadScene($"Level_{level}");
    }
}
