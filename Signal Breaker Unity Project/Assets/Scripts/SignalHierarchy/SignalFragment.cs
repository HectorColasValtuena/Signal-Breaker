//Contains a collection of ISignalContent object. They in turn can also implement ISignalContainer so as to act as intermediary storage.
//Objects implementing only ISignalContent are considered value containers

using System.Collections.Generic;
//using UnityEngine;

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
		return null;
	}
//ENDOF Implementación ISignalHandler
//Implementación ISignalContainer
	//Insert newEntry object.
	//If a position is given updates child offset. If absolutePosition = false, apply this container’s offset to child position.
	void ISignalContainer.AddChild (ISignalContent newEntry)
	{
		if (newEntry != null) { contents.Add(newEntry); }
		else { UnityEngine.Debug.LogWarning("Cannot SignalFragment.AddChildAt(null)"); }
	}
	void ISignalContainer.AddChildAt (ISignalContent newEntry, int position, bool absolutePosition)
	{
		if (newEntry != null)
		{
			newEntry.Offset = absolutePosition ? position : position - _offset;
			contents.Add(newEntry);
		}
		else { UnityEngine.Debug.LogWarning("Cannot SignalFragment.AddChildAt(null)"); }
	}

	//Get all immediate children. Optionally choose only children that have values in target position.
	//If recursive = true will recursively find grandchildren.
	List<ISignalContent> ISignalContainer.GetChildren (List<ISignalContent> collectorArray, bool recursive)
	{
		//ensure we have a collector array - create one otherwise
		if (collectorArray == null) { collectorArray = new List<ISignalContent>(); }
		//save our list of children onto the collector array
		collectorArray.AddRange(contents);
		//Recursively append children if requested
		if (recursive) {
			//access children as ISignalContainer and propagate request only to fitting children
			//[TO-DO] -TEST
			//[TEST-ME]
			foreach (ISignalContainer child in contents) {
				if (child != null) {
					child.GetChildren (collectorArray, recursive);
				}
			}
		}
		//finally return a reference to the collector array
		return collectorArray;
	}
	List<ISignalContent> ISignalContainer.GetChildrenTouching (int position, List<ISignalContent> collectorArray, bool recursive)
	{
		//[TO-DO]
		return null;
	}

	//Remove from this container a list of or every child
	//THIS DOES NOT DESTROY THE OBJECT - only the reference.
	void ISignalContainer.RemoveChildren (ISignalContent[] targets)
	{
		//[TO-DO]
	}
	void ISignalContainer.RemoveChildren ()
	{
		//[TO-DO]
	}
//ENDOF Implementación ISignalContainer
//Implementación ISignalContent
	int ISignalContent.Offset { get { return _offset; } set { _offset = value; } }
//ENDOF Implementación ISignalContent
}
