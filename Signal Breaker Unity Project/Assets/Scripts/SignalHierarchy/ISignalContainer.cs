//Interfaz de objeto contenedor de señales. A implementar por contenedores intermedios así como instancias finales de información
//contiene un offset inicial y un listado de objetos Wave o ISignalContainer
//Implementa métodos para acceder una posición específica de la señal, recursivamente y abstrayendo su offset.
public interface ISignalContainer
{
	//int Offset { get; set; }

	//Recursively access contents and return wave information at position, applying offset if absolute = false.
	//Will return null if no wave info for target position.
	WaveValue GetValueAt (int position, bool absolute = false);

	//Insert newEntry object. if absolute = false applies offset value to target position
	void AddChild (ISignalContainer newEntry, bool absolute = false);
	void AddChildAt (ISignalContainer newEntry, int position, bool absolute = false);

	//Get all immediate children. If recursive = true will recursively find every children's children.
	ISignalContainer GetChildren (bool recursive = false);

	//Remove from this container one or every child
	//THIS DOES NOT DESTROY THE OBJECT - only the reference.
	void RemoveChild (ISignalContainer target);
	void RemoveChildren ();
}
