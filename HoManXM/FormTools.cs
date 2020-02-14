using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoManXM
{
    static class FormTools
    {
        private const int HSCROLL = 0x100000;
        private const int VSCROLL = 0x200000;
        private const int STYLE = -16;

        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// 是否出现垂直滚动条
        /// </summary>
        /// <param name="ctrl">要测试的控件</param>
        /// <returns>true 出现，false 未出现</returns>
        public static bool IsVScrolVisible(this Control ctrl)
        {
            if (!ctrl.IsHandleCreated)
                return false;

            return (GetWindowLong(ctrl.Handle, STYLE) & VSCROLL) != 0;
        }

        /// <summary>
        /// 是否出现水平滚动条
        /// </summary>
        /// <param name="ctrl">要测试的控件</param>
        /// <returns>true 出现，false 未出现</returns>
        public static bool IsHScrolVisible(this Control ctrl)
        {
            if (!ctrl.IsHandleCreated)
                return false;
            return (GetWindowLong(ctrl.Handle, STYLE) & HSCROLL) != 0;
        }


    }
}
