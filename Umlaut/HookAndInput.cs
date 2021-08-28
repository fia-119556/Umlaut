using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Umlaut
{
    class HookAndInput
    {

        /// <summary>
        /// 各キーのステータス true:押下
        /// </summary>
        bool shift = false;
        bool ctrl = false;
        bool alt = false;

        const int INPUT_KEYBOARD = 1;
        const int KEYEVENTF_KEYDOWN = 0x0;
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
        const int KEYEVENTF_UNICODE = 0x4;

        delegate int delegateHookCallback(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(int idHook, delegateHookCallback lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        IntPtr hookPtr = IntPtr.Zero;

        [DllImport("user32.dll")]
        static extern void SendInput(int nInputs, ref INPUT pInputs, int cbsize);

        [DllImport("user32.dll")]
        static extern void SendInput(int nInputs, INPUT[] pInputs, int cbsize);

        [StructLayout(LayoutKind.Sequential)]
        struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public int dwExtraInfo;
        };

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public int dwExtraInfo;
        };

        [StructLayout(LayoutKind.Sequential)]
        struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        };

        [StructLayout(LayoutKind.Explicit)]
        struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            [FieldOffset(4)]
            public MOUSEINPUT no;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        };

        /// <summary>
        /// フック開始
        /// </summary>
        public void Hook()
        {
            
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                hookPtr = SetWindowsHookEx(
                    13,
                    HookCallback,
                    GetModuleHandle(curModule.ModuleName),
                    0
                );
                
            }
        }

        /// <summary>
        /// フックイベント
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        int HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Keys v = (Keys)(short)Marshal.ReadInt32(lParam);
            

            if (v == Keys.LShiftKey || v == Keys.RShiftKey)
            {
                if ((int)wParam == 256)//押下時 257キーアップ時
                {
                    shift = true;
                }
                else
                {
                    shift = false;
                }
                return 0;
            }

            if (v == Keys.LControlKey || v == Keys.RControlKey)
            {
                if ((int)wParam == 256)
                {
                    ctrl = true;
                }
                else
                {
                    ctrl = false;
                }
                return 0;
            }

            if (v == Keys.LMenu || v == Keys.RMenu)
            {
                if ((int)wParam == 256)
                {
                    alt = true;
                }
                else
                {
                    alt = false;
                }
                return 0;
            }

            if (!(ctrl & alt)) return 0;
            if ((int)wParam != 256) return 0;

            switch (v)
            {
                case Keys.A:
                    // Aキーの入力の場合
                    Send("Ä", "ä");
                    break;
                case Keys.U:
                    // Uキーの入力の場合
                    Send("Ü", "ü");
                    break;
                case Keys.O:
                    // Oキーの入力の場合
                    Send("Ö", "ö");
                    break;
                case Keys.S:
                    // Sキーの入力の場合
                    Send("ẞ", "ß");
                    break;
                default:
                    return 0;
            }

            return 1;
        }

        /// <summary>
        /// キーの送信
        /// </summary>
        /// <param name="onShift">ShiftがONの時の文字列</param>
        /// <param name="offShift">ShiftがOFFの時の文字列</param>
        private void Send(string onShift, string offShift)
        {
            INPUT[] inputs = null;
            if (shift)
            {
                inputs = ToInput(onShift);
            }
            else
            {
                inputs = ToInput(offShift);
            }
            SendInput(inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
        }

        /// <summary>
        /// 入力生成
        /// </summary>
        /// <param name="p">文字列</param>
        /// <returns></returns>
        private INPUT[] ToInput(string p)
        {
            int len = p.Length;
            INPUT[] inputs = new INPUT[len * 2];
            for (int i = 0; i < len; i++)
            {
                int j = i * 2;
                inputs[j].type = INPUT_KEYBOARD;
                inputs[j].ki.dwFlags = KEYEVENTF_UNICODE;
                inputs[j].ki.wScan = (short)p[i];

                int k = j + 1;
                inputs[k] = inputs[j];
                inputs[k].ki.dwFlags |= KEYEVENTF_KEYUP;
            }
            return inputs;
        }

        /// <summary>
        /// フック終了
        /// </summary>
        public void HookEnd()
        {
            UnhookWindowsHookEx(hookPtr);
            hookPtr = IntPtr.Zero;
        }
    }
}
