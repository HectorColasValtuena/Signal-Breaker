[System.Serializable]
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

	ISignalStack ISignalHandler.GetValuesAt (int position, ISignalStack collectorStack, bool recursive)
	{
		if (collectorStack == null)	//create an empty collectorStack if not available
		{
			//[TO-DO]
			//collectorStack = new !!ISignalStack();
		}

		if (position == _offset) {
			collectorStack.AddValue(waveValue);
		}

		return collectorStack;
	}
//ENDOF Implementación ISignalContent
}