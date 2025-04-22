using System.Runtime.CompilerServices;

namespace Jyodann.VectorExtensions.Vector3IntEx
{
    public static class Vector3IntExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DistanceTo(this UnityEngine.Vector3Int from, UnityEngine.Vector3Int to)
        {
            return UnityEngine.Vector3Int.Distance(from, to);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3Int MaxTo(this UnityEngine.Vector3Int lhs, UnityEngine.Vector3Int rhs)
        {
            return UnityEngine.Vector3Int.Max(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3Int MinTo(this UnityEngine.Vector3Int lhs, UnityEngine.Vector3Int rhs)
        {
            return UnityEngine.Vector3Int.Min(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityEngine.Vector3Int ScaleTo(this UnityEngine.Vector3Int lhs, UnityEngine.Vector3Int rhs)
        {
            return UnityEngine.Vector3Int.Scale(lhs, rhs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsShorterLengthThan(this UnityEngine.Vector3Int lhs, UnityEngine.Vector3Int rhs)
        {
            return lhs.sqrMagnitude < rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLongerLengthThan(this UnityEngine.Vector3Int lhs, UnityEngine.Vector3Int rhs)
        {
            return lhs.sqrMagnitude > rhs.sqrMagnitude;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSameLengthAs(this UnityEngine.Vector3Int lhs, UnityEngine.Vector3Int rhs)
        {
            return lhs.sqrMagnitude == rhs.sqrMagnitude;
        }
    }
}