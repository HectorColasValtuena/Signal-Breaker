using UnityEngine;
using UnityEngine.EventSystems;

public class DragXperiment : MonoBehaviour, IBeginDragHandler IDragHandler, IDropHandler
{
	public Transform ghostContainer;
	public GameObject ghostPrefab;

	private DragGhostHandler ghostInstance;

	public void Awake ()
	{
		if (ghostContainer == null)
		{
			ghostContainer = transform;
		}
	}


	public void OnDrag (PointerEventData eventData)
	{
		//Debug.Log("OnDrag(): " + eventData);
		transform.position = eventData.position;
	}

	public void OnDrop (PointerEventData eventData)
	{
		Debug.Log(gameObject.name + ".OnDrop()\nDropped game object " + eventData.pointerDrag.name);
		//Debug.Log(eventData);
	}

	public DragGhostHandler SpawnDragGhost (Vector3 initialPosition)
	{
		return Instantiate(ghostPrefab, initialPosition, Quaternion.identity, ghostContainer).GetComponent<DragGhostHandler>();
	}
}
