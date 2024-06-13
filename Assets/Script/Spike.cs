using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Animator m_animator;

    [Range(0, 50.0f)]
    public float m_spikeHasDameDuration = 10.0f;

    [Range(0, 50.0f)]
    public float m_spikeNormalDuration = 5.0f;

    private float m_currentDameTime = 0.0f;
    private float m_currentNormalTime = 0.0f;

    private bool m_isHasDame = false;

    void Start()
    {
        m_animator = GetComponent<Animator>();       
    }

    void Update()
    {
        if(!m_isHasDame){
            m_currentNormalTime += Time.deltaTime;
        }

        if(m_isHasDame){
            m_currentDameTime += Time.deltaTime;
        }

        if(m_currentDameTime >= m_spikeHasDameDuration){
            m_isHasDame = false;
            m_currentDameTime = 0.0f;
            m_animator.SetBool("IsSpikeActive", m_isHasDame);
        }

        if(m_currentNormalTime >= m_spikeNormalDuration){
            m_isHasDame = true;
            m_currentNormalTime = 0.0f;
            m_animator.SetBool("IsSpikeActive", m_isHasDame);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(m_isHasDame){
            other.gameObject.GetComponent<PlayerItem>().ResetItem();
        }
    }
}
