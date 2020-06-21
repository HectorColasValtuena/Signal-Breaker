namespace SignalHierarchy 
{
	public class Wave : ISignalContent, ISignalValue
	{
		//waveValue objeto conteniendo las propiedades de una onda
		private int _waveValue = 0;
		private int _offset = 0;


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

	//Implementación ISignalValue
		int ISignalValue.Value { get { return _waveValue; } }
	//ENDOF Implementación ISignalValue

	//Implementación ISignalContent
		int ISignalContent.Offset { get { return _offset; } set { _offset = value; } }
		//al hacer miVariable = Wave.Offset ejecutamos get
		//al hacer Wave.Offset = 5 ejecutamos set
	//ENDOF Implementación ISignalContent

	//Implementación ISignalHandler
		bool ISignalHandler.HasValuesAt (int position, uint loopLength, bool recursive)
		{
			//return true if this value's individual offset equals target position
			return SignalHelper.AbsoluteToRelativePosition(position, _offset, loopLength) == 0;
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
		}
	//ENDOF Implementación ISignalHandler
	}
}