using System.Collections.Generic;

namespace ArrayHashCodeEquality.Comparers
{
    public sealed unsafe class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
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

            fixed(byte* ptFirst = first, ptSecond = second )
            {
                byte* ptFirstStart = ptFirst;
                byte* ptFirstEnd = ptFirst + first.Length;
                byte* ptSecondStart = ptSecond;

                while(ptFirstStart < ptFirstEnd)
                {
                    if(*ptFirst != *ptSecond)
                    {
                        return false;
                    }
                    ptFirstStart++;
                    ptSecondStart++;
                }
            }

            return true;
        }

        public unsafe int GetHashCode(byte[] array)
        {
            unchecked
            {
                if (array == null)
                {
                    return 0;
                }

                int hash = 17;

                fixed (byte* ptArrayt = array)
                {
                    byte* ptArraytStart = ptArrayt;
                    byte* ptArraytEnd = ptArrayt + array.Length;
                    
                    while(ptArraytStart < ptArraytEnd)
                    {
                        hash = hash * 31 + (*ptArraytStart).GetHashCode();
                        ptArraytStart++;
                    }
                }

                return hash;
            }
        }
    }
}
