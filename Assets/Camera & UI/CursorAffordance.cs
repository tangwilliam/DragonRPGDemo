using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorAffordance : MonoBehaviour {

    CameraRaycast cameraRaycast;

    [SerializeField]
    Texture2D m_WalkableTex;
    [SerializeField]
    Texture2D m_FightTex;
    [SerializeField]
    Texture2D m_UnknownTex;


    Vector2 m_HotSpot = Vector2.zero;


	// Use this for initialization
	void Start () {

        cameraRaycast = GetComponent<CameraRaycast>();

        cameraRaycast.layerChange += OnLayerChange;

        Cursor.SetCursor(m_WalkableTex, m_HotSpot, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnLayerChange( Layer layer ){

        print("Cursor : current Layer = " + layer);

        switch( layer ){
            
            case Layer.Walkable:
                Cursor.SetCursor(m_WalkableTex, m_HotSpot, CursorMode.Auto);break;
            case Layer.Enemy:
                Cursor.SetCursor(m_FightTex, m_HotSpot, CursorMode.Auto);break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(m_UnknownTex, m_HotSpot, CursorMode.Auto);break;
            default:break;
        }
    }

}
