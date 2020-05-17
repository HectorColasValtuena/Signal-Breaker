using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using SignalHierarchy;

namespace SignalHierarchyTests
{
    public class SignalHelperTests
    {
    //SignalHelper.AbsoluteToRelativePosition (int position, int offset = 0, uint loopLength = 0)
        //> Get position, NO offset, NO loopLength
        [Test]
        public void UTSignalHelperAbsoluteToRelativePosition1 ()
        {
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(2),
                2
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(4, 0),
                4
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(8, 0),
                8
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(12, 0, 0),
                12
            );
        }

        //> Get position, USING offset, NO loopLength
        [Test]
        public void UTSignalHelperAbsoluteToRelativePosition2 ()
        {
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(2, 2),
                0
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(4, 3),
                1
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(8, 10),
                -2
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(12, 6, 0),
                6
            );
        }

        //> Get position, NO offset, USING loopLength
        [Test]
        public void UTSignalHelperAbsoluteToRelativePosition3 ()
        {
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(2, loopLength: 6),
                2
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(4, loopLength: 3),
                1
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(-10, loopLength: 6),
                2
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(12, 0, 6),
                0
            );
        }

        //> Get position, USING offset, USING loopLength
        [Test]
        public void UTSignalHelperAbsoluteToRelativePosition4 ()
        {
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(2, 4, 6),
                4
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(4, -4, 6),
                2
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(-10, 4, 6),
                4
            );
            Assert.AreEqual(
                SignalHelper.AbsoluteToRelativePosition(18, 6, 6),
                0
            );
        }
    //ENDOF SignalHelper.AbsoluteToRelativePosition()
    }
}
