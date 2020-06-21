namespace SignalHierarchy
{
	//Objecto representando una unidad mínima de información horizontal.
	//puede almacenar y representar el valor de una posición dentro de la señal.
	public interface ISignalValue
	{
		//valor intensidad de la onda. 
		int Value { get; }
	}
}