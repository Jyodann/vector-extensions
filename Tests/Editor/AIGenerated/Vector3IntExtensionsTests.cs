using NUnit.Framework;
using UnityEngine;
using Jyodann.VectorExtensions.Vector3IntEx;

namespace Jyodann.VectorExtensions.Vector3IntTests
{
    public class Vector3IntExtensionsTests
    {
        [Test]
        public void DistanceTo_CalculatesCorrectDistance()
        {
            // Arrange
            var a = new Vector3Int(1, 2, 3);
            var b = new Vector3Int(4, 6, 9);

            // Act
            float distance = a.DistanceTo(b);

            // Assert
            float expectedDistance = Mathf.Sqrt((4 - 1) * (4 - 1) + (6 - 2) * (6 - 2) + (9 - 3) * (9 - 3));
            Assert.AreEqual(expectedDistance, distance);
        }

        [Test]
        public void MaxTo_ReturnsComponentWiseMaximum()
        {
            // Arrange
            var a = new Vector3Int(1, 5, 3);
            var b = new Vector3Int(4, 2, 6);

            // Act
            var result = a.MaxTo(b);

            // Assert
            Assert.AreEqual(new Vector3Int(4, 5, 6), result);
        }

        [Test]
        public void MinTo_ReturnsComponentWiseMinimum()
        {
            // Arrange
            var a = new Vector3Int(1, 5, 3);
            var b = new Vector3Int(4, 2, 6);

            // Act
            var result = a.MinTo(b);

            // Assert
            Assert.AreEqual(new Vector3Int(1, 2, 3), result);
        }

        [Test]
        public void ScaleTo_ReturnsComponentWiseProduct()
        {
            // Arrange
            var a = new Vector3Int(2, 3, 4);
            var b = new Vector3Int(5, 6, 7);

            // Act
            var result = a.ScaleTo(b);

            // Assert
            Assert.AreEqual(new Vector3Int(10, 18, 28), result);
        }

        [Test]
        public void ShorterLengthThan_ReturnsTrueWhenShorter()
        {
            // Arrange
            var shorter = new Vector3Int(1, 0, 0);
            var longer = new Vector3Int(2, 0, 0);

            // Act & Assert
            Assert.IsTrue(shorter.IsShorterLengthThan(longer));
            Assert.IsFalse(longer.IsShorterLengthThan(shorter));
        }

        [Test]
        public void LongerLengthThan_ReturnsTrueWhenLonger()
        {
            // Arrange
            var shorter = new Vector3Int(1, 0, 0);
            var longer = new Vector3Int(2, 0, 0);

            // Act & Assert
            Assert.IsTrue(longer.IsLongerLengthThan(shorter));
            Assert.IsFalse(shorter.IsLongerLengthThan(longer));
        }

        [Test]
        public void SameLengthAs_ReturnsTrueWhenEqualLength()
        {
            // Arrange
            var a = new Vector3Int(1, 2, 2); // sqrt(1+4+4) = 3
            var b = new Vector3Int(3, 0, 0); // sqrt(9+0+0) = 3

            // Act & Assert
            Assert.IsTrue(a.IsSameLengthAs(b));
            Assert.IsFalse(a.IsSameLengthAs(new Vector3Int(1, 1, 1)));
        }

        [Test]
        public void EdgeCases()
        {
            // Zero vectors
            var zero = Vector3Int.zero;
            var nonZero = new Vector3Int(1, 1, 1);

            Assert.IsTrue(zero.IsShorterLengthThan(nonZero));
            Assert.IsFalse(zero.IsLongerLengthThan(nonZero));
            Assert.IsTrue(zero.IsSameLengthAs(Vector3Int.zero));

            // Negative components (though Vector3Int can't have negatives)
            var v1 = new Vector3Int(-1, -1, -1);
            var v2 = new Vector3Int(1, 1, 1);

            Assert.IsTrue(v1.IsSameLengthAs(v2));
        }
    }
}