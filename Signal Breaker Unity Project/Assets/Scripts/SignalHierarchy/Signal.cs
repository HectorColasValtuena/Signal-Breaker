using UnityEngine;

public class Signal : MonoBehaviour
{
	public SignalFragment[] fragmentList;
	public Sample[] sampleList;

	public void Start () {
		DebugLogging();
	}

	public void DebugLogging ()
	{
	//*
		fragmentList = new SignalFragment[] {
			null,
			null,
			new SignalFragment(),
			new SignalFragment(),
			null
		};
	/**/
		Debug.Log(fragmentList);

		for (int i = 0, iLimit = fragmentList.Length; i < iLimit; i++) {
			Debug.Log(fragmentList[i]);
		}
	}
}
