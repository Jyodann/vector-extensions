using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Jyodann.VectorExtensions.Vector2Ex;

namespace Jyodann.VectorExtensions.Vector2Tests
{
    public class Vector2ExtensionsTests
    {
        private const float Epsilon = 0.0001f;

        [Test]
        public void AngleTo_ShouldReturnCorrectAngle()
        {
            // Arrange
            Vector2 from = new Vector2(1, 0);
            Vector2 to = new Vector2(0, 1);
            float expected = 90f;

            // Act
            float result = from.AngleTo(to);

            // Assert
            Assert.AreEqual(expected, result, Epsilon);
        }

        [Test]
        public void ClampMagnitudeTo_ShouldCorrectlyClampVector()
        {
            // Arrange
            Vector2 source = new Vector2(3, 4); // Magnitude 5
            float maxLength = 2.5f;
            Vector2 expected = source.normalized * maxLength;

            // Act
            Vector2 result = source.ClampMagnitudeTo(maxLength);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
            Assert.AreEqual(maxLength, result.magnitude, Epsilon);
        }

        [Test]
        public void DistanceTo_ShouldReturnCorrectDistance()
        {
            // Arrange
            Vector2 from = new Vector2(1, 1);
            Vector2 to = new Vector2(4, 5);
            float expected = 5f; // Distance from (1,1) to (4,5) is 5

            // Act
            float result = from.DistanceTo(to);

            // Assert
            Assert.AreEqual(expected, result, Epsilon);
        }

        [Test]
        public void DotTo_ShouldReturnCorrectDotProduct()
        {
            // Arrange
            Vector2 lhs = new Vector2(2, 3);
            Vector2 rhs = new Vector2(4, 5);
            float expected = 2 * 4 + 3 * 5; // 8 + 15 = 23

            // Act
            float result = lhs.DotTo(rhs);

            // Assert
            Assert.AreEqual(expected, result, Epsilon);
        }

        [Test]
        public void LerpTo_ShouldCorrectlyInterpolate()
        {
            // Arrange
            Vector2 a = new Vector2(0, 0);
            Vector2 b = new Vector2(10, 20);
            float t = 0.3f;
            Vector2 expected = new Vector2(3, 6);

            // Act
            Vector2 result = a.LerpTo(b, t);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
        }

        [Test]
        public void LerpUnclampedTo_ShouldCorrectlyInterpolateWithoutClamping()
        {
            // Arrange
            Vector2 a = new Vector2(0, 0);
            Vector2 b = new Vector2(10, 20);
            float t = 1.5f; // Beyond the [0,1] range
            Vector2 expected = new Vector2(15, 30);

            // Act
            Vector2 result = a.LerpUnclampedTo(b, t);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
        }

        [Test]
        public void MaxTo_ShouldReturnVectorWithLargestComponents()
        {
            // Arrange
            Vector2 lhs = new Vector2(5, 2);
            Vector2 rhs = new Vector2(3, 7);
            Vector2 expected = new Vector2(5, 7);

            // Act
            Vector2 result = lhs.MaxTo(rhs);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
        }

        [Test]
        public void MinTo_ShouldReturnVectorWithSmallestComponents()
        {
            // Arrange
            Vector2 lhs = new Vector2(5, 2);
            Vector2 rhs = new Vector2(3, 7);
            Vector2 expected = new Vector2(3, 2);

            // Act
            Vector2 result = lhs.MinTo(rhs);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
        }

        [Test]
        public void PerpendicularTo_ShouldReturnPerpendicularVector()
        {
            // Arrange
            Vector2 inDirection = new Vector2(3, 4);
            Vector2 expected = new Vector2(-4, 3); // Unity's Perpendicular rotates 90° counter-clockwise

            // Act
            Vector2 result = inDirection.PerpendicularTo();

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);

            // Additional check: perpendicular vectors have dot product of 0
            Assert.AreEqual(0f, Vector2.Dot(inDirection, result), Epsilon);
        }

        [Test]
        public void ReflectTo_ShouldCorrectlyReflectVector()
        {
            // Arrange
            Vector2 inDirection = new Vector2(1, -1);
            Vector2 inNormal = new Vector2(0, 1).normalized;
            Vector2 expected = new Vector2(1, 1); // Reflection around horizontal surface

            // Act
            Vector2 result = inDirection.ReflectTo(inNormal);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
        }

        [Test]
        public void ScaleTo_ShouldCorrectlyScaleComponents()
        {
            // Arrange
            Vector2 lhs = new Vector2(2, 3);
            Vector2 rhs = new Vector2(4, 5);
            Vector2 expected = new Vector2(2 * 4, 3 * 5); // (8, 15)

            // Act
            Vector2 result = lhs.ScaleTo(rhs);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
        }

        [Test]
        public void SignedAngleTo_ShouldReturnCorrectSignedAngle()
        {
            // Arrange
            Vector2 from = new Vector2(1, 0);
            Vector2 to = new Vector2(0, 1);
            float expected = 90f; // Counter-clockwise is positive

            // Act
            float result = from.SignedAngleTo(to);

            // Assert
            Assert.AreEqual(expected, result, Epsilon);

            // Counter test (clockwise is negative)
            result = to.SignedAngleTo(from);
            Assert.AreEqual(-90f, result, Epsilon);
        }

        [Test]
        public void ShorterLengthThan_ShouldReturnCorrectComparison()
        {
            // Arrange
            Vector2 shorter = new Vector2(1, 2); // Length √5
            Vector2 longer = new Vector2(3, 4);  // Length 5

            // Act & Assert
            Assert.IsTrue(shorter.IsShorterLengthThan(longer));
            Assert.IsFalse(longer.IsShorterLengthThan(shorter));
            Assert.IsFalse(shorter.IsShorterLengthThan(shorter)); // Same vector
        }

        [Test]
        public void LongerLengthThan_ShouldReturnCorrectComparison()
        {
            // Arrange
            Vector2 shorter = new Vector2(1, 2); // Length √5
            Vector2 longer = new Vector2(3, 4);  // Length 5

            // Act & Assert
            Assert.IsTrue(longer.IsLongerLengthThan(shorter));
            Assert.IsFalse(shorter.IsLongerLengthThan(longer));
            Assert.IsFalse(shorter.IsLongerLengthThan(shorter)); // Same vector
        }

        [Test]
        public void SameLengthAs_ShouldReturnCorrectComparison()
        {
            // Arrange
            Vector2 v1 = new Vector2(3, 4);  // Length 5
            Vector2 v2 = new Vector2(5, 0);  // Length 5
            Vector2 v3 = new Vector2(1, 1);  // Different length

            // Act & Assert
            Assert.IsTrue(v1.IsSameLengthAs(v2));
            Assert.IsTrue(v2.IsSameLengthAs(v1));
            Assert.IsFalse(v1.IsSameLengthAs(v3));
        }

        [Test]
        public void DirectionTo_ShouldReturnCorrectDirection()
        {
            // Arrange
            Vector2 origin = new Vector2(1, 1);
            Vector2 destination = new Vector2(4, 6);
            Vector2 expected = new Vector2(3, 5);

            // Act
            Vector2 result = origin.DirectionTo(destination);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
        }

        [Test]
        public void DirectionNormalizedTo_ShouldReturnNormalizedDirection()
        {
            // Arrange
            Vector2 origin = new Vector2(1, 1);
            Vector2 destination = new Vector2(4, 6);
            Vector2 direction = new Vector2(3, 5);
            Vector2 expected = direction.normalized;

            // Act
            Vector2 result = origin.DirectionNormalizedTo(destination);

            // Assert
            Assert.AreEqual(expected.x, result.x, Epsilon);
            Assert.AreEqual(expected.y, result.y, Epsilon);
            Assert.AreEqual(1f, result.magnitude, Epsilon);
        }

        [Test]
        public void RoundToInt_ShouldCorrectlyRoundToIntegerVector()
        {
            // Arrange
            Vector2 vector = new Vector2(3.4f, 5.7f);
            Vector2Int expected = new Vector2Int(3, 6);

            // Act
            Vector2Int result = vector.RoundToInt();

            // Assert
            Assert.AreEqual(expected.x, result.x);
            Assert.AreEqual(expected.y, result.y);
        }

        [Test]
        public void CeilToInt_ShouldCorrectlyCeilToIntegerVector()
        {
            // Arrange
            Vector2 vector = new Vector2(3.1f, 5.7f);
            Vector2Int expected = new Vector2Int(4, 6);

            // Act
            Vector2Int result = vector.CeilToInt();

            // Assert
            Assert.AreEqual(expected.x, result.x);
            Assert.AreEqual(expected.y, result.y);
        }

        [Test]
        public void FloorToInt_ShouldCorrectlyFloorToIntegerVector()
        {
            // Arrange
            Vector2 vector = new Vector2(3.9f, 5.2f);
            Vector2Int expected = new Vector2Int(3, 5);

            // Act
            Vector2Int result = vector.FloorToInt();

            // Assert
            Assert.AreEqual(expected.x, result.x);
            Assert.AreEqual(expected.y, result.y);
        }
    }
}