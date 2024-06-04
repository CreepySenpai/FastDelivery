using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Slider m_slider;

    [SerializeField]
    private TextMeshProUGUI m_loadingProcess;

    public void LoadLevel(int sceneIndex){
        StartCoroutine(loadSceneAsync(sceneIndex));
    }

    private IEnumerator loadSceneAsync(int sceneIndex){
        var op = SceneManager.LoadSceneAsync($"Level_{sceneIndex}");

        GameAssetsController.GetInstance().LoadingScene.SetActive(true);

        while(!op.isDone){
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            m_slider.value = progress;
            m_loadingProcess.text = $"{progress * 100.0f}%";
            yield return null;
        }
    }
}
