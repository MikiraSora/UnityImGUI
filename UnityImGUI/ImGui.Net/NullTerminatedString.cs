using ImGuiNET.FXCompatible.System.Text;
using System.Text;

namespace ImGuiNET
{
    public unsafe struct NullTerminatedString
    {
        public readonly byte* Data;

        public NullTerminatedString(byte* data)
        {
            Data = data;
        }

        public override string ToString()
        {
            int length = 0;
            byte* ptr = Data;
            while (*ptr != 0)
            {
                length += 1;
                ptr += 1;
            }

            return Encoding.ASCII.GetStringFromPtr(Data, length);
        }

        public static implicit operator string(NullTerminatedString nts) => nts.ToString();
    }
}
