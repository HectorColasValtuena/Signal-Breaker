namespace WorldScreen
{
	public interface IWSViewport
	{
		//returns maximum size of the viewport as well as upper right limit. Lower left limit is 0,0.
		UnityEngine.Vector2 viewportSize { get; }
		//base transform to be made parent of every item that goes into the screenspace
		UnityEngine.Transform rootTransform { get; }

		//returns true if point is within the emulated viewport like so: 0,0 <= point <= ViewportSize 
		bool IsWithin (UnityEngine.Vector2 point);
		//transforms a 2d position within the viewport into the corresponding 3d worldspace position
		//UnityEngine.Vector3 ViewportToWorldPoint (UnityEngine.Vector2 ViewportPoint);
	}
}