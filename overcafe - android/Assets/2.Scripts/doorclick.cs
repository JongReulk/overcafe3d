using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorclick : MonoBehaviour
{
    float door_y;
    Collider m_collider;
    int door_num;
    // Start is called before the first frame update
    void Start()
    {
        m_collider = GetComponent<Collider>();
        door_num = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if(GameManager.instance.isPaused)
        {
            return;
        }

        if (transform.eulerAngles.y == 270)
        {
            m_collider.enabled = false;
            StartCoroutine(DoorOpen());
        }

        if (transform.eulerAngles.y == 180)
        {
            m_collider.enabled = false;
            StartCoroutine(DoorClose());
        }
    }

    IEnumerator DoorOpen()
    {
        door_num += 1;
        door_y = transform.eulerAngles.y;
        
        while (door_y > 180)
        {
            door_y -= 9;
            transform.eulerAngles = new Vector3(-90, door_y, 0);
            yield return new WaitForSeconds(0.1f);
        }

        if(door_num == 7)
        {
            GameManager.instance.scoreResult += 50;
            soundManager.instance.isAchieved = true;
        }
        m_collider.enabled = true;
    }

    IEnumerator DoorClose()
    {
        door_num += 1;
        door_y = transform.eulerAngles.y;
        
        while (door_y < 270)
        {
            door_y += 9;
            transform.eulerAngles = new Vector3(-90, door_y, 0);
            yield return new WaitForSeconds(0.1f);
        }

        if (door_num == 7)
        {
            GameManager.instance.scoreResult += 50;
            soundManager.instance.isAchieved = true;
        }
        m_collider.enabled = true;
        
    }
}
