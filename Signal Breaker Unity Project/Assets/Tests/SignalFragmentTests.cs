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
            //> Check for a (non)EXISTENT position, NOT using loopLength, NOT recursively
        [Test]
        public void UTSignalFragmentHasValuesAt1 ()
        {
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(0, 0),
                    new Wave(2, 2)
                }
            );
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(0));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(2));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(1));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(-4));

            SignalFragment testItem2 = new SignalFragment(3, 
                new List<ISignalContent> {
                    new Wave(8, 5),
                    new Wave(1, -2)
                }
            );
            Assert.IsFalse((testItem2 as ISignalHandler).HasValuesAt(-2));
            Assert.IsFalse((testItem2 as ISignalHandler).HasValuesAt(5));
            Assert.IsTrue((testItem2 as ISignalHandler).HasValuesAt(8));
            Assert.IsTrue((testItem2 as ISignalHandler).HasValuesAt(1));

            SignalFragment testItem3 = new SignalFragment(-2, 
                new List<ISignalContent> {
                    new Wave(0, 2),
                    new Wave(-4, -2),
                    new Wave(5, 7)
                }
            );
            Assert.IsTrue((testItem3 as ISignalHandler).HasValuesAt(0));
            Assert.IsTrue((testItem3 as ISignalHandler).HasValuesAt(-4));
            Assert.IsTrue((testItem3 as ISignalHandler).HasValuesAt(5));
            Assert.IsFalse((testItem3 as ISignalHandler).HasValuesAt(2));
            Assert.IsFalse((testItem3 as ISignalHandler).HasValuesAt(7));
        }

            //> Check for a (non)EXISTENT position, USING loopLength, NOT recursively
        [Test]
        public void UTSignalFragmentHasValuesAt2 ()
        {
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(-3, -3),
                    new Wave(6, 6),
                    new Wave(8, 8)
                }
            );
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(-4, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(3, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(0, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(2, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(6, 7));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(1, 7));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(1, 6));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(-4));

            SignalFragment testItem2 = new SignalFragment(-3, 
                new List<ISignalContent> {
                    new Wave(2, 5),
                    new Wave(-5, -2)
                }
            );
            Assert.IsTrue((testItem2 as ISignalHandler).HasValuesAt(2, 6));
            Assert.IsTrue((testItem2 as ISignalHandler).HasValuesAt(-4, 6));
            Assert.IsTrue((testItem2 as ISignalHandler).HasValuesAt(14, 6));
            Assert.IsTrue((testItem2 as ISignalHandler).HasValuesAt(1, 6));
            Assert.IsFalse((testItem2 as ISignalHandler).HasValuesAt(-4));
            Assert.IsFalse((testItem2 as ISignalHandler).HasValuesAt(3, 6));
            Assert.IsFalse((testItem2 as ISignalHandler).HasValuesAt(4, 6));
            Assert.IsFalse((testItem2 as ISignalHandler).HasValuesAt(5, 6));
            Assert.IsFalse((testItem2 as ISignalHandler).HasValuesAt(0, 6));

            SignalFragment testItem3 = new SignalFragment(2, 
                new List<ISignalContent> {
                    new Wave(2, 0),
                    new Wave(-2, -4),
                    new Wave(7, 5)
                }
            );
            Assert.IsTrue((testItem3 as ISignalHandler).HasValuesAt(2, 6));
            Assert.IsTrue((testItem3 as ISignalHandler).HasValuesAt(4, 6));
            Assert.IsTrue((testItem3 as ISignalHandler).HasValuesAt(1, 6));
            Assert.IsFalse((testItem3 as ISignalHandler).HasValuesAt(3, 6));
            Assert.IsFalse((testItem3 as ISignalHandler).HasValuesAt(5, 6));
        }

            //> Check for a (non)EXISTENT position, NOT using loopLength, RECURSIVELY
        [Test]
        public void UTSignalFragmentHasValuesAt3 ()
        {
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new SignalFragment(0, new List<ISignalContent> {
                        new Wave(1, 0),
                        new Wave(1, 1)
                    }),
                    new SignalFragment(3, new List<ISignalContent> {
                        new Wave(3, 0),
                        new Wave(1, 3)
                    }),
                    new SignalFragment(6, new List<ISignalContent> {
                        new Wave(4, 4),
                        new Wave(4, -2),
                    })
                }
            );
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(0));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(1));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(3));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(4));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(10));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(2));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(5));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(0, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(1, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(3, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(4, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(10, recursive: false));
        }

            //> Check for a (non)EXISTENT position, USING loopLength, RECURSIVELY
        [Test]
        public void UTSignalFragmentHasValuesAt4 ()
        {
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new SignalFragment(-3, new List<ISignalContent> {
                        new Wave(-3, 0),
                        new Wave(1, 2)
                    }),
                    new SignalFragment(6, new List<ISignalContent> {
                        new Wave(4, 4),
                        new Wave(4, 8),
                    })
                }
            );

            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(0, 6));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(1, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(2, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(3, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(4, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(5, 6));
            Assert.IsTrue((testItem1 as ISignalHandler).HasValuesAt(0, 6, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(2, 6, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(3, 6, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(4, 6, recursive: false));
            Assert.IsFalse((testItem1 as ISignalHandler).HasValuesAt(5, 6, recursive: false));
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
