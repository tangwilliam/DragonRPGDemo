using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{

    [SerializeField]
    private Layer[] m_Layers = {

        Layer.Enemy,
        Layer.Walkable
    };


    public float distanceToBackground = 100.0f;

    RaycastHit m_Hit;
    public RaycastHit hit{ get{

            return m_Hit;
        }}

    Layer m_LayerHit;
    public Layer layerHit{
        get { return m_LayerHit; }
    }

    // Delegate and Event
    public delegate void LayerChangeHandler(Layer layer);
    public event LayerChangeHandler layerChange;

    private Camera m_ViewCamera;

	// Use this for initialization
	void Start () {

        m_ViewCamera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {

        Layer layerThisHit = Layer.RaycastEndStop;

        foreach( Layer layer in m_Layers ){
            
            var thisHit = RaycastLayer(layer) ;
            if( thisHit.HasValue ){
                m_Hit = (RaycastHit)thisHit;
                layerThisHit = layer;
                break;
            }
        }

        if( layerThisHit == Layer.RaycastEndStop ){
            m_Hit.distance = distanceToBackground;
        }
       

        if( m_LayerHit != layerThisHit ){
            // Broadcast Event
            layerChange( layerThisHit );
            m_LayerHit = layerThisHit;
        }
	}


    RaycastHit? RaycastLayer( Layer layer ){
        
        RaycastHit aHit;

        Ray ray = m_ViewCamera.ScreenPointToRay(Input.mousePosition);

        int layerMask = 1 << (int)layer;

        if( Physics.Raycast( ray, out aHit, distanceToBackground,  layerMask )){
            return aHit;
        }else{
            return null;
        }
    }

}
