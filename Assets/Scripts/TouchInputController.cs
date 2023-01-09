using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInputController : MonoBehaviour
{
    [SerializeField] private GameObject colitionSfere;
    void FixedUpdate()
    {
        if (Input.touchCount>0)
        {
            colitionSfere.SetActive(true);
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3( touch.position.x, touch.position.y, 10.0f ));
           touchPosition.y = 0f;
            colitionSfere.transform.position = touchPosition;
        }
        else
        {
            colitionSfere.SetActive(false);
        }
        
    }
    
}
