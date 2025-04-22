using NUnit.Framework;
using UnityEngine;
using Jyodann.VectorExtensions.Vector4Ex;

namespace Jyodann.VectorExtensions.Vector4Tests
{
    public class Vector4ExtensionsTests
    {
        private Vector4 v1;
        private Vector4 v2;

        [SetUp]
        public void Setup()
        {
            v1 = new Vector4(1, 2, 3, 4);
            v2 = new Vector4(4, 3, 2, 1);
        }

        [Test]
        public void DistanceTo_ReturnsCorrectDistance()
        {
            float expected = Vector4.Distance(v1, v2);
            float actual = v1.DistanceTo(v2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DotTo_ReturnsCorrectDotProduct()
        {
            float expected = Vector4.Dot(v1, v2);
            float actual = v1.DotTo(v2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LerpTo_ReturnsCorrectLerp()
        {
            float t = 0.5f;
            Vector4 expected = Vector4.Lerp(v1, v2, t);
            Vector4 actual = v1.LerpTo(v2, t);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LerpUnclampedTo_ReturnsCorrectLerpUnclamped()
        {
            float t = 1.5f;
            Vector4 expected = Vector4.LerpUnclamped(v1, v2, t);
            Vector4 actual = v1.LerpUnclampedTo(v2, t);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MaxTo_ReturnsCorrectMax()
        {
            Vector4 expected = Vector4.Max(v1, v2);
            Vector4 actual = v1.MaxTo(v2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MinTo_ReturnsCorrectMin()
        {
            Vector4 expected = Vector4.Min(v1, v2);
            Vector4 actual = v1.MinTo(v2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ProjectTo_ReturnsCorrectProjection()
        {
            Vector4 expected = Vector4.Project(v1, v2);
            Vector4 actual = v1.ProjectTo(v2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ScaleTo_ReturnsCorrectScale()
        {
            Vector4 expected = Vector4.Scale(v1, v2);
            Vector4 actual = v1.ScaleTo(v2);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShorterLengthThan_ReturnsTrue_WhenV1IsShorter()
        {
            Vector4 vShort = new Vector4(1, 1, 1, 1);
            Vector4 vLong = new Vector4(10, 10, 10, 10);
            Assert.IsTrue(vShort.IsShorterLengthThan(vLong));
        }

        [Test]
        public void LongerLengthThan_ReturnsTrue_WhenV1IsLonger()
        {
            Vector4 vShort = new Vector4(1, 1, 1, 1);
            Vector4 vLong = new Vector4(10, 10, 10, 10);
            Assert.IsTrue(vLong.IsLongerLengthThan(vShort));
        }

        [Test]
        public void SameLengthAs_ReturnsTrue_WhenLengthsAreEqual()
        {
            Vector4 vA = new Vector4(1, 2, 3, 4);
            Vector4 vB = new Vector4(1, 2, 3, 4);
            Assert.IsTrue(vA.IsSameLengthAs(vB));
        }
    }
}