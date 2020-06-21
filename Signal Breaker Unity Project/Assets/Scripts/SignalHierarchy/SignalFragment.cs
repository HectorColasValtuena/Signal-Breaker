//Contains a collection of ISignalContent object. They in turn can also implement ISignalContainer so as to act as intermediary storage.
//Objects implementing only ISignalContent are considered value containers

using System.Collections.Generic;

namespace SignalHierarchy 
{
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
		bool ISignalHandler.HasValuesAt (int position, uint loopLength, bool recursive)
		{
			position = SignalHelper.AbsoluteToRelativePosition(position, _offset, loopLength);


			foreach (ISignalContent child in contents)
			{
				//propagate the call to every children if recursive = true,
				//only to children who are not containers if recursive = false
				if ((recursive || (child as ISignalContainer) == null) && child.HasValuesAt(position, loopLength, recursive))
				{
					return true;
				}
			}

			return false;
		}

		ISignalStack ISignalHandler.GetValuesAt (int position, ISignalStack collectorStack, uint loopLength, bool recursive)
		{
			//propagate a request for all available values at position down to all children then return the collector stack

			//create an empty collectorStack if not available
			if (collectorStack == null)	{ collectorStack = new WaveStack(); }

			//adjust position to this object's offset 
			position = SignalHelper.AbsoluteToRelativePosition(position, _offset, loopLength);

			//propagate the call down to every children
			foreach (ISignalContent child in contents) 
			{
				//propagate the call only if the object is NOT a container or if recursive is true
				if (recursive || !(child is ISignalContainer))
				{
					child.GetValuesAt(position, collectorStack, loopLength, recursive);
				}
			}

			return collectorStack;
		}
	//ENDOF Implementación ISignalHandler

	//Implementación ISignalContainer
		//Adjust offset and Re-organize contents so that the earliest element sits at position 0 and every element keeps its absolute position. Acts recursively
		//Returns this element’s new offset
		void ISignalContainer.AutoRebaseOffsets ()
		{
			//loop once through the list of children trying to determine target offset
			int lowestOffset = int.MaxValue;
			foreach (ISignalContent child in contents)
			{
				ISignalContainer childAsContainer = child as ISignalContainer;
				//propagate the AutoRebaseOffsets call to container elements, so they also have a 0-index offset
				if (childAsContainer != null)
				{
					childAsContainer.AutoRebaseOffsets();
				}

				//keep the lowest offset out of every contained element to determine zero-index offset
				if (child.Offset < lowestOffset) {
					lowestOffset = child.Offset;
				}
			}

			//skip restructuring offsets if they area already 0-aligned
			if (lowestOffset == 0) { return; }

			//now that we know the position of the earliest element, adjust this container's and every content's offset
			//so lowest element sits a position 0
			_offset += lowestOffset;

			foreach (ISignalContent child in contents)
			{
				child.Offset -= lowestOffset;	
			}
		}

		//Insert newEntry object.
		//If a position is given updates child offset. If absolutePosition = false, apply this container’s offset to child position.
		void ISignalContainer.AddChild (ISignalContent newEntry)
		{
			if (newEntry != null) { contents.Add(newEntry); }
			//else { UnityEngine.Debug.LogWarning("Cannot SignalFragment.AddChildAt(null)"); }
		}
		void ISignalContainer.AddChildAt (ISignalContent newEntry, int position, bool absolutePosition)
		{
			if (newEntry != null)
			{
				newEntry.Offset = absolutePosition ? position : SignalHelper.AbsoluteToRelativePosition(position, _offset);
				contents.Add(newEntry);
			}
			//else { UnityEngine.Debug.LogWarning("Cannot SignalFragment.AddChildAt(null)"); }
		}

		//Get all immediate children.
		//If recursive = true will recursively find grandchildren.
		List<ISignalContent> ISignalContainer.GetChildren (List<ISignalContent> collectorArray, bool recursive)
		{
			//ensure we have a collector array - create one otherwise
			if (collectorArray == null) { collectorArray = new List<ISignalContent>(); }

			//save our list of children onto the collector array
			collectorArray.AddRange(contents);

			//Recursively append children if requested
			if (recursive)
			{
				//access children as ISignalContainer and propagate request only to fitting children
				foreach (ISignalContent child in contents)
				{
					ISignalContainer containerChild = child as ISignalContainer;
					if (containerChild != null)
					{
						containerChild.GetChildren(collectorArray, recursive);
					}
				}
			}
			//finally return a reference to the collector array
			return collectorArray;
		}

		//return every children with values at target position.
		//if recursive = false will only include immediate children but values will be searched down to every depth
		List<ISignalContent> ISignalContainer.GetChildrenTouching (int position, List<ISignalContent> collectorArray, uint loopLength, bool recursive)
		{
			position = SignalHelper.AbsoluteToRelativePosition(position, _offset, loopLength);

			//ensure collectorArray exists
			if (collectorArray == null) { collectorArray = new List<ISignalContent>(); }

			//save immediate children with values in target position
			//also propagate the call if recursive = true
			foreach (ISignalContent child in contents)
			{
				ISignalHandler childHandler = child as ISignalHandler;
				if (child != null && childHandler != null && childHandler.HasValuesAt(position, loopLength, true))
				{
					collectorArray.Add(child);

					if (recursive && (child as ISignalContainer) != null)
					{
						(child as ISignalContainer).GetChildrenTouching(position, collectorArray, loopLength, true);
					}
				}
			}

			return collectorArray;
		}

		//Remove from this container a single, a list of, or every child
		//THIS DOES NOT DESTROY THE OBJECT - only the reference.
		void ISignalContainer.RemoveChild (ISignalContent target)
		{
			while (contents.Remove(target)); //execute remove in a loop to ensure every single instance of target is removed
		}
		void ISignalContainer.RemoveChildren (List<ISignalContent> targets)
		{
			//remove every instance of content contained in targets
			contents.RemoveAll((ISignalContent candidate) => { return targets.Contains(candidate); });
		}
		void ISignalContainer.RemoveChildren ()
		{
			contents = new List<ISignalContent>();
		}
	//ENDOF Implementación ISignalContainer

	//Implementación ISignalContent
		int ISignalContent.Offset { get { return _offset; } set { _offset = value; } }
	//ENDOF Implementación ISignalContent
	}
}