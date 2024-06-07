using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetsController : MonoBehaviour
{
    private static GameAssetsController s_instance = null;

    public static GameAssetsController GetInstance() {
        if (s_instance == null)
        {
            s_instance = GameObject.Find("GameAssetsController").GetComponent<GameAssetsController>();
        }
        return s_instance;
    }

    public GameObject ScorePopup;

    public GameObject LoadingScene;

    public GameObject PlayerBackPack;

    public GameObject ScoreBar;
}
