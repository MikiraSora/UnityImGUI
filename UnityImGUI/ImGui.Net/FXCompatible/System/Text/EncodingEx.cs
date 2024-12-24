using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImGuiNET.FXCompatible.System.Text
{
    internal unsafe static class EncodingEx
    {
        public static string GetStringFromPtr(this Encoding encoding, byte* ptr, int byteCount)
        {
            var buffer = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
                buffer[i] = ptr[i];
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
