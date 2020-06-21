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
            //> Get a SINGLE and MULTIPLE EXISTENT values at position, NOT using loopLength, recursively
        [Test]
        public void UTSignalFragmentGetValuesAt1 ()
        {
            
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new SignalFragment(-3, new List<ISignalContent> {
                        new Wave(1, 3),
                        new Wave(1, 5)
                    }),
                    new SignalFragment(6, new List<ISignalContent> {
                        new Wave(1, 0),
                        new Wave(1, 8),
                    })
                }
            );
            
            Assert.AreEqual(1, (testItem1 as ISignalHandler).GetValuesAt(0, recursive: false).Value);
            Assert.AreEqual(0, (testItem1 as ISignalHandler).GetValuesAt(2, recursive: false).Value);
            Assert.AreEqual(2, (testItem1 as ISignalHandler).GetValuesAt(0, recursive: true).Value);
            Assert.AreEqual(1, (testItem1 as ISignalHandler).GetValuesAt(2, recursive: true).Value);
        }

            //> Get MULTIPLE VALUES at position, in different loop multiples USING loopLength, recursively
        [Test]
        public void UTSignalFragmentGetValuesAt2 ()
        {
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new SignalFragment(-3, new List<ISignalContent> {
                        new Wave(1, 3),
                        new Wave(1, -1)
                    }),
                    new SignalFragment(6, new List<ISignalContent> {
                        new Wave(1, 0),
                        new Wave(1, 8),
                    })
                }
            );
            
            Assert.AreEqual(1, (testItem1 as ISignalHandler).GetValuesAt(0, loopLength: 6, recursive: false).Value);
            Assert.AreEqual(0, (testItem1 as ISignalHandler).GetValuesAt(2, loopLength: 6, recursive: false).Value);
            Assert.AreEqual(3, (testItem1 as ISignalHandler).GetValuesAt(0, loopLength: 6, recursive: true).Value);
            Assert.AreEqual(2, (testItem1 as ISignalHandler).GetValuesAt(2, loopLength: 6, recursive: true).Value);
        }

            //> Check if an EXISTENT value at a deeper level is ignored if NON RECURSIVE
        [Test]
        public void UTSignalFragmentGetValuesAt3 ()
        {
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, 2),
                    new SignalFragment(0, new List<ISignalContent> {
                        new Wave(1, 0),
                        new Wave(1, 2)
                    })
                }
            );

            Assert.AreEqual(2, (testItem1 as ISignalHandler).GetValuesAt(0).Value);
            Assert.AreEqual(2, (testItem1 as ISignalHandler).GetValuesAt(2).Value);
            Assert.AreEqual(1, (testItem1 as ISignalHandler).GetValuesAt(0, recursive: false).Value);
            Assert.AreEqual(1, (testItem1 as ISignalHandler).GetValuesAt(2, recursive: false).Value);
        }

            //> PROVIDING collectorStack, get EXISTENT values at position
        [Test]
        public void UTSignalFragmentGetValuesAt4 ()
        {
            SignalFragment testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, 2),
                    new SignalFragment(0, new List<ISignalContent> {
                        new Wave(1, 2)
                    })
                }
            );


            ISignalStack testCollector = new WaveStack();
            (testItem1 as ISignalHandler).GetValuesAt(0, collectorStack: testCollector);
            Assert.AreEqual(1, testCollector.Value);

            testCollector = new WaveStack();
            (testItem1 as ISignalHandler).GetValuesAt(2, collectorStack: testCollector);
            Assert.AreEqual(2, testCollector.Value);
        }



    //ENDOF ISignalHandler interface

    //ISignalContainer interface
        //> AutoRebaseOffsets ()
            //> Check if offsets above 0 are properly rebased
        [Test]
        public void UTSignalFragmentAutoRebaseOffsets1 ()
        {
            ISignalContainer testItem1 = new SignalFragment(3, 
                new List<ISignalContent> {
                    new Wave(6, 3),
                    new Wave(7, 4),
                    new SignalFragment(5, new List<ISignalContent> {
                        new Wave(9, 1)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(6, testItem1.GetValuesAt(6).Value);
            Assert.AreEqual(7, testItem1.GetValuesAt(7).Value);
            Assert.AreEqual(9, testItem1.GetValuesAt(9).Value);

            testItem1.AutoRebaseOffsets();

            Assert.AreEqual(6, testItem1.GetValuesAt(6).Value);
            Assert.AreEqual(7, testItem1.GetValuesAt(7).Value);
            Assert.AreEqual(9, testItem1.GetValuesAt(9).Value);
            Assert.AreEqual(6, (testItem1 as ISignalContent).Offset);
            Assert.AreEqual(3, (testItem1.GetChildrenTouching(9, recursive: false)[0] as ISignalContent).Offset);
        }
            //> Check if offsets above 0 are properly rebased
        [Test]
        public void UTSignalFragmentAutoRebaseOffsets2 ()
        {
             ISignalContainer testItem1 = new SignalFragment(-3, 
                new List<ISignalContent> {
                    new Wave(-6, -3),
                    new Wave(-7, -4),
                    new SignalFragment(-5, new List<ISignalContent> {
                        new Wave(-9, -1)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(-6, testItem1.GetValuesAt(-6).Value);
            Assert.AreEqual(-7, testItem1.GetValuesAt(-7).Value);
            Assert.AreEqual(-9, testItem1.GetValuesAt(-9).Value);

            testItem1.AutoRebaseOffsets();

            Assert.AreEqual(-6, testItem1.GetValuesAt(-6).Value);
            Assert.AreEqual(-7, testItem1.GetValuesAt(-7).Value);
            Assert.AreEqual(-9, testItem1.GetValuesAt(-9).Value);
            Assert.AreEqual(-9, (testItem1 as ISignalContent).Offset);
            Assert.AreEqual(0, (testItem1.GetChildrenTouching(-9, recursive: false)[0] as ISignalContent).Offset);
        }

        //> AddChild (ISignalContent newEntry)
            //> Check if an EXISTENT child is properly added
        [Test]
        public void UTSignalFragmentAddChild1 ()
        {
            ISignalContainer testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0)
                }
            ) as ISignalContainer;
            ISignalContent testWave1 = new Wave(1, 2) as ISignalContent;

            Assert.IsTrue(testItem1.HasValuesAt(0));
            Assert.IsFalse(testItem1.HasValuesAt(2));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 1);

            testItem1.AddChild(testWave1);

            Assert.IsTrue(testItem1.HasValuesAt(0));
            Assert.IsTrue(testItem1.HasValuesAt(2));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 2);
        }

            //> Check if a NULL child is properly ignored
        [Test]
        public void UTSignalFragmentAddChild2 ()
        {
            ISignalContainer testItem1 = new SignalFragment(0, 
                new List<ISignalContent> {
                    new Wave(1, 0)
                }
            ) as ISignalContainer;

            Assert.IsTrue(testItem1.HasValuesAt(0));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 1);

            testItem1.AddChild(null);

            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 1);
        }


        //> AddChildAt (ISignalContent newEntry, int position, bool absolutePosition)
            //> Check wether an EXISTENT child is properly added at position, NON absolute
        [Test]
        public void UTSignalFragmentAddChildAt1 ()
        {
            ISignalContainer testItem1 = new SignalFragment(1, 
                new List<ISignalContent> {
                    new Wave(1, 0)
                }
            ) as ISignalContainer;
            ISignalContent testWave1 = new Wave(1, -2) as ISignalContent;

            Assert.IsTrue(testItem1.HasValuesAt(1));
            Assert.IsFalse(testItem1.HasValuesAt(2));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 1);

            testItem1.AddChildAt(testWave1, 2);

            Assert.IsTrue(testItem1.HasValuesAt(1));
            Assert.IsTrue(testItem1.HasValuesAt(2));
            Assert.IsFalse(testItem1.HasValuesAt(-1));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 2);
        }

            //> Check wether an EXISTENT child is properly added at ABSOLUTE position
        [Test]
        public void UTSignalFragmentAddChildAt2 ()
        {
            ISignalContainer testItem1 = new SignalFragment(1, 
                new List<ISignalContent> {
                    new Wave(1, 0)
                }
            ) as ISignalContainer;
            ISignalContent testWave1 = new Wave(1, -2) as ISignalContent;

            Assert.IsTrue(testItem1.HasValuesAt(1));
            Assert.IsFalse(testItem1.HasValuesAt(3));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 1);

            testItem1.AddChildAt(testWave1, 2, true);

            Assert.IsTrue(testItem1.HasValuesAt(1));
            Assert.IsTrue(testItem1.HasValuesAt(3));
            Assert.IsFalse(testItem1.HasValuesAt(-2));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 2);
        }

            //> Check wether a NULL child is properly ignored        
        [Test]
        public void UTSignalFragmentAddChildAt3 ()
        {
            ISignalContainer testItem1 = new SignalFragment(1, 
                new List<ISignalContent> {
                    new Wave(1, 0)
                }
            ) as ISignalContainer;

            Assert.IsTrue(testItem1.HasValuesAt(1));
            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>()).Count, 1);

            testItem1.AddChildAt(null, 2, true);

            Assert.IsTrue(testItem1.HasValuesAt(1));

            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>(), false).Count, 1);
        }


        //> GetChildren (List<ISignalContent> collectorArray, bool recursive)
            //> Get list of immediate children, NON-recursively, PROVIDING collectorArray
        [Test]
        public void UTSignalFragmentGetChildren1 ()
        {
            ISignalContainer testItem1 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, 0),
                    new SignalFragment(new List<ISignalContent> {
                        new Wave(1, 0),
                        new SignalFragment(new List<ISignalContent> {
                            new Wave(1, 0)
                        }),
                        new SignalFragment(new List<ISignalContent> {
                            new Wave(1, 0)
                        })
                    }),
                    new SignalFragment(new List<ISignalContent> {
                        new Wave(1, 0)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(testItem1.GetChildren(new List<ISignalContent>(), false).Count, 4);
        }

            //> Get full list of children, RECURSIVELY, NOT PROVIDING collectorArray
        [Test]
        public void UTSignalFragmentGetChildren2 ()
        {
            ISignalContainer testItem1 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, 0),
                    new SignalFragment(new List<ISignalContent> {
                        new Wave(1, 0),
                        new SignalFragment(new List<ISignalContent> {
                            new Wave(1, 0)
                        }),
                        new SignalFragment(new List<ISignalContent> {
                            new Wave(1, 0)
                        })
                    }),
                    new SignalFragment(new List<ISignalContent> {
                        new Wave(1, 0)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(testItem1.GetChildren().Count, 10);
        }

        //> GetChildrenTouching<TSignalHandler> (int position, List<TSignalHandler> collectorArray, uint loopLength, bool recursive)
            //> Get an EXISTENT child at position, NOT using loopLength, NON recursively
        [Test]
        public void UTSignalFragmentGetChildrenTouching1 ()
        {
            ISignalContainer testItem1 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, 3),
                    new SignalFragment(new List<ISignalContent> {
                        new Wave(1, 3),
                        new SignalFragment(new List<ISignalContent> {
                            new Wave(1, 0)
                        }),
                        new SignalFragment(2, new List<ISignalContent> {
                            new Wave(1, 0),
                            new Wave(1, 1)
                        })
                    }),
                    new SignalFragment(2, new List<ISignalContent> {
                        new Wave(1, 0),
                        new Wave(1, 1)
                    }),
                    new SignalFragment(1, new List<ISignalContent> {
                        new Wave(1,0)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(3 , testItem1.GetChildrenTouching(3, recursive: false).Count);
        }

            //> Get an EXISTENT and NON EXISTENT child at position, USING loopLength, NON recursively
        [Test]
        public void UTSignalFragmentGetChildrenTouching2 ()
        {
            ISignalContainer testItem1 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, -3), //si
                    new SignalFragment(6, new List<ISignalContent> {//si
                        new Wave(1, 3), //si
                        new SignalFragment(-2, new List<ISignalContent> {//si
                            new Wave(1, -1) //si
                        }),
                        new SignalFragment(2, new List<ISignalContent> {
                            new Wave(1, 0),
                            new Wave(1, 2)
                        })
                    }),
                    new SignalFragment(24, new List<ISignalContent> {//si
                        new Wave(1, 0),
                        new Wave(1, 27) //si
                    }),
                    new SignalFragment(3, new List<ISignalContent> {
                        new Wave(1,3)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(3, testItem1.GetChildrenTouching(3, loopLength: 6, recursive: false).Count);

            //non-existent
            ISignalContainer testItem2 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, -3), 
                    new SignalFragment(3, new List<ISignalContent> {
                        new Wave(1, 5),
                        new Wave(1, 7),
                    }),
                    new SignalFragment(24, new List<ISignalContent> {
                        new Wave(1, 11),
                    }),
                    new SignalFragment(-9, new List<ISignalContent> {
                         new Wave(1, -5),
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(0, testItem2.GetChildrenTouching(1, loopLength: 6, recursive: true).Count);
        }

            //> Get an EXISTENT child at position, NOT using loopLength, RECURSIVELY, WITHOUT deeper children
        [Test]
        public void UTSignalFragmentGetChildrenTouching3 ()
        {
            ISignalContainer testItem1 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, -3), //si
                    new SignalFragment(3, new List<ISignalContent> {//si
    
                    }),
                    new SignalFragment(24, new List<ISignalContent> {//si
                        
                    }),
                    new SignalFragment(3, new List<ISignalContent> {
                        
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(1, testItem1.GetChildrenTouching(3, loopLength: 6, recursive: true).Count);
        }

            //> Get an EXISTENT child at position, USING and NOT using loopLength, RECURSIVELY, WITH deeper children
        [Test]
        public void UTSignalFragmentGetChildrenTouching4 ()
        {
            ISignalContainer testItem1 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, -3), //si
                    new SignalFragment(6, new List<ISignalContent> {//si
                        new Wave(1, 9), //si
                        new SignalFragment(-2, new List<ISignalContent> {//si
                            new Wave(1, -1) //si
                        }),
                        new SignalFragment(2, new List<ISignalContent> {
                            new Wave(1, 0),
                            new Wave(1, 2)
                        })
                    }),
                    new SignalFragment(24, new List<ISignalContent> {//si
                        new Wave(1, 0),
                        new Wave(1, 27) //si
                    }),
                    new SignalFragment(3, new List<ISignalContent> {
                        new Wave(1,3)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(3, testItem1.GetChildrenTouching(3, recursive: true).Count);
            Assert.AreEqual(7, testItem1.GetChildrenTouching(3, loopLength: 6, recursive: true).Count);
        }

            //> PROVIDING collectorArray, get an EXISTENT child at position        
        [Test]
        public void UTSignalFragmentGetChildrenTouching6 ()
        {
            ISignalContainer testItem1 = new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, 3),
                    new SignalFragment(new List<ISignalContent> {
                        new Wave(1, 3),
                        new SignalFragment(new List<ISignalContent> {
                            new Wave(1, 0)
                        }),
                        new SignalFragment(2, new List<ISignalContent> {
                            new Wave(1, 0),
                            new Wave(1, 1)
                        })
                    }),
                    new SignalFragment(2, new List<ISignalContent> {
                        new Wave(1, 0),
                        new Wave(1, 1)
                    }),
                    new SignalFragment(1, new List<ISignalContent> {
                        new Wave(1,0)
                    })
                }
            ) as ISignalContainer;

            Assert.AreEqual(5, testItem1.GetChildrenTouching(3, recursive: false, collectorArray: new List<ISignalContent>{new Wave(1, 0), new Wave(1, 3)}).Count);
        }


        //> RemoveChild (ISignalContent target)
            //> Check for removal of ONE child
        [Test]
        public void UTSignalFragmentRemoveChild1 ()
        {
            Wave waveTestItem = new Wave(1, 0);
            Wave waveTestItem2 = new Wave(1, 0);
            ISignalContainer testItem1 = (new SignalFragment( 
                new List<ISignalContent> {
                    waveTestItem,
                    waveTestItem2,
                    new SignalFragment(0, new List<ISignalContent> {
                        new Wave(1, 1)
                    }),
                    new SignalFragment(3, new List<ISignalContent> {
                        new Wave(1, 8),
                    }),
                    waveTestItem2,
                }
            ) as ISignalContainer);

            Assert.AreEqual(testItem1.GetChildren(recursive: false).Count, 5);
            testItem1.RemoveChild(waveTestItem as ISignalContent);
            Assert.AreEqual(testItem1.GetChildren(recursive: false).Count, 4);
            testItem1.RemoveChild(waveTestItem2 as ISignalContent);
            Assert.AreEqual(testItem1.GetChildren(recursive: false).Count, 2);
        }

        //> RemoveChildren (List<ISignalContent> targets)
            //> Check for removal of SOME but NOT ALL children
        [Test]
        public void UTSignalFragmentRemoveChildren1 ()
        {
            List<ISignalContent> testItemList = new List<ISignalContent> { new Wave(1, 0), new Wave(1, 2) };
            ISignalContainer testItem1 = (new SignalFragment( 
                new List<ISignalContent> {
                    testItemList[0],
                    new SignalFragment(0, new List<ISignalContent> {
                        new Wave(1, 1)
                    }),
                    new SignalFragment(3, new List<ISignalContent> {
                        new Wave(1, 8),
                    }),
                    testItemList[1],
                }
            ) as ISignalContainer);

            Assert.AreEqual(testItem1.GetChildren(recursive: false).Count, 4);
            testItem1.RemoveChildren(testItemList);
            Assert.AreEqual(testItem1.GetChildren(recursive: false).Count, 2);
        }

        //> RemoveChildren ()
            //> Check for removal of ALL children
        [Test]
        public void UTSignalFragmentRemoveChildren2 ()
        {
            ISignalContainer testItem1 = (new SignalFragment( 
                new List<ISignalContent> {
                    new Wave(1, 0),
                    new Wave(1, 2),
                    new SignalFragment(0, new List<ISignalContent> {
                        new Wave(1, 1)
                    }),
                    new SignalFragment(3, new List<ISignalContent> {
                        new Wave(1, 8),
                    }),
                }
            ) as ISignalContainer);

            Assert.AreEqual(testItem1.GetChildren(recursive: false).Count, 4);
            testItem1.RemoveChildren();
            Assert.AreEqual(testItem1.GetChildren(recursive: false).Count, 0);
        }

    //ENDOF ISignalContainer interface

    //ISignalContent interface
        //> int Offset { get; set; }
        [Test]
        public void UTSignalFragmentOffset1 ()
        {
            Assert.AreEqual((new SignalFragment() as ISignalContent).Offset, 0);

            ISignalContent testItem1 = (new SignalFragment(1) as ISignalContent);
            ISignalContent testItem2 = (new SignalFragment(2, null) as ISignalContent);

            Assert.AreEqual(testItem1.Offset, 1);
            Assert.AreEqual(testItem2.Offset, 2);

            testItem1.Offset = 4;
            Assert.AreEqual(testItem1.Offset, 4);
        }
    }
    //ENDOF ISignalContent interface
}
