using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraCollider : MonoBehaviour
{
    public Camera MainCamera;
    Collider m_Collider;
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCamera.enabled)
        {
            m_Collider.enabled = false;
        }
        else
        {
            m_Collider.enabled = true;
        }
    }
}
