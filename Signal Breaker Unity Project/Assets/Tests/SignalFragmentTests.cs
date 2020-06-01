using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using SignalHierarchy;

namespace SignalHierarchyTests
{
    public class SignalFragmentTests
    {
    //Constructor
        //> Constructor SignalFragment ()
        [Test]
        public void UTSignalFragmentConstructor1 ()
        {
            SignalFragment testItem = new SignalFragment();

            Assert.IsNotNull(testItem);
            Assert.AreEqual((testItem as ISignalContent).Offset, 0);
        }

        //> Constructor SignalFragment (int __offset)
        [Test]
        public void UTSignalFragmentConstructor2 ()
        {
            SignalFragment testItem = new SignalFragment(3);

            Assert.IsNotNull(testItem);
            Assert.AreEqual((testItem as ISignalContent).Offset, 3);
        }

        //> Constructor SignalFragment (List<ISignalContent> __contents)
        [Test]
        public void UTSignalFragmentConstructor3 ()
        {
            List<ISignalContent> newContents = new List<ISignalContent>{new Wave(1), new Wave(2, 2)};
            SignalFragment testItem = new SignalFragment(newContents);

            Assert.IsNotNull(testItem);
            Assert.IsTrue((testItem as ISignalHandler).HasValuesAt(0));
            Assert.IsTrue((testItem as ISignalHandler).HasValuesAt(2));
            Assert.IsFalse((testItem as ISignalHandler).HasValuesAt(3));
            Assert.IsFalse((testItem as ISignalHandler).HasValuesAt(5));
        }

        //> Constructor SignalFragment (int __offset, List<ISignalContent> __contents)
        [Test]
        public void UTSignalFragmentConstructor4 ()
        {
            List<ISignalContent> newContents = new List<ISignalContent>{new Wave(1), new Wave(2, 2)};
            SignalFragment testItem = new SignalFragment(3, newContents);

            Assert.IsNotNull(testItem);
            Assert.AreEqual((testItem as ISignalContent).Offset, 3);
            Assert.IsTrue((testItem as ISignalHandler).HasValuesAt(3));
            Assert.IsTrue((testItem as ISignalHandler).HasValuesAt(5));
            Assert.IsFalse((testItem as ISignalHandler).HasValuesAt(0));
            Assert.IsFalse((testItem as ISignalHandler).HasValuesAt(2));
        }
    //ENDOF Constructor

    //ISignalHandler interface
        //> HasValuesAt (int position, uint loopLength, bool recursive)
            //> Check for an EXISTENT position, NOT using loopLength, NOT recursively
        [Test]
        public void UTSignalFragmentHasValuesAt1 ()
        {
            Assert.IsTrue(false);
        }

            //> Check for an EXISTENT position, NOT using loopLength, RECURSIVELY
        [Test]
        public void UTSignalFragmentHasValuesAt2 ()
        {
            Assert.IsTrue(false);
        }

            //> Check for an EXISTENT position, USING loopLength, RECURSIVELY
        [Test]
        public void UTSignalFragmentHasValuesAt3 ()
        {
            Assert.IsTrue(false);
        }

            //> Check for a NON-EXISTENT position, USING loopLength
        [Test]
        public void UTSignalFragmentHasValuesAt4 ()
        {
            Assert.IsTrue(false);
        }


        //> GetValuesAt (int position, ISignalStack collectorStack, uint loopLength, bool recursive)
            //> Get a SINGLE EXISTENT value at position, NOT using loopLength, recursively
        [Test]
        public void UTSignalFragmentGetValuesAt1 ()
        {
            Assert.IsTrue(false);
        }

            //> Get MULTIPLE VALUES at position, in different loop multiples USING loopLength, recursively
        [Test]
        public void UTSignalFragmentGetValuesAt2 ()
        {
            Assert.IsTrue(false);
        }

            //> Check if an EXISTENT value at a deeper level is ignored if NON RECURSIVE
        [Test]
        public void UTSignalFragmentGetValuesAt3 ()
        {
            Assert.IsTrue(false);
        }

            //> NOT PROVIDING collectorStack, get EXISTENT values at position
        [Test]
        public void UTSignalFragmentGetValuesAt4 ()
        {
            Assert.IsTrue(false);
        }



    //ENDOF ISignalHandler interface

    //ISignalContainer interface
        //> AddChild (ISignalContent newEntry)
            //> Check if an EXISTENT child is properly added
        [Test]
        public void UTSignalFragmentAddChild1 ()
        {
            Assert.IsTrue(false);
        }

            //> Check if a NULL child is properly ignored
        [Test]
        public void UTSignalFragmentAddChild2 ()
        {
            Assert.IsTrue(false);
        }


        //> AddChildAt (ISignalContent newEntry, int position, bool absolutePosition)
            //> Check wether an EXISTENT child is properly added at position, NON absolute
        [Test]
        public void UTSignalFragmentAddChildAt1 ()
        {
            Assert.IsTrue(false);
        }

            //> Check wether an EXISTENT child is properly added at ABSOLUTE position
        [Test]
        public void UTSignalFragmentAddChildAt2 ()
        {
            Assert.IsTrue(false);
        }

            //> Check wether a NULL child is properly ignored        
        [Test]
        public void UTSignalFragmentAddChildAt3 ()
        {
            Assert.IsTrue(false);
        }


        //> GetChildren (List<ISignalContent> collectorArray, bool recursive)
            //> Get list of immediate children, NON-recursively, PROVIDING collectorArray
        [Test]
        public void UTSignalFragmentGetChildren1 ()
        {
            Assert.IsTrue(false);
        }

            //> Get full list of children, RECURSIVELY, PROVIDING collectorArray
        [Test]
        public void UTSignalFragmentGetChildren2 ()
        {
            Assert.IsTrue(false);
        }

            //> Get a list of children NOT PROVIDING collectoArray
        [Test]
        public void UTSignalFragmentGetChildren3 ()
        {
            Assert.IsTrue(false);
        }

        //> GetChildrenTouching<TSignalHandler> (int position, List<TSignalHandler> collectorArray, uint loopLength, bool recursive)
            //> Get an EXISTENT child at position, NOT using loopLength, NON recursively
        [Test]
        public void UTSignalFragmentGetChildrenTouching1 ()
        {
            Assert.IsTrue(false);
        }

            //> Get an EXISTENT child at position, USING loopLength, NON recursively
        [Test]
        public void UTSignalFragmentGetChildrenTouching2 ()
        {
            Assert.IsTrue(false);
        }

            //> Get an EXISTENT child at position, NOT using loopLength, RECURSIVELY, WITHOUT deeper children
        [Test]
        public void UTSignalFragmentGetChildrenTouching3 ()
        {
            Assert.IsTrue(false);
        }

            //> Get an EXISTENT child at position, NOT using loopLength, RECURSIVELY, WITH deeper children
        [Test]
        public void UTSignalFragmentGetChildrenTouching4 ()
        {
            Assert.IsTrue(false);
        }

            //> Get an EXISTENT child at position, USING using loopLength, RECURSIVELY, WITH deeper children
        [Test]
        public void UTSignalFragmentGetChildrenTouching5 ()
        {
            Assert.IsTrue(false);
        }

            //> Get a NON-EXISTENT child at position, USING loopLength
        [Test]
        public void UTSignalFragmentGetChildrenTouching6 ()
        {
            Assert.IsTrue(false);
        }

            //> NOT PROVIDING collectorArray, get an EXISTENT child at position        
        [Test]
        public void UTSignalFragmentGetChildrenTouching7 ()
        {
            Assert.IsTrue(false);
        }


        //> RemoveChild (ISignalContent target)
            //> Check for removal of ONE child
        [Test]
        public void UTSignalFragmentRemoveChild1 ()
        {
            Assert.IsTrue(false);
        }

        //> RemoveChildren (List<ISignalContent> targets)
            //> Check for removal of SOME but NOT ALL children
        [Test]
        public void UTSignalFragmentRemoveChildren1 ()
        {
            Assert.IsTrue(false);
        }

        //> RemoveChildren ()
            //> Check for removal of ALL children
        [Test]
        public void UTSignalFragmentRemoveChildren2 ()
        {
            Assert.IsTrue(false);
        }

    //ENDOF ISignalContainer interface

    //ISignalContent interface
        //> int Offset { get; set; }
        [Test]
        public void UTSignalFragmentOffset1 ()
        {
            Assert.IsTrue(false);
        }

    //ENDOF ISignalContent interface

//Delete me when done
        [Test]
        public void SignalFragmentUnfinishedMarker()
        {
            Assert.IsTrue(false);
        }
//Delete me when done
    }
}
