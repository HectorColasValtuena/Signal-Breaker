using UnityEngine;
using UnityEngine.EventSystems;

public class DropReceiverXperiment : MonoBehaviour, IDropHandler
{
	private const string draggableTag = "draggable";	//tag required on the dragged object to receive a drop

	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log(gameObject.name + ".OnDrop()\nDropped game object " + eventData.pointerDrag.name);		
		if (eventData.pointerDrag.tag == draggableTag)
		{
			DropReceived(eventData.pointerDrag);
		}
	}

	private void DropReceived (GameObject droplet)
	{
		Debug.Log(gameObject.name + " was dropped: " + droplet.name);
		droplet.transform.SetParent(transform);	
		droplet.transform.localPosition = Vector3.zero;
	}
}
