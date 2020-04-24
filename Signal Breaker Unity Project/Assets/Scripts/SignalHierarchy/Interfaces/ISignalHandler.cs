//padre de todas las clases manejadoras de almacenaje.
//Expone el método usado para reclamar valores en una posición específica.
//Recomendable implementar e invocar explícitamente como ISignalHandler.GetValuesAt
public interface ISignalHandler
{
	//fetch values at position. Saves them into collectorStack if provided, or a new ISignalStack object.
	//Returns a pointer to received/newly created ISignalStack object.
	ISignalStack GetValuesAt (int position, ISignalStack collectorStack = null, bool recursive = true);
}
