using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem3 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool lastP = false;
    Image image;
    CanvasGroup group;
    public Transform parentAfterDrag;
    public GameObject speedDescription;
    public GameObject equipOrUnequip;
    public GameObject capBiggerBranch3;

    public void Start()
    {
        image = GetComponent<Image>();
        group = GetComponent<CanvasGroup>();
        speedDescription.SetActive(false);
        equipOrUnequip.SetActive(false);
        capBiggerBranch3.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        group.alpha = .5f;
        image.raycastTarget = false;
        speedDescription.SetActive(true);
        equipOrUnequip.SetActive(true);
        capBiggerBranch3.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);

        group.alpha = 1f;
        image.raycastTarget = true;
        speedDescription.SetActive(false);
        equipOrUnequip.SetActive(false);
        capBiggerBranch3.SetActive(false);
        if (transform.parent.CompareTag("Equipped") && !lastP)
        {
            PlayerController.Instance.Speederer();
            lastP = true;
        }
        else if (transform.parent.CompareTag("Unequipped") && lastP)
        {
            PlayerController.Instance.Slowerer();
            lastP = false;
        }
    }

}
