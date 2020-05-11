namespace SignalHierarchy 
{
	//Interfaz de contenedor de almacenaje.
	//Las clases contenido y los contenedores intermedios deberán implementarlos para que el ISignalContainer pueda comunicarse con éste.
	public interface ISignalContent : ISignalHandler
	{
		//Offset posicional de este contenido respecto a su contenedor.
		//Será la posición del valor si es un objeto de valor, o un offset heredado por todos los hijos si es un organizador intermedio.
		int Offset { get; set; }
	}
}