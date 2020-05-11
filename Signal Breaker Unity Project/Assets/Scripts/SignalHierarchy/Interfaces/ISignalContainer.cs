//Interfaz de objeto contenedor de señales. A implementar por contenedores intermedios así como instancias finales de información
//contiene un offset inicial y un listado de objetos Wave o ISignalContainer
//Implementa métodos para acceder una posición específica de la señal, recursivamente y abstrayendo su offset.
using System.Collections.Generic;

public interface ISignalContainer : ISignalHandler
{
	//Insert newEntry object.
	//If a position is given updates child offset. If absolutePosition = false, apply this container’s offset to child position.
	void AddChild (ISignalContent newEntry);
	void AddChildAt (ISignalContent newEntry, int position, bool absolutePosition = false);

	//Get all immediate children. Optionally choose only children that have values in target position.
	//Will append items at the end of collectorArray. Will create an empty list if none.
	//If recursive = true will recursively find grandchildren.
	List<ISignalContent> GetChildren (List<ISignalContent> collectorArray = null, bool recursive = true);
	//generic type TSignalHandler should be ISignalContent,ISignalContainer, ISignalHandler, or otherwise implement ISignalHandler
	//it determines wether children that implement ISignalContainer, ISignalContent, or either are returned
	List<TSignalHandler> GetChildrenTouching<TSignalHandler> (int position, List<TSignalHandler> collectorArray = null, uint loopLength = 0, bool recursive = true);

	//List<ISignalContent> GetChildrenTouching (int position, List<ISignalContent> collectorArray = null, uint loopLength = 0, bool recursive = true);
	//List<ISignalContainer> GetChildrenTouching (int position, List<ISignalContainer> collectorArray = null, uint loopLength = 0, bool recursive = true);
	

	//Remove from this container a list of or every child
	//THIS DOES NOT DESTROY THE OBJECT - only the reference.
	void RemoveChildren (List<ISignalContent> targets);
	void RemoveChildren ();
	void RemoveChild (ISignalContent target);
}
