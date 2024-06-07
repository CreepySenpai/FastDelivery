using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer m_audioMixer;

    private Resolution[] m_resolutions;

    [SerializeField]
    private TMP_Dropdown m_resolutionDropDown;

    private int m_currentResolution = 0;

    [SerializeField]
    private TMP_Dropdown m_graphicQualityDropDown;

    private void Start() {
        
        m_graphicQualityDropDown.value = QualitySettings.GetQualityLevel();
        m_graphicQualityDropDown.RefreshShownValue();

        m_resolutions = Screen.resolutions;

        m_resolutionDropDown.ClearOptions();

        List<string> resolutionList = new();

        for(int i = 0; i < m_resolutions.Length; ++i){

            resolutionList.Add($"{m_resolutions[i].width} x {m_resolutions[i].height}");

            if((m_resolutions[i].width == Screen.currentResolution.width) && (m_resolutions[i].height == Screen.currentResolution.height)){
                m_currentResolution = i;
            }
        }
        
        m_resolutionDropDown.AddOptions(resolutionList);

        m_resolutionDropDown.value = m_currentResolution;
        m_resolutionDropDown.RefreshShownValue();
    }

    public void SetVolume(float volume){
        m_audioMixer.SetFloat("maingamevolume", volume);
    }

    public void SetQuality(int quality){
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolution){
        m_currentResolution = resolution;
        Screen.SetResolution(m_resolutions[resolution].width, m_resolutions[resolution].height, Screen.fullScreen);
    }
}