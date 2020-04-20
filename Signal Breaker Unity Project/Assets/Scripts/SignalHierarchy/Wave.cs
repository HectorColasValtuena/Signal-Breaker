//using UnityEngine;

[System.Serializable]
public class Wave //: ISignalContainer
{
	public WaveValue value;

//Constructor
	public Wave (int __value, int __sign)
	{
		value = new WaveValue(__value, __sign);
	}
//ENDOF Constructor

//Implementación ISignalContainer
	//offset
	private int _offset;
	public int Offset {
		get { return _offset; }
		set { _offset = value; }
	}
	
//ENDOF Implementación ISignalContainer
}