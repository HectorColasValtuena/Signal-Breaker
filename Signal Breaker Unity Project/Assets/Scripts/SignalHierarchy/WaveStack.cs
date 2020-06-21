namespace SignalHierarchy 
{
	//Keeps track of the total value of a stack of waves in the same position.
	//Offers the ability to add a single value or gather the entirety of the final result

	//this is a simple stack: merely adds together every value incorporated.
	public class WaveStack : ISignalStack
	{
		private int total = 0;

		int ISignalValue.Value { get { return total; } }
		
		void ISignalStack.AddValue (int newValue)
		{
			total += newValue;
		}

	}
}