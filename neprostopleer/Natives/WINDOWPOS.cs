using System.Runtime.InteropServices;
using System;
namespace neprostopleer.Natives
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndInsertAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
        public SetWindowPosFlags flags;
    }
}