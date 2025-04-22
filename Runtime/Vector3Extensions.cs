using System.Runtime.CompilerServices;

namespace Jyodann.VectorExtensions.Vector3Ex
{
    public static class Vector3Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AngleTo(this UnityEngine.Vector3 from, UnityEngine.Vector3 to)
        {
            return UnityEngine.Vector3.Angle(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 ClampMagnitudeTo(this UnityEngine.Vector3 source, float maxLength)
        {
            return UnityEngine.Vector3.ClampMagnitude(source, maxLength);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 CrossTo(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return UnityEngine.Vector3.Cross(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceTo(this UnityEngine.Vector3 from, UnityEngine.Vector3 to)
        {
            return UnityEngine.Vector3.Distance(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DotTo(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return UnityEngine.Vector3.Dot(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 LerpTo(this UnityEngine.Vector3 a, UnityEngine.Vector3 b, float t)
        {
            return UnityEngine.Vector3.Lerp(a, b, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 LerpUnclampedTo(this UnityEngine.Vector3 a, UnityEngine.Vector3 b, float t)
        {
            return UnityEngine.Vector3.LerpUnclamped(a, b, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 MaxTo(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return UnityEngine.Vector3.Max(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 MinTo(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return UnityEngine.Vector3.Min(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 ProjectTo(this UnityEngine.Vector3 vector, UnityEngine.Vector3 onNormal)
        {
            return UnityEngine.Vector3.Project(vector, onNormal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 ProjectOnPlaneTo(this UnityEngine.Vector3 vector, UnityEngine.Vector3 planeNormal)
        {
            return UnityEngine.Vector3.ProjectOnPlane(vector, planeNormal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 ReflectTo(this UnityEngine.Vector3 inDirection, UnityEngine.Vector3 inNormal)
        {
            return UnityEngine.Vector3.Reflect(inDirection, inNormal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 ScaleTo(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return UnityEngine.Vector3.Scale(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SignedAngleTo(this UnityEngine.Vector3 from, UnityEngine.Vector3 to, UnityEngine.Vector3 axis)
        {
            return UnityEngine.Vector3.SignedAngle(from, to, axis);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsShorterLengthThan(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return lhs.sqrMagnitude < rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLongerLengthThan(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return lhs.sqrMagnitude > rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameLengthAs(this UnityEngine.Vector3 lhs, UnityEngine.Vector3 rhs)
        {
            return lhs.sqrMagnitude == rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 Direction(UnityEngine.Vector3 origin, UnityEngine.Vector3 destination)
        {
            return destination - origin;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 DirectionNormalized(UnityEngine.Vector3 origin, UnityEngine.Vector3 destination)
        {
            return (destination - origin).normalized;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 DirectionTo(this UnityEngine.Vector3 origin, UnityEngine.Vector3 destination)
        {
            return Direction(origin, destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3 DirectionNormalizedTo(this UnityEngine.Vector3 origin, UnityEngine.Vector3 destination)
        {
            return DirectionNormalized(origin, destination);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3Int RoundToInt(this UnityEngine.Vector3 vector)
        {
            return UnityEngine.Vector3Int.RoundToInt(vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3Int CeilToInt(this UnityEngine.Vector3 vector)
        {
            return UnityEngine.Vector3Int.CeilToInt(vector);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3Int FloorToInt(this UnityEngine.Vector3 vector)
        {
            return UnityEngine.Vector3Int.FloorToInt(vector);
        }
    }
}