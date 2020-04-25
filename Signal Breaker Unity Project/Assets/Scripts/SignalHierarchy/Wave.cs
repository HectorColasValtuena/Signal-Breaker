//[System.Serializable]
public class Wave : ISignalContent
{
	//WaveValue objeto conteniendo las propiedades de una onda
	private int waveValue;
	private int _offset;


//Constructor
	public Wave (int __waveValue)
	{
		waveValue = __waveValue;
	}

	public Wave (int __waveValue, int __offset) : this (__waveValue)
	{
		_offset = __offset;
	}
//ENDOF Constructor

//Implementación ISignalContent
	int ISignalContent.Offset { get { return _offset; } set { _offset = value; } }
//ENDOF Implementación ISignalContent
//Implementación ISignalHandler
	ISignalStack ISignalHandler.GetValuesAt (int position, ISignalStack collectorStack, bool recursive)
	{
		//Single-line implementation
		//((collectorStack == null) ? collectorStack = new WaveStack() : collectorStack).AddValue(waveValue);
		//no good, doesn't check for this item's position

		//create an empty collectorStack if not available
		if (collectorStack == null)	{ collectorStack = new WaveStack(); }

		//add this object's value to the stack if the requested position coincides with this wave's position
		if (position == _offset) { collectorStack.AddValue(waveValue); }
		
		return collectorStack;
	}
//ENDOF Implementación ISignalHandler
}