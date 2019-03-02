using System.Collections.Generic;

namespace ArrayHashCodeEquality.Comparers
{
    public sealed class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
    {
        // You could make this a per-instance field with a constructor parameter
        private static readonly EqualityComparer<byte> elementComparer
            = EqualityComparer<byte>.Default;

        public bool Equals(byte[] first, byte[] second)
        {
            if (first == second)
            {
                return true;
            }
            if (first == null || second == null)
            {
                return false;
            }
            if (first.Length != second.Length)
            {
                return false;
            }
            for (int i = 0; i < first.Length; i++)
            {
                if (!elementComparer.Equals(first[i], second[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(byte[] array)
        {
            unchecked
            {
                if (array == null)
                {
                    return 0;
                }
                int hash = 17;
                foreach (byte element in array)
                {
                    hash = hash * 31 + elementComparer.GetHashCode(element);
                }
                return hash;
            }
        }
    }
}
