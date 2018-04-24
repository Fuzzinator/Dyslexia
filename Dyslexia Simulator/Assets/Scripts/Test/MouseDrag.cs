using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    public float distance = 15;

    private bool _canGrab = true;

    private void OnMouseDown()
    {
        Actions.breakConnection += breakConnectionHandler;
    }

    private void OnMouseUp()
    {
        Actions.breakConnection -= breakConnectionHandler;
    }

    private void OnMouseDrag()
    {
        if (_canGrab)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.position = objPos;
        }
    }

    private void FixedUpdate()
    {
        if (_canGrab)
        {
            if (Camera.main.transform.localEulerAngles.x < 13)
            {
                distance = 35;
            }
            else
            {
                distance = 15;
            }
        }
    }

    

    private void breakConnectionHandler()
    {
        _canGrab = false;
    }
}
