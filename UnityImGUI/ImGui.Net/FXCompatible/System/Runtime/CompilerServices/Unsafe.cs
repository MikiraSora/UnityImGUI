using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;

namespace ImGuiNET.FXCompatible.System.Runtime.CompilerServices
{
    internal unsafe class Unsafe
    {
        public static ref T AsRef<T>(void* ptr)
        {
            return ref *((T*)ptr);
        }

        public static int SizeOf<T>()
        {
            return Marshal.SizeOf(typeof(T));
        }

        internal static void CopyBlock(byte* destination, byte* source, uint byteCount)
        {
            byte* dest = destination;
            byte* src = source;

            for (uint i = 0; i < byteCount; i++)
            {
                *(dest + i) = *(src + i);
            }
        }

        internal static void InitBlockUnaligned(byte* array, byte value, uint size)
        {
            byte* p = array;
            for (uint i = 0; i < size; i++)
                *(p + i) = value;
        }

        internal static T Read<T>(void* v)
        {
            return (T)Marshal.PtrToStructure(new IntPtr(v), typeof(T));
        }
    }
}
