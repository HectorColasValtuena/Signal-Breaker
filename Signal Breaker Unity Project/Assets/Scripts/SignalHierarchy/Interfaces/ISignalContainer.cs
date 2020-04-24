//Interfaz de objeto contenedor de señales. A implementar por contenedores intermedios así como instancias finales de información
//contiene un offset inicial y un listado de objetos Wave o ISignalContainer
//Implementa métodos para acceder una posición específica de la señal, recursivamente y abstrayendo su offset.
public interface ISignalContainer : ISignalHandler
{
	//Insert newEntry object.
	//If a position is given updates child offset applying this container's offset value
	void AddChild (ISignalContent newEntry);
	void AddChildAt (ISignalContent newEntry, int position);

	//Get all immediate children. Optionally choose only children that have values in target position.
	//If recursive = true will recursively find grandchildren.
	ISignalContent[] GetChildren (bool recursive = true);
	ISignalContent[] GetChildrenTouching (int position, bool recursive = true);

	//Remove from this container a list of or every child
	//THIS DOES NOT DESTROY THE OBJECT - only the reference.
	void RemoveChildren (ISignalContent[] targets);
	void RemoveChildren ();
}
