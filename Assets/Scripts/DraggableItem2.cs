using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem2 : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private bool lastP = false;
    Image image;
    CanvasGroup group;
    public Transform parentAfterDrag;
    public GameObject fireBlastDescription;
    public GameObject equipOrUnequip;
    public GameObject capBiggerBranch2;

    public void Start()
    {
        image = GetComponent<Image>();
        group = GetComponent<CanvasGroup>();
        fireBlastDescription.SetActive(false);
        equipOrUnequip.SetActive(false);
        capBiggerBranch2.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        group.alpha = .5f;
        image.raycastTarget = false;
        fireBlastDescription.SetActive(true);
        equipOrUnequip.SetActive(true);
        capBiggerBranch2.SetActive(true);
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
        fireBlastDescription.SetActive(false);
        equipOrUnequip.SetActive(false);
        capBiggerBranch2.SetActive(false);
        if (transform.parent.CompareTag("Equipped") && !lastP)
        {
            BlastWave.Instance.Change();
            lastP = true;
        }
        else if (transform.parent.CompareTag("Unequipped") && lastP)
        {
            BlastWave.Instance.Return();
            lastP = false;
        }
    }

}

