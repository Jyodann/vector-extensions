using System.Runtime.CompilerServices;

namespace Jyodann.VectorExtensions.Vector2Ex
{
    public static class Vector2Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleTo(this UnityEngine.Vector2 from, UnityEngine.Vector2 to)
        {
            return UnityEngine.Vector2.Angle(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 ClampMagnitudeTo(this UnityEngine.Vector2 source, float maxLength)
        {
            return UnityEngine.Vector2.ClampMagnitude(source, maxLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceTo(this UnityEngine.Vector2 from, UnityEngine.Vector2 to)
        {
            return UnityEngine.Vector2.Distance(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DotTo(this UnityEngine.Vector2 lhs, UnityEngine.Vector2 rhs)
        {
            return UnityEngine.Vector2.Dot(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 LerpTo(this UnityEngine.Vector2 a, UnityEngine.Vector2 b, float t)
        {
            return UnityEngine.Vector2.Lerp(a, b, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 LerpUnclampedTo(this UnityEngine.Vector2 a, UnityEngine.Vector2 b, float t)
        {
            return UnityEngine.Vector2.LerpUnclamped(a, b, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 MaxTo(this UnityEngine.Vector2 lhs, UnityEngine.Vector2 rhs)
        {
            return UnityEngine.Vector2.Max(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 MinTo(this UnityEngine.Vector2 lhs, UnityEngine.Vector2 rhs)
        {
            return UnityEngine.Vector2.Min(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 PerpendicularTo(this UnityEngine.Vector2 inDirection)
        {
            return UnityEngine.Vector2.Perpendicular(inDirection);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 ReflectTo(this UnityEngine.Vector2 inDirection, UnityEngine.Vector2 inNormal)
        {
            return UnityEngine.Vector2.Reflect(inDirection, inNormal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 ScaleTo(this UnityEngine.Vector2 lhs, UnityEngine.Vector2 rhs)
        {
            return UnityEngine.Vector2.Scale(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SignedAngleTo(this UnityEngine.Vector2 from, UnityEngine.Vector2 to)
        {
            return UnityEngine.Vector2.SignedAngle(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsShorterLengthThan(this UnityEngine.Vector2 lhs, UnityEngine.Vector2 rhs)
        {
            return lhs.sqrMagnitude < rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLongerLengthThan(this UnityEngine.Vector2 lhs, UnityEngine.Vector2 rhs)
        {
            return lhs.sqrMagnitude > rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameLengthAs(this UnityEngine.Vector2 lhs, UnityEngine.Vector2 rhs)
        {
            return lhs.sqrMagnitude == rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 Direction(UnityEngine.Vector2 origin, UnityEngine.Vector2 destination)
        {
            return destination - origin;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 DirectionNormalized(UnityEngine.Vector2 origin, UnityEngine.Vector2 destination)
        {
            return (destination - origin).normalized;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 DirectionTo(this UnityEngine.Vector2 origin, UnityEngine.Vector2 destination)
        {
            return Direction(origin, destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2 DirectionNormalizedTo(this UnityEngine.Vector2 origin, UnityEngine.Vector2 destination)
        {
            return DirectionNormalized(origin, destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2Int RoundToInt(this UnityEngine.Vector2 vector)
        {
            return UnityEngine.Vector2Int.RoundToInt(vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2Int CeilToInt(this UnityEngine.Vector2 vector)
        {
            return UnityEngine.Vector2Int.CeilToInt(vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2Int FloorToInt(this UnityEngine.Vector2 vector)
        {
            return UnityEngine.Vector2Int.FloorToInt(vector);
        }
    }
}