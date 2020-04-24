﻿//Contains a collection of ISignalContent object. They in turn can also implement ISignalContainer so as to act as intermediary storage.
//Objects implementing only ISignalContent are considered value containers

using System.Collections.Generic;

//[System.Serializable]
public class SignalFragment : ISignalContainer, ISignalContent
{
	private int _offset;
	private List<ISignalContent> contents;

//Constructor
	public SignalFragment () : this (0, null) {}
	public SignalFragment (int __offset) : this (__offset, null) {}
	public SignalFragment (List<ISignalContent> __contents) : this (0, __contents) {}
	public SignalFragment (int __offset, List<ISignalContent> __contents)
	{
		_offset = __offset;
		contents = (__contents != null) ? __contents : new List<ISignalContent>();
	}
//ENDOF Constructor

//Implementación ISignalHandler
	ISignalStack ISignalHandler.GetValuesAt (int position, ISignalStack collectorStack, bool recursive)
	{
		//[TO-DO]
	}
//ENDOF Implementación ISignalHandler
//Implementación ISignalContainer
	//Insert newEntry object.
	//If a position is given updates child offset applying this container's offset value
	void AddChild (ISignalContent newEntry)
	{
		//[TO-DO]
	}
	void AddChildAt (ISignalContent newEntry, int position)
	{
		//[TO-DO]
	}

	//Get all immediate children. Optionally choose only children that have values in target position.
	//If recursive = true will recursively find grandchildren.
	ISignalContent[] GetChildren (bool recursive = true)
	{
		//[TO-DO]
	}
	ISignalContent[] GetChildrenTouching (int position, bool recursive = true)
	{
		//[TO-DO]
	}

	//Remove from this container a list of or every child
	//THIS DOES NOT DESTROY THE OBJECT - only the reference.
	void RemoveChildren (ISignalContent[] targets)
	{
		//[TO-DO]
	}
	void RemoveChildren ()
	{
		//[TO-DO]
	}
//ENDOF Implementación ISignalContainer
//Implementación ISignalContent
	int ISignalContent.Offset { get { return _offset; } set { _offset = value; } }
//ENDOF Implementación ISignalContent
}
