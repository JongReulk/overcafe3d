using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCameraFOV : MonoBehaviour
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
            camera.fieldOfView = 21f;
        }

        if (scaleFOV > 0.72)
        {
            Vector3 cameraP = new Vector3(-0.05f, 0f, 0f);
            camera.transform.position += cameraP;
            camera.fieldOfView = 23f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
