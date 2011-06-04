using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using neprostopleer.Natives;
using System.Runtime.InteropServices;
using System.Drawing;

namespace neprostopleer.Cores
{
    public class CoreSnappingForm: Form
    {
        private const int WM_WINDOWPOSCHANGING = 0x0046;
        private const int WM_SIZING = 0x0214;
        private const int WM_EXITSIZEMOVE = 0x0232;
        
        private static int wndprocctr = 0;
        private bool snappingFormSizing = false;
        int SNAPTHRESHOLD = 15;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //Debug.WriteLine(wndprocctr++ + m.Msg.ToString() + "" + m.ToString());
            if (m.Msg == WM_SIZING)
            {
                snappingFormSizing = true;
            }
            else if (m.Msg == WM_EXITSIZEMOVE)
            {
                snappingFormSizing = false;
            }
            if (m.Msg == WM_WINDOWPOSCHANGING)
            {
                WINDOWPOS r = (WINDOWPOS)Marshal.PtrToStructure(m.LParam, typeof(WINDOWPOS));
                if (!snappingFormSizing)
                    ProcessWindowPosChanging(ref r);
                else
                    ProcessWindowPosChangingSizing(ref r);
                Marshal.StructureToPtr(r, m.LParam, false);
            }
        }

        private void ProcessWindowPosChangingSizing(ref WINDOWPOS r)
        {
            Rectangle ScreenBounds = Screen.FromHandle(this.Handle).Bounds;
            if (r.x == 0 && r.y == 0 && r.cx == 0 && r.cy == 0)
                return;
            foreach (IntPtr k in Program.snappingManager.bounds.Keys)
            {
                Rectangle v = Program.snappingManager.bounds[k];
                if (k != this.Handle)
                {

                    if (Math.Abs(r.x + r.cx - v.Right) < SNAPTHRESHOLD)
                    {
                        r.cx = v.Right - r.x;
                    }

                    if (Math.Abs(r.x + r.cx - v.Left) < SNAPTHRESHOLD)
                    {
                        r.cx = v.Left - r.x;
                    }

                    if (Math.Abs(r.x - v.Left) < SNAPTHRESHOLD)
                    {
                        int diff = r.x - v.Left;
                        r.x = v.Left;
                        r.cx += diff;
                    }

                    if (Math.Abs(r.x - v.Right) < SNAPTHRESHOLD)
                    {
                        r.x = v.Right;
                    }

                    if (Math.Abs(r.y - v.Top) < SNAPTHRESHOLD)
                    {
                        int diff = r.y - v.Top;
                        r.y = v.Top;
                        r.cy += diff;
                    }

                    if (Math.Abs(r.y - v.Bottom) < SNAPTHRESHOLD)
                    {
                        int diff = r.y - v.Bottom;
                        r.y = v.Bottom;
                        r.cy += diff;
                    }

                    if (Math.Abs(r.y + r.cy - v.Top) < SNAPTHRESHOLD)
                    {
                        r.cy = v.Top-r.y;
                    }

                    if (Math.Abs(r.y + r.cy - v.Bottom) < SNAPTHRESHOLD)
                    {
                        r.cy = v.Bottom - r.y;
                    }

                }
            }
        }

        private void ProcessWindowPosChanging(ref WINDOWPOS r)
        {
            Rectangle ScreenBounds = Screen.FromHandle(this.Handle).Bounds;
            if (r.x == 0 && r.y == 0 && r.cx == 0 && r.cy == 0)
                return;
            foreach (IntPtr k in Program.snappingManager.bounds.Keys)
            {
                Rectangle v = Program.snappingManager.bounds[k];
                if (k != this.Handle)
                {

                    if (Math.Abs(r.x + r.cx - v.Left) < SNAPTHRESHOLD)
                    {
                        r.x = v.Left - r.cx;
                    }

                    if (Math.Abs(r.x - (v.Left + v.Width)) < SNAPTHRESHOLD)
                    {
                        r.x = v.Left + v.Width;
                    }

                    if (Math.Abs((r.x + r.cx) - (v.Left + v.Width)) < SNAPTHRESHOLD)
                    {
                        r.x = v.Left + v.Width - r.cx;
                    }

                    if (Math.Abs(r.x - v.Left) < SNAPTHRESHOLD)
                    {
                        r.x = v.Left;
                    }

                    if (Math.Abs(r.y - v.Top) < SNAPTHRESHOLD)
                    {
                        r.y = v.Top;
                    }

                    if (Math.Abs(r.y + r.cy - v.Top) < SNAPTHRESHOLD)
                    {
                        r.y = v.Top - r.cy;
                    }

                    if (Math.Abs(r.y - (v.Top + v.Height)) < SNAPTHRESHOLD)
                    {
                        r.y = v.Top + v.Height;
                    }

                    if (Math.Abs((r.y + r.cy) - (v.Top + v.Height)) < SNAPTHRESHOLD)
                    {
                        r.y = v.Top + v.Height - r.cy;
                    }

                }
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            updateBoundsCollection();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            updateBoundsCollection();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            updateBoundsCollection();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            updateBoundsCollection();
        }

        private void updateBoundsCollection()
        {
            if (this.Visible)
                Program.snappingManager.bounds[this.Handle] = this.Bounds;
            else
                Program.snappingManager.bounds.Remove(this.Handle);
        }
    }
}
