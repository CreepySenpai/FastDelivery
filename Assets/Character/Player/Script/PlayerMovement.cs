using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

enum PlayerState{
    IDLE = 0, WALK_RIGHT, WALK_LEFT, WALK_UP, WALK_DOWN
}

public class PlayerMovement : MonoBehaviour
{  
    [SerializeField]
    private float m_moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 m_moveDirection = Vector3.zero;

    [SerializeField]
    private PlayerState m_playerState = PlayerState.IDLE;

    public Animator m_animator;

    public LayerMask m_solidObject;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        this.onKeyPress();
    }

    private void onKeyPress() {
        m_moveSpeed = 2.0f;

        if(Input.GetKeyDown(KeyCode.A)){
            m_moveDirection.x = -1;
            m_playerState = PlayerState.WALK_RIGHT;
        }

        else if(Input.GetKeyDown(KeyCode.D)){
            m_playerState = PlayerState.WALK_LEFT;
            m_moveDirection.x = 1;
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            m_playerState = PlayerState.WALK_UP;
            m_moveDirection.y = 1;
        }
        else if(Input.GetKeyDown(KeyCode.S)){
            m_playerState = PlayerState.WALK_DOWN;
            m_moveDirection.y = -1;
        }

        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)){
            m_playerState = PlayerState.IDLE;
            m_moveSpeed = 0.0f;
            m_moveDirection.x = 0;
            m_moveDirection.y = 0;
        }
        
        m_animator.SetFloat("Speed", Mathf.Abs(m_moveSpeed));
        m_animator.SetInteger("MoveDirection", ((int)m_playerState));
    }

    private void onAnimationUpdate(){

        switch(m_playerState){
            case PlayerState.IDLE:{
                break;
            }
            case PlayerState.WALK_RIGHT:
            case PlayerState.WALK_LEFT:
            case PlayerState.WALK_UP:
            case PlayerState.WALK_DOWN:{
                Vector3 pos = GetComponent<Transform>().position;
                pos += m_moveDirection.normalized * m_moveSpeed * Time.fixedDeltaTime;
                if(!isTouchSolidObject(pos)){
                    Debug.Log("Can move");
                    GetComponent<Transform>().position = pos;
                }
                else {
                    Debug.Log("Not Move");
                }
                break;
            }

        }

    }

    void FixedUpdate() {
        this.onAnimationUpdate();
    }

    private bool isTouchSolidObject(Vector3 target) => Physics2D.OverlapCircle(target, 0.2f, m_solidObject) != null;
}
