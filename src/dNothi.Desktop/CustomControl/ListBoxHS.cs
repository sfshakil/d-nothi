using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.CustomControl
{
    public partial class ListBoxEx : ListBox
    {
        public ListBoxEx()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DoubleBuffered = true; // Eliminates flicker (optional).
        }

        private int _hotTrackedIndex = -1;
        private int HotTrackedIndex
        {
            get => _hotTrackedIndex;
            set
            {
                if (value != _hotTrackedIndex)
                {
                    if (_hotTrackedIndex >= 0 && _hotTrackedIndex < Items.Count)
                    {
                        Invalidate(GetItemRectangle(_hotTrackedIndex));
                    }
                    _hotTrackedIndex = value;
                    if (_hotTrackedIndex >= 0)
                    {
                        Invalidate(GetItemRectangle(_hotTrackedIndex));
                    }
                }
            }
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            var borderRect = e.Bounds;
            borderRect.Width--;
            borderRect.Height--;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                if (Focused)
                {
                    e.Graphics.FillRectangle(Brushes.Teal, e.Bounds);
                    e.Graphics.DrawRectangle(Pens.LightSkyBlue, borderRect);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.DimGray, e.Bounds);
                    e.Graphics.DrawRectangle(Pens.White, borderRect);
                }
            }
            else if (e.Index == HotTrackedIndex)
            {
                e.Graphics.FillRectangle(Brushes.DarkSlateGray, e.Bounds);
                e.Graphics.DrawRectangle(Pens.DarkCyan, borderRect);
            }
            else
            {
                e.DrawBackground();
            }
            if (Items[e.Index] != null)
            {
                e.Graphics.DrawString(Items[e.Index].ToString(), e.Font, Brushes.White, 6, e.Bounds.Top, StringFormat.GenericTypographic);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HotTrackedIndex = -1;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            HotTrackedIndex = IndexFromPoint(e.Location);
            base.OnMouseMove(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (SelectedIndex >= 0)
            {
                RefreshItem(SelectedIndex);
            }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (SelectedIndex >= 0)
            {
                RefreshItem(SelectedIndex);
            }
            base.OnLostFocus(e);
        }
    }
}
