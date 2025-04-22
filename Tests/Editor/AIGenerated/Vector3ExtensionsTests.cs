using UnityEngine;
using NUnit.Framework;
using Jyodann.VectorExtensions.Vector3Ex;

namespace Jyodann.VectorExtensions.Vector3Tests
{
    [TestFixture]
    public class Vector3ExtensionsTests
    {
        // Floating point comparisons need a tolerance
        private const float Tolerance = 0.0001f;

        // Helper for comparing Vector3 with tolerance
        private static void AssertAreApproximatelyEqual(Vector3 expected, Vector3 actual, float tolerance)
        {
            Assert.AreEqual(expected.x, actual.x, tolerance, $"X component mismatch. Expected: {expected.x}, Got: {actual.x}");
            Assert.AreEqual(expected.y, actual.y, tolerance, $"Y component mismatch. Expected: {expected.y}, Got: {actual.y}");
            Assert.AreEqual(expected.z, actual.z, tolerance, $"Z component mismatch. Expected: {expected.z}, Got: {actual.z}");
        }

        // --- Test Cases for AngleTo ---
        [Test]
        public void AngleTo_ParallelVectors_ReturnsZero() => Assert.AreEqual(0f, Vector3.right.AngleTo(Vector3.right), Tolerance);

        [Test]
        public void AngleTo_OppositeVectors_Returns180() => Assert.AreEqual(180f, Vector3.right.AngleTo(Vector3.left), Tolerance);

        [Test]
        public void AngleTo_PerpendicularVectors_Returns90() => Assert.AreEqual(90f, Vector3.right.AngleTo(Vector3.up), Tolerance);

        [Test]
        public void AngleTo_SpecificAngle_ReturnsCorrectAngle() => Assert.AreEqual(45f, Vector3.right.AngleTo(new Vector3(1, 1, 0)), Tolerance);

        // --- Test Cases for ClampMagnitudeTo ---
        [Test]
        public void ClampMagnitudeTo_VectorShorterThanMax_ReturnsOriginal()
        {
            Vector3 source = new Vector3(1, 1, 1); // Magnitude ~1.732
            float maxLength = 5f;
            Vector3 result = source.ClampMagnitudeTo(maxLength);
            AssertAreApproximatelyEqual(source, result, Tolerance);
            Assert.LessOrEqual(result.magnitude, maxLength);
        }

        [Test]
        public void ClampMagnitudeTo_VectorLongerThanMax_ReturnsClamped()
        {
            Vector3 source = new Vector3(3, 4, 0); // Magnitude 5
            float maxLength = 2.5f;
            Vector3 expected = source.normalized * maxLength;
            Vector3 result = source.ClampMagnitudeTo(maxLength);
            AssertAreApproximatelyEqual(expected, result, Tolerance);
            Assert.AreEqual(maxLength, result.magnitude, Tolerance);
        }

        [Test]
        public void ClampMagnitudeTo_ZeroVector_ReturnsZero() => AssertAreApproximatelyEqual(Vector3.zero, Vector3.zero.ClampMagnitudeTo(5f), Tolerance);

        [Test]
        public void ClampMagnitudeTo_ZeroMaxLength_ReturnsZero() => AssertAreApproximatelyEqual(Vector3.zero, new Vector3(1, 2, 3).ClampMagnitudeTo(0f), Tolerance);

        // --- Test Cases for CrossTo ---
        [Test]
        public void CrossTo_StandardBasis_ReturnsCorrectAxis()
        {
            AssertAreApproximatelyEqual(Vector3.forward, Vector3.right.CrossTo(Vector3.up), Tolerance); // i x j = k
            AssertAreApproximatelyEqual(Vector3.right, Vector3.up.CrossTo(Vector3.forward), Tolerance);    // j x k = i
            AssertAreApproximatelyEqual(Vector3.up, Vector3.forward.CrossTo(Vector3.right), Tolerance);   // k x i = j
        }

        [Test]
        public void CrossTo_ParallelVectors_ReturnsZero() => AssertAreApproximatelyEqual(Vector3.zero, Vector3.up.CrossTo(Vector3.up * 5), Tolerance);

        [Test]
        public void CrossTo_AntiParallelVectors_ReturnsZero() => AssertAreApproximatelyEqual(Vector3.zero, Vector3.up.CrossTo(Vector3.down * 5), Tolerance);

        // --- Test Cases for DistanceTo ---
        [Test]
        public void DistanceTo_SamePoint_ReturnsZero() => Assert.AreEqual(0f, Vector3.one.DistanceTo(Vector3.one), Tolerance);

        [Test]
        public void DistanceTo_AlongAxis_ReturnsCorrectDistance() => Assert.AreEqual(5f, Vector3.zero.DistanceTo(new Vector3(0, 5, 0)), Tolerance);

        [Test]
        public void DistanceTo_Diagonal_ReturnsCorrectDistance()
        {
            Vector3 from = new Vector3(1, 1, 1);
            Vector3 to = new Vector3(4, 5, 1); // Diff (3, 4, 0) -> Dist 5
            Assert.AreEqual(5f, from.DistanceTo(to), Tolerance);
        }

        // --- Test Cases for DotTo ---
        [Test]
        public void DotTo_ParallelVectors_ReturnsProductOfMagnitudes() => Assert.AreEqual(15f, (Vector3.right * 3).DotTo(Vector3.right * 5), Tolerance);

        [Test]
        public void DotTo_OppositeVectors_ReturnsNegativeProductOfMagnitudes() => Assert.AreEqual(-15f, (Vector3.right * 3).DotTo(Vector3.left * 5), Tolerance);

        [Test]
        public void DotTo_PerpendicularVectors_ReturnsZero() => Assert.AreEqual(0f, Vector3.right.DotTo(Vector3.up), Tolerance);

        [Test]
        public void DotTo_GeneralVectors_ReturnsCorrectDotProduct() => Assert.AreEqual(23f, new Vector3(1, 2, 3).DotTo(new Vector3(4, 5, 3)), Tolerance); // 1*4 + 2*5 + 3*3 = 4 + 10 + 9 = 23

        // --- Test Cases for LerpTo ---
        [Test]
        public void LerpTo_TZero_ReturnsStart() => AssertAreApproximatelyEqual(Vector3.right, Vector3.right.LerpTo(Vector3.up, 0f), Tolerance);

        [Test]
        public void LerpTo_TOne_ReturnsEnd() => AssertAreApproximatelyEqual(Vector3.up, Vector3.right.LerpTo(Vector3.up, 1f), Tolerance);

        [Test]
        public void LerpTo_THalf_ReturnsMidpoint() => AssertAreApproximatelyEqual(new Vector3(0.5f, 0.5f, 0f), Vector3.right.LerpTo(Vector3.up, 0.5f), Tolerance);

        [Test]
        public void LerpTo_TNegative_ClampsToStart() => AssertAreApproximatelyEqual(Vector3.right, Vector3.right.LerpTo(Vector3.up, -0.5f), Tolerance);

        [Test]
        public void LerpTo_TGreaterThanOne_ClampsToEnd() => AssertAreApproximatelyEqual(Vector3.up, Vector3.right.LerpTo(Vector3.up, 1.5f), Tolerance);

        // --- Test Cases for LerpUnclampedTo ---
        [Test]
        public void LerpUnclampedTo_TZero_ReturnsStart() => AssertAreApproximatelyEqual(Vector3.right, Vector3.right.LerpUnclampedTo(Vector3.up, 0f), Tolerance);

        [Test]
        public void LerpUnclampedTo_TOne_ReturnsEnd() => AssertAreApproximatelyEqual(Vector3.up, Vector3.right.LerpUnclampedTo(Vector3.up, 1f), Tolerance);

        [Test]
        public void LerpUnclampedTo_THalf_ReturnsMidpoint() => AssertAreApproximatelyEqual(new Vector3(0.5f, 0.5f, 0f), Vector3.right.LerpUnclampedTo(Vector3.up, 0.5f), Tolerance);

        [Test]
        public void LerpUnclampedTo_TNegative_ExtrapolatesBeforeStart() => AssertAreApproximatelyEqual(new Vector3(1.5f, -0.5f, 0f), Vector3.right.LerpUnclampedTo(Vector3.up, -0.5f), Tolerance); // right + (-0.5 * (up - right)) = (1,0,0) + (-0.5 * (-1,1,0)) = (1,0,0) + (0.5, -0.5, 0)

        [Test]
        public void LerpUnclampedTo_TGreaterThanOne_ExtrapolatesBeyondEnd() => AssertAreApproximatelyEqual(new Vector3(-0.5f, 1.5f, 0f), Vector3.right.LerpUnclampedTo(Vector3.up, 1.5f), Tolerance); // right + (1.5 * (up - right)) = (1,0,0) + (1.5 * (-1,1,0)) = (1,0,0) + (-1.5, 1.5, 0)

        // --- Test Cases for MaxTo ---
        [Test]
        public void MaxTo_ReturnsComponentWiseMaximum() => Assert.AreEqual(new Vector3(3, 5, 1), new Vector3(1, 5, 0).MaxTo(new Vector3(3, 2, 1)));

        [Test]
        public void MaxTo_WithNegativeNumbers_ReturnsComponentWiseMaximum() => Assert.AreEqual(new Vector3(-1, -2, 0), new Vector3(-1, -5, -1).MaxTo(new Vector3(-3, -2, 0)));

        // --- Test Cases for MinTo ---
        [Test]
        public void MinTo_ReturnsComponentWiseMinimum() => Assert.AreEqual(new Vector3(1, 2, 0), new Vector3(1, 5, 1).MinTo(new Vector3(3, 2, 0)));

        [Test]
        public void MinTo_WithNegativeNumbers_ReturnsComponentWiseMinimum() => Assert.AreEqual(new Vector3(-3, -5, -1), new Vector3(-1, -5, 0).MinTo(new Vector3(-3, -2, -1)));

        // --- Test Cases for ProjectTo ---
        [Test]
        public void ProjectTo_OntoAxis_ReturnsCorrectProjection() => AssertAreApproximatelyEqual(new Vector3(5, 0, 0), new Vector3(5, 3, 4).ProjectTo(Vector3.right), Tolerance);

        [Test]
        public void ProjectTo_ParallelVector_ReturnsOriginalVector() => AssertAreApproximatelyEqual(Vector3.up * 5, (Vector3.up * 5).ProjectTo(Vector3.up), Tolerance);

        [Test]
        public void ProjectTo_PerpendicularVector_ReturnsZero() => AssertAreApproximatelyEqual(Vector3.zero, Vector3.right.ProjectTo(Vector3.up), Tolerance);

        // --- Test Cases for ProjectOnPlaneTo ---
        [Test]
        public void ProjectOnPlaneTo_OntoXYPlane_RemovesZComponent() => AssertAreApproximatelyEqual(new Vector3(1, 2, 0), new Vector3(1, 2, 3).ProjectOnPlaneTo(Vector3.forward), Tolerance);

        [Test]
        public void ProjectOnPlaneTo_VectorOnPlane_ReturnsOriginalVector() => AssertAreApproximatelyEqual(Vector3.right, Vector3.right.ProjectOnPlaneTo(Vector3.forward), Tolerance);

        [Test]
        public void ProjectOnPlaneTo_VectorParallelToNormal_ReturnsZero() => AssertAreApproximatelyEqual(Vector3.zero, Vector3.forward.ProjectOnPlaneTo(Vector3.forward), Tolerance);

        // --- Test Cases for ReflectTo ---
        [Test]
        public void ReflectTo_AcrossAxisPlane_ReturnsCorrectReflection() => AssertAreApproximatelyEqual(new Vector3(-1, 2, 3), new Vector3(1, 2, 3).ReflectTo(Vector3.right), Tolerance); // Reflect across YZ plane

        // --- Test Cases for ScaleTo ---
        [Test]
        public void ScaleTo_PerformsComponentWiseMultiplication() => Assert.AreEqual(new Vector3(8, 15, -2), new Vector3(2, 3, 1).ScaleTo(new Vector3(4, 5, -2)));

        [Test]
        public void ScaleTo_WithZero_ReturnsZeroVector() => Assert.AreEqual(Vector3.zero, new Vector3(2, 3, 4).ScaleTo(Vector3.zero));

        // --- Test Cases for SignedAngleTo ---
        [Test]
        public void SignedAngleTo_90DegCounterClockwise_ReturnsPositive90() => Assert.AreEqual(90f, Vector3.right.SignedAngleTo(Vector3.up, Vector3.forward), Tolerance); // Around +Z axis

        [Test]
        public void SignedAngleTo_90DegClockwise_ReturnsNegative90() => Assert.AreEqual(-90f, Vector3.right.SignedAngleTo(Vector3.down, Vector3.forward), Tolerance); // Around +Z axis

        [Test]
        public void SignedAngleTo_ParallelVectors_ReturnsZero() => Assert.AreEqual(0f, Vector3.right.SignedAngleTo(Vector3.right, Vector3.up), Tolerance);

        [Test]
        public void SignedAngleTo_OppositeVectors_Returns180() => Assert.AreEqual(180f, Vector3.right.SignedAngleTo(Vector3.left, Vector3.up), Tolerance);

        // --- Test Cases for ShorterLengthThan ---
        [Test] public void ShorterLengthThan_LhsShorter_ReturnsTrue() => Assert.IsTrue(new Vector3(1, 1, 1).IsShorterLengthThan(new Vector3(2, 2, 2))); // sqrt(3) vs sqrt(12)

        [Test] public void ShorterLengthThan_LhsLonger_ReturnsFalse() => Assert.IsFalse(new Vector3(3, 0, 0).IsShorterLengthThan(new Vector3(2, 2, 0))); // 3 vs sqrt(8)

        [Test] public void ShorterLengthThan_SameLength_ReturnsFalse() => Assert.IsFalse(new Vector3(3, 4, 0).IsShorterLengthThan(new Vector3(5, 0, 0))); // 5 vs 5

        // --- Test Cases for LongerLengthThan ---
        [Test] public void LongerLengthThan_LhsLonger_ReturnsTrue() => Assert.IsTrue(new Vector3(3, 0, 0).IsLongerLengthThan(new Vector3(2, 2, 0)));

        [Test] public void LongerLengthThan_LhsShorter_ReturnsFalse() => Assert.IsFalse(new Vector3(1, 1, 1).IsLongerLengthThan(new Vector3(2, 2, 2)));

        [Test] public void LongerLengthThan_SameLength_ReturnsFalse() => Assert.IsFalse(new Vector3(0, 0, 5).IsLongerLengthThan(new Vector3(3, 4, 0)));

        // --- Test Cases for SameLengthAs ---
        [Test] public void SameLengthAs_SameLength_ReturnsTrue() => Assert.IsTrue(new Vector3(3, 4, 0).IsSameLengthAs(new Vector3(0, 0, -5)));

        [Test] public void SameLengthAs_DifferentLength_ReturnsFalse() => Assert.IsFalse(new Vector3(1, 1, 1).IsSameLengthAs(new Vector3(2, 2, 2)));

        [Test] public void SameLengthAs_BothZero_ReturnsTrue() => Assert.IsTrue(Vector3.zero.IsSameLengthAs(Vector3.zero));

        // --- Test Cases for Direction (Static and Extension) ---
        [Test]
        public void Direction_CalculatesDifference()
        {
            Vector3 origin = new Vector3(1, 2, 3);
            Vector3 destination = new Vector3(5, 4, 0);
            Vector3 expected = new Vector3(4, 2, -3);
            Assert.AreEqual(expected, Vector3Extensions.Direction(origin, destination));
            Assert.AreEqual(expected, origin.DirectionTo(destination)); // Test extension method
        }

        // --- Test Cases for DirectionNormalized (Static and Extension) ---
        [Test]
        public void DirectionNormalized_CalculatesNormalizedDifference()
        {
            Vector3 origin = new Vector3(1, 1, 1);
            Vector3 destination = new Vector3(4, 1, 1); // Difference is (3, 0, 0)
            Vector3 expected = Vector3.right;
            Vector3 resultStatic = Vector3Extensions.DirectionNormalized(origin, destination);
            Vector3 resultExtension = origin.DirectionNormalizedTo(destination);

            AssertAreApproximatelyEqual(expected, resultStatic, Tolerance);
            Assert.AreEqual(1f, resultStatic.magnitude, Tolerance);

            AssertAreApproximatelyEqual(expected, resultExtension, Tolerance); // Test extension method
            Assert.AreEqual(1f, resultExtension.magnitude, Tolerance);
        }

        [Test]
        public void DirectionNormalized_ZeroDifference_ReturnsZero()
        {
            Vector3 origin = Vector3.one;
            Vector3 destination = Vector3.one;
            Vector3 expected = Vector3.zero;
            Vector3 resultStatic = Vector3Extensions.DirectionNormalized(origin, destination);
            Vector3 resultExtension = origin.DirectionNormalizedTo(destination);

            AssertAreApproximatelyEqual(expected, resultStatic, Tolerance);
            AssertAreApproximatelyEqual(expected, resultExtension, Tolerance);
        }

        // --- Test Cases for RoundToInt ---
        [Test] public void RoundToInt_RoundsCorrectly() => Assert.AreEqual(new Vector3Int(1, 2, -3), new Vector3(1.2f, 2.5f, -3.1f).RoundToInt());

        [Test] public void RoundToInt_NegativeHalfRoundsToEven() => Assert.AreEqual(new Vector3Int(0, -2, -2), new Vector3(-0.5f, -1.5f, -2.5f).RoundToInt()); // Note: Unity's RoundToInt rounds .5 to the nearest even integer

        // --- Test Cases for CeilToInt ---
        [Test] public void CeilToInt_CeilsCorrectly() => Assert.AreEqual(new Vector3Int(2, 3, -3), new Vector3(1.2f, 2.5f, -3.1f).CeilToInt());

        [Test] public void CeilToInt_IntegersUnchanged() => Assert.AreEqual(new Vector3Int(1, -2, 0), new Vector3(1f, -2f, 0f).CeilToInt());

        // --- Test Cases for FloorToInt ---
        [Test] public void FloorToInt_FloorsCorrectly() => Assert.AreEqual(new Vector3Int(1, 2, -4), new Vector3(1.2f, 2.5f, -3.1f).FloorToInt());

        [Test] public void FloorToInt_IntegersUnchanged() => Assert.AreEqual(new Vector3Int(1, -2, 0), new Vector3(1f, -2f, 0f).FloorToInt());
    }
}