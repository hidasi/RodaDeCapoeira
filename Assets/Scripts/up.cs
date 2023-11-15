using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class up : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ButtonControllerup bc3;

    public void OnPointerDown(PointerEventData eventData)
    {
        bc3.up = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bc3.up = false;
    }

}