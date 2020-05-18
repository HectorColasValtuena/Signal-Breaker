using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using SignalHierarchy;

namespace SignalHierarchyTests
{
    public class WaveTests
    {
    //Constructor
        //> Constructor Wave (int __waveValue)
        [Test]
        public void UTWaveConstructor1 ()
        {
            Wave TestItem1 = new Wave (1);
            Wave TestItem2 = new Wave (2);

            Assert.IsNotNull(TestItem1);
            Assert.IsNotNull(TestItem2);
            Assert.AreEqual((TestItem1 as ISignalContent).Offset, 0);
            Assert.AreEqual((TestItem2 as ISignalContent).Offset, 0);
        }

        //> Constructor Wave (int __waveValue, int __offset) overload
        [Test]
        public void UTWaveConstructor2 ()
        {
            Wave TestItem1 = new Wave (1, 4);
            Wave TestItem2 = new Wave (2, 8);

            Assert.IsNotNull(TestItem1);
            Assert.IsNotNull(TestItem2);
            Assert.AreEqual((TestItem1 as ISignalContent).Offset, 4);
            Assert.AreEqual((TestItem2 as ISignalContent).Offset, 8);
        }
    //ENDOF Constructor

    //ISignalHandler interface
        //> HasValuesAt (int position, uint loopLength, bool recursive)
            //> Check for THIS wave's position, NOT using loopLength
        [Test]
        public void UTWaveHasValuesAt1 ()
        {
            ISignalHandler TestItem1 = (new Wave (1) as ISignalHandler);
            ISignalHandler TestItem2 = (new Wave (2, 2) as ISignalHandler);
            ISignalHandler TestItem3 = (new Wave (-2, 8) as ISignalHandler);
            ISignalHandler TestItem4 = (new Wave (3, -2) as ISignalHandler);

            Assert.IsTrue(TestItem1.HasValuesAt(0));
            Assert.IsFalse(TestItem1.HasValuesAt(6));

            Assert.IsTrue(TestItem2.HasValuesAt(2, recursive: true));
            Assert.IsFalse(TestItem2.HasValuesAt(8, recursive: true));

            Assert.IsTrue(TestItem3.HasValuesAt(8, recursive: false));
            Assert.IsFalse(TestItem3.HasValuesAt(2, recursive: false));

            Assert.IsTrue(TestItem4.HasValuesAt(-2));
            Assert.IsFalse(TestItem4.HasValuesAt(4));
        }

            //> Check for THIS wave's position, USING loopLength
        [Test]
        public void UTWaveHasValuesAt2 ()
        {
            ISignalHandler TestItem1 = (new Wave (1) as ISignalHandler);
            ISignalHandler TestItem2 = (new Wave (2, 2) as ISignalHandler);
            ISignalHandler TestItem3 = (new Wave (-2, 8) as ISignalHandler);
            ISignalHandler TestItem4 = (new Wave (3, -2) as ISignalHandler);

            Assert.IsTrue(TestItem1.HasValuesAt(0, 6));
            Assert.IsTrue(TestItem1.HasValuesAt(6, 6));
            Assert.IsTrue(TestItem1.HasValuesAt(-18, 6));
            Assert.IsFalse(TestItem1.HasValuesAt(7, 6));

            Assert.IsTrue(TestItem2.HasValuesAt(2, 6));
            Assert.IsTrue(TestItem2.HasValuesAt(8, 6));
            Assert.IsTrue(TestItem2.HasValuesAt(-16, 6));
            Assert.IsFalse(TestItem2.HasValuesAt(7, 6));

            Assert.IsTrue(TestItem3.HasValuesAt(2, 6));
            Assert.IsTrue(TestItem3.HasValuesAt(8, 6));
            Assert.IsTrue(TestItem3.HasValuesAt(-16, 6));
            Assert.IsFalse(TestItem3.HasValuesAt(7, 6));

            Assert.IsTrue(TestItem4.HasValuesAt(4, 6));
            Assert.IsTrue(TestItem4.HasValuesAt(10, 6));
            Assert.IsTrue(TestItem4.HasValuesAt(-20, 6));
            Assert.IsFalse(TestItem4.HasValuesAt(-9, 6));
        }
            //> Check for NOT THIS wave's position
        [Test]
        public void UTWaveHasValuesAt3 ()
        {
            ISignalHandler TestItem1 = (new Wave (1) as ISignalHandler);
            ISignalHandler TestItem2 = (new Wave (2, 2) as ISignalHandler);
            ISignalHandler TestItem3 = (new Wave (-2, 8) as ISignalHandler);
            ISignalHandler TestItem4 = (new Wave (3, -2) as ISignalHandler);

            Assert.IsTrue(TestItem1.HasValuesAt(0));
            Assert.IsFalse(TestItem1.HasValuesAt(6));
            Assert.IsFalse(TestItem1.HasValuesAt(1, 6));
            Assert.IsFalse(TestItem1.HasValuesAt(11, 6));

            Assert.IsTrue(TestItem2.HasValuesAt(2));
            Assert.IsFalse(TestItem2.HasValuesAt(8));
            Assert.IsFalse(TestItem2.HasValuesAt(4));
            Assert.IsFalse(TestItem2.HasValuesAt(4));
            Assert.IsFalse(TestItem2.HasValuesAt(11, 6));

            Assert.IsTrue(TestItem3.HasValuesAt(8));
            Assert.IsFalse(TestItem3.HasValuesAt(2));
            Assert.IsFalse(TestItem3.HasValuesAt(3, 6));
            Assert.IsFalse(TestItem3.HasValuesAt(-4));
            Assert.IsFalse(TestItem3.HasValuesAt(11, 6));

            Assert.IsTrue(TestItem4.HasValuesAt(-2));
            Assert.IsFalse(TestItem4.HasValuesAt(8));
            Assert.IsFalse(TestItem4.HasValuesAt(4));
            Assert.IsFalse(TestItem4.HasValuesAt(8, 6));
            Assert.IsFalse(TestItem4.HasValuesAt(-11, 6));
        }

        //> GetValuesAt (int position, ISignalStack collectorStack, uint loopLength, bool recursive)
            //> Get value corresponding to THIS wave's position, NOT using loopLength, PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt1 ()
        {


            Assert.IsTrue(false); //unfinished indicator
        }
            //> Get value corresponding to THIS wave's position, USING loopLength, PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt2 ()
        {


            Assert.IsTrue(false); //unfinished indicator
        }
            //> Get value corresponding to a DIFFERENT wave position, PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt3 ()
        {



            Assert.IsTrue(false); //unfinished indicator
        }
            //> Get value NOT PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt4 ()
        {
            

            Assert.IsTrue(false); //unfinished indicator
        }
    //ENDOF ISignalHandler interface

    //ISignalContent interface
        //> int Offset { get; set; }
        [Test]
        public void UTOffset ()
        {
            ISignalContent TestItem1 = new Wave (1) as ISignalContent;
            ISignalContent TestItem2 = new Wave (1, 4) as ISignalContent;
            Assert.AreEqual(TestItem1.Offset, 0);
            Assert.AreEqual(TestItem2.Offset, 4);

            TestItem1.Offset = 3;
            Assert.AreEqual(TestItem1.Offset, 3);
        }

    //ENDOF ISignalContent interface
    }
}
