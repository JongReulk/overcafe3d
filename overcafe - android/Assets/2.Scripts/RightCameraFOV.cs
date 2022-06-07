using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCameraFOV : MonoBehaviour
{
    public RectTransform ordersParent;
    public RectTransform Timer;
    public RectTransform LeftCursor;
    public RectTransform Volume;
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();

        float scaleFOV = ((float)Screen.height / Screen.width);
        float defaultFOV = camera.fieldOfView;
        Debug.Log("FOV" + scaleFOV);

        if (scaleFOV < 0.55)
        {
            camera.fieldOfView = 31f;
        }

        //Debug.Log("camera : " + scaleFOV);
        if (scaleFOV < 0.5)
        {
            camera.fieldOfView = 29f;
            Vector3 cameraP = new Vector3(0.1f, 0.1f, -0.1f);
            camera.transform.position += cameraP;

            if (ordersParent != null)
            {
                ordersParent.anchoredPosition = new Vector2(24f, 0f);
            }

            if (Timer != null)
            {
                Timer.anchoredPosition = new Vector2(10f, 0f);
            }

            if (LeftCursor != null)
            {
                LeftCursor.anchoredPosition = new Vector2(40f, -60f);
            }

            if (Volume != null)
            {
                Volume.anchoredPosition = new Vector2(40f, 0f);
            }

        }

        if (scaleFOV > 0.59)
        {
            camera.fieldOfView = 34f;
            Vector3 cameraP = new Vector3(0.37f, 0f, 0.37f);
            camera.transform.position += cameraP;
            print("transform" + camera.transform.position);
        }

        if (scaleFOV > 0.72)
        {
            camera.fieldOfView = 38f;
            //Vector3 cameraP = new Vector3(0.37f, 0f, 0.37f);
            //camera.transform.position += cameraP;

        }




    }

    // Update is called once per frame
    void Update()
    {

    }
}
