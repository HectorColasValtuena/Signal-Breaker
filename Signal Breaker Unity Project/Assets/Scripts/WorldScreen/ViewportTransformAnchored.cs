using UnityEngine;

namespace WorldScreen {

	public class ViewportTransformAnchored : MonoBehaviour, IViewport
	{
		public Transform lowerLimitTransform;
		public Transform upperLimitTransform;

		private Vector2 _viewportSize;

		// Start is called before the first frame update
		void Start()
		{
			if (lowerLimitTransform == null || upperLimitTransform == null) 
			{
				Debug.LogError("ViewportTransformAnchored initiated without limiter transform references setup. Aborting.");
				_viewportSize = Vector2.zero;
				return;
			}
			_viewportSize = new Vector2 (
				upperLimitTransform.position.x - lowerLimitTransform.position.x,
				upperLimitTransform.position.y - lowerLimitTransform.position.y
			);
			transform.position = lowerLimitTransform.position;
		}

	//Implementación IViewport
		Vector2 IViewport.viewportSize { get { return _viewportSize; } }
		Transform IViewport.rootTransform { get { return transform; } }

		bool IViewport.IsWithin (Vector2 point)
		{
			return (
				( point.x <= _viewportSize.x && point.x >= 0 ) &&
				( point.y <= _viewportSize.y && point.y >= 0 )
			);
		}

		//public Vector3 IViewport.ViewportToWorldPoint (Vector2 ViewportPoint) {}

	//ENDOF Implementación IViewport
	}
}