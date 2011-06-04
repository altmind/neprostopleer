using System.Runtime.InteropServices;
namespace neprostopleer.Natives
{
    [StructLayout(LayoutKind.Sequential)]
    public class RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}