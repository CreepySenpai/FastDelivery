using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePopup : MonoBehaviour
{
    public static ScorePopup Create(Vector3 pos, int score) {
        var scorePopupInstance = Instantiate(GameAssetsController.GetInstance().ScorePopup, pos, Quaternion.identity);
        ScorePopup scorePopup = scorePopupInstance.GetComponent<ScorePopup>();
        scorePopup.SetPopupScore(score);

        return scorePopup;
    }

    private const float m_textMoveSpeed = 2.0f;
    private TextMeshPro m_textMesh;

    private Color m_textColor;

    [SerializeField]
    private float m_disappearTime;

    private void Awake() {
        m_textMesh = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        transform.position += new Vector3(0.0f, m_textMoveSpeed) * Time.deltaTime;

        m_disappearTime -= Time.deltaTime;

        if(m_disappearTime < 0.0f){
            m_textColor.a -= 2.0f * Time.deltaTime;
            m_textMesh.color = m_textColor;

            if(m_textColor.a < 0.0f){
                Destroy(gameObject);
            }
        }
    }

    public void SetPopupScore(int score) {
        if(score < 0){
            AudioController.GetInstance().PlayMusic("SubScore");
            m_textMesh.color = Color.red;
            m_textMesh.text = $"-{score}";
        }
        else{
            AudioController.GetInstance().PlayMusic("AddScore");
            m_textMesh.color = Color.green;
            m_textMesh.text = $"+{score}";
        }
        
        m_textColor = m_textMesh.color;
        m_disappearTime = 1.0f;
    }
}
