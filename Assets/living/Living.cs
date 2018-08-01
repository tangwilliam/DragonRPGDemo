using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Living : MonoBehaviour {

    [SerializeField]
    float maxHealth = 100.0f;
    float m_currentHeath = 100.0f;

    // Use this for initialization
    void Start()
    {

        m_currentHeath = maxHealth;
    }

    public float healthAsPercentage
    {
        get
        {
            if (maxHealth > 0)
                return m_currentHeath / maxHealth;
            else
                print("Error: Player Health max value is negative");
            return 0.0f;
        }
    }
}
