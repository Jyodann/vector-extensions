using UnityEngine;
using NUnit.Framework;
using Jyodann.VectorExtensions.Vector2IntEx;

namespace Jyodann.VectorExtensions.Vector2IntTests
{
    [TestFixture]
    public class Vector2IntExtensionsTests
    {
        // Floating point comparisons need a tolerance
        private const float Tolerance = 0.0001f;

        // --- Test Cases for DistanceTo ---

        [Test]
        public void DistanceTo_ZeroVectors_ReturnsZero()
        {
            // Arrange
            Vector2Int from = Vector2Int.zero;
            Vector2Int to = Vector2Int.zero;

            // Act
            float distance = from.DistanceTo(to);

            // Assert
            Assert.AreEqual(0f, distance, Tolerance);
        }

        [Test]
        public void DistanceTo_PositiveVectors_CalculatesCorrectDistance()
        {
            // Arrange
            Vector2Int from = new Vector2Int(1, 2);
            Vector2Int to = new Vector2Int(4, 6); // Difference is (3, 4)
            float expectedDistance = 5.0f; // Sqrt(3^2 + 4^2) = Sqrt(9 + 16) = Sqrt(25) = 5

            // Act
            float distance = from.DistanceTo(to);

            // Assert
            Assert.AreEqual(expectedDistance, distance, Tolerance);
        }

        [Test]
        public void DistanceTo_MixedSignVectors_CalculatesCorrectDistance()
        {
            // Arrange
            Vector2Int from = new Vector2Int(-1, -1);
            Vector2Int to = new Vector2Int(2, 3); // Difference is (3, 4)
            float expectedDistance = 5.0f;

            // Act
            float distance = from.DistanceTo(to);

            // Assert
            Assert.AreEqual(expectedDistance, distance, Tolerance);
        }

        // --- Test Cases for MaxTo ---

        [Test]
        public void MaxTo_ReturnsComponentWiseMaximum()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(1, 5);
            Vector2Int rhs = new Vector2Int(3, 2);
            Vector2Int expected = new Vector2Int(3, 5);

            // Act
            Vector2Int result = lhs.MaxTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxTo_WithNegativeNumbers_ReturnsComponentWiseMaximum()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(-1, -5);
            Vector2Int rhs = new Vector2Int(-3, -2);
            Vector2Int expected = new Vector2Int(-1, -2);

            // Act
            Vector2Int result = lhs.MaxTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MaxTo_WithIdenticalVectors_ReturnsSameVector()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(10, -10);
            Vector2Int rhs = new Vector2Int(10, -10);
            Vector2Int expected = new Vector2Int(10, -10);

            // Act
            Vector2Int result = lhs.MaxTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // --- Test Cases for MinTo ---

        [Test]
        public void MinTo_ReturnsComponentWiseMinimum()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(1, 5);
            Vector2Int rhs = new Vector2Int(3, 2);
            Vector2Int expected = new Vector2Int(1, 2);

            // Act
            Vector2Int result = lhs.MinTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MinTo_WithNegativeNumbers_ReturnsComponentWiseMinimum()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(-1, -5);
            Vector2Int rhs = new Vector2Int(-3, -2);
            Vector2Int expected = new Vector2Int(-3, -5);

            // Act
            Vector2Int result = lhs.MinTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MinTo_WithIdenticalVectors_ReturnsSameVector()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(10, -10);
            Vector2Int rhs = new Vector2Int(10, -10);
            Vector2Int expected = new Vector2Int(10, -10);

            // Act
            Vector2Int result = lhs.MinTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // --- Test Cases for ScaleTo ---

        [Test]
        public void ScaleTo_PerformsComponentWiseMultiplication()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(2, 3);
            Vector2Int rhs = new Vector2Int(4, 5);
            Vector2Int expected = new Vector2Int(8, 15);

            // Act
            Vector2Int result = lhs.ScaleTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ScaleTo_WithNegativeNumbers_PerformsComponentWiseMultiplication()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(-2, 3);
            Vector2Int rhs = new Vector2Int(4, -5);
            Vector2Int expected = new Vector2Int(-8, -15);

            // Act
            Vector2Int result = lhs.ScaleTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ScaleTo_WithZero_ReturnsZeroVector()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(2, 3);
            Vector2Int rhs = Vector2Int.zero;
            Vector2Int expected = Vector2Int.zero;

            // Act
            Vector2Int result = lhs.ScaleTo(rhs);

            // Assert
            Assert.AreEqual(expected, result);
        }

        // --- Test Cases for ShorterLengthThan ---

        [Test]
        public void ShorterLengthThan_LhsShorter_ReturnsTrue()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(1, 1); // sqrMag = 2
            Vector2Int rhs = new Vector2Int(2, 2); // sqrMag = 8

            // Act
            bool result = lhs.IsShorterLengthThan(rhs);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ShorterLengthThan_LhsLonger_ReturnsFalse()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(3, 0); // sqrMag = 9
            Vector2Int rhs = new Vector2Int(2, 2); // sqrMag = 8

            // Act
            bool result = lhs.IsShorterLengthThan(rhs);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ShorterLengthThan_SameLength_ReturnsFalse()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(3, 4); // sqrMag = 25
            Vector2Int rhs = new Vector2Int(5, 0); // sqrMag = 25

            // Act
            bool result = lhs.IsShorterLengthThan(rhs);

            // Assert
            Assert.IsFalse(result);
        }

        // --- Test Cases for LongerLengthThan ---

        [Test]
        public void LongerLengthThan_LhsLonger_ReturnsTrue()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(3, 0); // sqrMag = 9
            Vector2Int rhs = new Vector2Int(2, 2); // sqrMag = 8

            // Act
            bool result = lhs.IsLongerLengthThan(rhs);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void LongerLengthThan_LhsShorter_ReturnsFalse()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(1, 1); // sqrMag = 2
            Vector2Int rhs = new Vector2Int(2, 2); // sqrMag = 8

            // Act
            bool result = lhs.IsLongerLengthThan(rhs);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void LongerLengthThan_SameLength_ReturnsFalse()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(3, 4); // sqrMag = 25
            Vector2Int rhs = new Vector2Int(0, 5); // sqrMag = 25

            // Act
            bool result = lhs.IsLongerLengthThan(rhs);

            // Assert
            Assert.IsFalse(result);
        }

        // --- Test Cases for SameLengthAs ---

        [Test]
        public void SameLengthAs_SameLength_ReturnsTrue()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(3, 4); // sqrMag = 25
            Vector2Int rhs = new Vector2Int(-5, 0); // sqrMag = 25

            // Act
            bool result = lhs.IsSameLengthAs(rhs);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void SameLengthAs_DifferentLength_ReturnsFalse()
        {
            // Arrange
            Vector2Int lhs = new Vector2Int(1, 1); // sqrMag = 2
            Vector2Int rhs = new Vector2Int(2, 2); // sqrMag = 8

            // Act
            bool result = lhs.IsSameLengthAs(rhs);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void SameLengthAs_BothZero_ReturnsTrue()
        {
            // Arrange
            Vector2Int lhs = Vector2Int.zero; // sqrMag = 0
            Vector2Int rhs = Vector2Int.zero; // sqrMag = 0

            // Act
            bool result = lhs.IsSameLengthAs(rhs);

            // Assert
            Assert.IsTrue(result);
        }
    }
}