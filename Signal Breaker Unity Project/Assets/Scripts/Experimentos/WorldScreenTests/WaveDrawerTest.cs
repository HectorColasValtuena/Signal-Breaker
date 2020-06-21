using SignalHierarchy;
using WordlScreen;
using UnityEngine;

public class WaveDrawerTest : MonoBehaviour
{
	public WaveDrawer waveDrawer;
	public int value;

	// Start is called before the first frame update
	void Start()
	{
		waveDrawer.setParametersAndRedraw(new Wave(value) as ISignalValue);
	}
}
