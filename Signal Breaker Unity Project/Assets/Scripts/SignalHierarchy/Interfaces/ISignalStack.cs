namespace SignalHierarchy 
{
	//An object implementing this interface keeps track of either a list of values or a running total.
	//Offers the ability to add a single value or gather the entirety of the final result
	public interface ISignalStack
	{
		void AddValue (int newValue);
		int GetCombinedValue ();
	}
}