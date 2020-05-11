namespace SignalHierarchy 
{
	//padre de todas las clases manejadoras de almacenaje.
	//Expone el método usado para reclamar valores en una posición específica.
	//Recomendable implementar e invocar explícitamente como ISignalHandler.GetValuesAt
	public interface ISignalHandler
	{
		//Determina si este contenedor contiene algún valor en la posición objetivo. ignora los contenedores hijos si recursive = false.
		//Si loopLength > 0, la búsqueda incluye todos los valores en posiciones múltiplo de loopLength.
		bool HasValuesAt (int position, uint loopLength = 0, bool recursive = true);

		//Busca (recursivamente?) entre todos sus hijos, acumulando un listado de todos los contenidos encontrados en la posición correspondiente.
		//Si se le pasa un array collectionStack añade los valores a este, crea uno nuevo de lo contrario.
		//Si loopLength > 0, la búsqueda incluye todos los valores en posiciones múltiplo de loopLength
		//Devuelve un puntero al objeto collectorStack utilizado.
		ISignalStack GetValuesAt (int position, ISignalStack collectorStack = null, uint loopLength = 0, bool recursive = true);
	}
}