//Keeps track of the total value of a stack of waves in the same position.
//Offers the ability to add a single value or gather the entirety of the final result

//this is a simple stack: merely adds together every value incorporated.
public class WaveStack : ISignalStack
{
	private int total = 0;

	void ISignalStack.AddValue (int newValue)
	{
		total += newValue;
	}

	int ISignalStack.GetCombinedValue ()
	{
		return total;
	}
}
