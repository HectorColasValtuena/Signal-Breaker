using UnityEngine;

public class TestClickable : MonoBehaviour, WorldScreen.IWSClickable
{
	void WorldScreen.IWSClickable.Clicked ()
	{
		Debug.Log("TestClickable.Clicked(); executed.");
	}
}
