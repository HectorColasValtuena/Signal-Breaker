using System.Collections.Generic;
using SignalHierarchy;
using WorldScreen;
using UnityEngine;

public class SignalFragmentRackTest : MonoBehaviour
{
	public SignalFragmentRackHandler signalFragmentRack;
	public SignalFragment value = new SignalFragment(-3, new List<ISignalContent> {
                        new Wave(2, 30),
                        new Wave(4, -10),
                        new Wave(5, -10),
                        new Wave(5, -10),
                        new Wave(6, 30)
                    });

	// Start is called before the first frame update
	void Start()
	{
		signalFragmentRack.SetParametersAndRedraw(value);
		//waveDrawer.SetParametersAndRedraw(new Wave(value) as ISignalValue);
	}
}
