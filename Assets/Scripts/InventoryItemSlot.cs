using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop2(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<DraggableItem2>().parentAfterDrag = transform;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
       /* if (transform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<DraggableItem>().parentAfterDrag = transform;
        }*/
    }
    
    public void OnDrop3(PointerEventData eventData)
    {/*
        if (transform.childCount == 0)
        {
            eventData.pointerDrag.GetComponent<DraggableItem3>().parentAfterDrag = transform;
        }*/
    }
}

