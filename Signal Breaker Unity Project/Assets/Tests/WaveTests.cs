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

        }

            //> Check for THIS wave's position, USING loopLength
        [Test]
        public void UTWaveHasValuesAt2 ()
        {

        }
            //> Check for NOT THIS wave's position
        [Test]
        public void UTWaveHasValuesAt3 ()
        {

        }

        //> GetValuesAt (int position, ISignalStack collectorStack, uint loopLength, bool recursive)
            //> Get value corresponding to THIS wave's position, NOT using loopLength, PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt1 ()
        {

        }
            //> Get value corresponding to THIS wave's position, USING loopLength, PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt2 ()
        {

        }
            //> Get value corresponding to a DIFFERENT wave position, PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt3 ()
        {

        }
            //> Get value NOT PROVIDING collectorStack
        [Test]
        public void UTWaveGetValuesAt4 ()
        {

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
