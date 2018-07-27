using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour {

    ThirdPersonCharacter m_Character;
    CameraRaycast m_CameraRaycast;
    Vector3 m_CurrentMoveTarget;

    public float moveToTargetThresholdDistance = 0.2f;

    bool m_DirectMoveMode = false;
    bool m_PlayerShouldMove = false;

	// Use this for initialization
	void Start () {

        m_Character = GetComponent<ThirdPersonCharacter>();
        m_CameraRaycast = Camera.main.gameObject.GetComponent<CameraRaycast>();
        m_CurrentMoveTarget = transform.position;
	}
	

	// Update is called once per frame
    void FixedUpdate () {

        if( Input.GetKeyDown(KeyCode.G) ){

            m_DirectMoveMode = !m_DirectMoveMode;
            m_CurrentMoveTarget = transform.position;
        }

        if( m_DirectMoveMode ){

            ProcessKeyboardMove();
        }else{
            ProcessMouseClickMove();
        }

	}

    void ProcessKeyboardMove(){

        // Placehold
    }

    void ProcessMouseClickMove(){

        if (Input.GetMouseButtonDown(0))
        {
            switch (m_CameraRaycast.LayerHit)
            {

                case Layer.Walkable:
                    {

                        m_CurrentMoveTarget = m_CameraRaycast.Hit.point;
                        m_PlayerShouldMove = true;
                    }
                    break;

                case Layer.Enemy:
                    {
                        print("Player Movement: Can not Move to enemy's position");
                    }
                    break;

                case Layer.RaycastEndStop:
                    {
                        print("Player Movement: Can not go there");
                    }
                    break;
                default: break;
            }
        }



        Vector3 toTarget = m_CurrentMoveTarget - transform.position;
        if (toTarget.magnitude > moveToTargetThresholdDistance && m_PlayerShouldMove )
        {
            m_Character.Move(toTarget, false, false);
        }
        else
        {
            m_Character.Move(Vector3.zero, false, false);
            m_PlayerShouldMove = false;
        }

       
    }
}
