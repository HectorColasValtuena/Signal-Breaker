using UnityEngine;

namespace WorldScreen 
{
	public class ViewportCanvasAnchored : MonoBehaviour, IWSViewport
	{
		RectTransform rectTransform;

		void Start()
		{
			rectTransform = GetComponent<RectTransform>();

			//* [DEBUG]
			Debug.Log("Canvas viewport size: " + (this as IWSViewport).viewportSize);

			Debug.Log("IsWithin(100,100): " + (this as IWSViewport).IsWithin(new Vector2 (100, 100)));
			Debug.Log("IsWithin(200,200): " + (this as IWSViewport).IsWithin(new Vector2 (200, 200)));
			//*
		}


	//Implementación IViewport
		Vector2 IWSViewport.viewportSize { get { return rectTransform.rect.size; } }
		Transform IWSViewport.rootTransform { get { return transform; } }

		bool IWSViewport.IsWithin (Vector2 point)
		{
			return (
				( point.x <= rectTransform.rect.size.x && point.x >= 0 ) &&
				( point.y <= rectTransform.rect.size.y && point.y >= 0 )
			);
		}

		//public Vector3 IViewport.ViewportToWorldPoint (Vector2 ViewportPoint) {}

	//ENDOF Implementación IViewport
	}
}