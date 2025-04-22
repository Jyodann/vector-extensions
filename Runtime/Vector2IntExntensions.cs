using System.Runtime.CompilerServices;

namespace Jyodann.VectorExtensions.Vector2IntEx
{
    public static class Vector2IntExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceTo(this UnityEngine.Vector2Int from, UnityEngine.Vector2Int to)
        {
            return UnityEngine.Vector2Int.Distance(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2Int MaxTo(this UnityEngine.Vector2Int lhs, UnityEngine.Vector2Int rhs)
        {
            return UnityEngine.Vector2Int.Max(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2Int MinTo(this UnityEngine.Vector2Int lhs, UnityEngine.Vector2Int rhs)
        {
            return UnityEngine.Vector2Int.Min(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector2Int ScaleTo(this UnityEngine.Vector2Int lhs, UnityEngine.Vector2Int rhs)
        {
            return UnityEngine.Vector2Int.Scale(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsShorterLengthThan(this UnityEngine.Vector2Int lhs, UnityEngine.Vector2Int rhs)
        {
            return lhs.sqrMagnitude < rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLongerLengthThan(this UnityEngine.Vector2Int lhs, UnityEngine.Vector2Int rhs)
        {
            return lhs.sqrMagnitude > rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameLengthAs(this UnityEngine.Vector2Int lhs, UnityEngine.Vector2Int rhs)
        {
            return lhs.sqrMagnitude == rhs.sqrMagnitude;
        }
    }
}