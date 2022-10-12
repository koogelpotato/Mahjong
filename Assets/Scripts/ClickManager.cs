using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickManager : MonoBehaviour
{
    private Camera _camera;
    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    public static event Action ObjectClicked = delegate { };
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit)
            {
                IClickable clickable = hit.collider.GetComponent<IClickable>();
                clickable?.Click();
            }
        }
        
       
    }
    
}

