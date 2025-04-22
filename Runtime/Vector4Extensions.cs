using System.Runtime.CompilerServices;

namespace Jyodann.VectorExtensions.Vector4Ex
{
    public static class Vector4Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceTo(this UnityEngine.Vector4 from, UnityEngine.Vector4 to)
        {
            return UnityEngine.Vector4.Distance(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DotTo(this UnityEngine.Vector4 lhs, UnityEngine.Vector4 rhs)
        {
            return UnityEngine.Vector4.Dot(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector4 LerpTo(this UnityEngine.Vector4 a, UnityEngine.Vector4 b, float t)
        {
            return UnityEngine.Vector4.Lerp(a, b, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector4 LerpUnclampedTo(this UnityEngine.Vector4 a, UnityEngine.Vector4 b, float t)
        {
            return UnityEngine.Vector4.LerpUnclamped(a, b, t);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector4 MaxTo(this UnityEngine.Vector4 lhs, UnityEngine.Vector4 rhs)
        {
            return UnityEngine.Vector4.Max(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector4 MinTo(this UnityEngine.Vector4 lhs, UnityEngine.Vector4 rhs)
        {
            return UnityEngine.Vector4.Min(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector4 ProjectTo(this UnityEngine.Vector4 vector, UnityEngine.Vector4 onNormal)
        {
            return UnityEngine.Vector4.Project(vector, onNormal);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector4 ScaleTo(this UnityEngine.Vector4 lhs, UnityEngine.Vector4 rhs)
        {
            return UnityEngine.Vector4.Scale(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsShorterLengthThan(this UnityEngine.Vector4 lhs, UnityEngine.Vector4 rhs)
        {
            return lhs.sqrMagnitude < rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLongerLengthThan(this UnityEngine.Vector4 lhs, UnityEngine.Vector4 rhs)
        {
            return lhs.sqrMagnitude > rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameLengthAs(this UnityEngine.Vector4 lhs, UnityEngine.Vector4 rhs)
        {
            return lhs.sqrMagnitude == rhs.sqrMagnitude;
        }
    }
}