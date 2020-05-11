//[System.Serializable]
public class Wave : ISignalContent
{
	//waveValue objeto conteniendo las propiedades de una onda
	private int _waveValue;
	private int _offset;


//Constructor
	public Wave (int __waveValue)
	{
		_waveValue = __waveValue;
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
	bool ISignalHandler.HasValuesAt (int position, uint loopLength, bool recursive)
	{
		//return true if this value's individual offset equals target position
		return SignalHelper.AbsoluteToRelativePosition(position, _offset, loopLength) == 0;

		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//[TO-DO] [TEST-ME]
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	}

	ISignalStack ISignalHandler.GetValuesAt (int position, ISignalStack collectorStack, uint loopLength, bool recursive)
	{
		//create an empty collectorStack if not available
		if (collectorStack == null)	{ collectorStack = new WaveStack(); } //[TO-DO] !! Is there some way to define default collector class elsewhere/pass it through parameters?
																		 //			!! Perhaps some way to remove this conditional?

		//if this wave corresponds to target position, add its value to the stack
		if ((this as ISignalHandler).HasValuesAt (position, loopLength))
		{
			collectorStack.AddValue(_waveValue);
		}

		//return a reference to used collection stack
		return collectorStack;

		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//[TO-DO] [TEST-ME]
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
	}
//ENDOF Implementación ISignalHandler
}