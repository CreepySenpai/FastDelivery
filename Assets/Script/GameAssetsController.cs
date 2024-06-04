using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetsController : MonoBehaviour
{
    private static GameAssetsController instance = null;

    public static GameAssetsController GetInstance() {
        if (instance == null)
        {
            instance = GameObject.Find("GameAssetsController").GetComponent<GameAssetsController>();
        }
        return instance;
    }

    public GameObject ScorePopup;

    public GameObject LoadingScene;
}
