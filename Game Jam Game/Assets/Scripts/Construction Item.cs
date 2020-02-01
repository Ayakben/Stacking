using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConstructionItem : MonoBehaviour, IPointerClickHandler
{
    public bool selected;
    public void OnPointerClick(PointerEventData eventData)
    {
        selected = true;
    }
    public void Update()
    {
        if (selected)
        {
            transform.position = Input.mousePosition;
        }
    }

}
