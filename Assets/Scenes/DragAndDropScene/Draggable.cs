using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
		
	[SerializeField] private Transform placeholderParent = null;
	GameObject placeholder = null;
	
	public void OnBeginDrag(PointerEventData eventData) {
				
		placeholder = new GameObject();
		placeholder.transform.SetParent(placeholderParent);
		LayoutElement le = placeholder.AddComponent<LayoutElement>();
		le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
		le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
		le.flexibleWidth = 0;
		le.flexibleHeight = 0;
		placeholder.transform.SetSiblingIndex( this.transform.GetSiblingIndex());
		HidePlaceholder();
		GetComponent<CanvasGroup>().blocksRaycasts = false;
	}	

	public void OnDrag(PointerEventData eventData) {
				
		this.transform.position = eventData.position;
		int newSiblingIndex = placeholderParent.childCount;

		for(int i=0; i < placeholderParent.childCount; i++) {
			if(this.transform.position.y > placeholderParent.GetChild(i).position.y) {

				newSiblingIndex = i;

				if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
					newSiblingIndex--;

				break;
			}
		}

		placeholder.transform.SetSiblingIndex(newSiblingIndex);
	}
	
	public void OnEndDrag(PointerEventData eventData) {
		
		this.transform.SetParent(placeholderParent);
		this.transform.SetSiblingIndex( placeholder.transform.GetSiblingIndex() );
		GetComponent<CanvasGroup>().blocksRaycasts = true;

		Destroy(placeholder);
	}

	public void HidePlaceholder()
	{
		placeholder.SetActive(false);
	}

	public void ShowPlaceholder()
	{
		placeholder.SetActive(true);
	}
}
