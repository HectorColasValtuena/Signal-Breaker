using UnityEngine;
using UnityEngine.EventSystems;

public class DragXperiment : MonoBehaviour, IDragHandler
{
	public void OnDrag (PointerEventData eventData)
	{
		Debug.Log("OnDrag(): " + eventData);
		transform.position = eventData.position;
	}
}
