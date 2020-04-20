using UnityEngine;

[System.Serializable]
public class SignalFragment// : MonoBehaviour
{
	public Wave[] waveList;

	public SignalFragment () {}
	public SignalFragment (Wave[] _waveList) {
		waveList = _waveList;
	} 
}
