using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReadyTour : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private UnityEvent _tourAssembled;

    public void TourAssembled()
    {
        _tourAssembled?.Invoke();
    }

	public void OnPointerEnter(PointerEventData eventData)
	{		
		if (eventData.pointerDrag == null)
			return;

		ElementDrag currentElementDrag = eventData.pointerDrag.GetComponent<ElementDrag>();
		if (currentElementDrag != null)
		{
			Debug.Log("Элемент над полем");
		}
	}
}
