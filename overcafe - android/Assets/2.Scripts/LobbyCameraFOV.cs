using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCameraFOV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();

        float scaleFOV = ((float)Screen.height / Screen.width);
        float defaultFOV = camera.fieldOfView;
        Debug.Log("FOV" + scaleFOV);



        if (scaleFOV > 0.59)
        {
            camera.fieldOfView = 63f;
        }

        if (scaleFOV > 0.72)
        {
            camera.fieldOfView = 73f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
