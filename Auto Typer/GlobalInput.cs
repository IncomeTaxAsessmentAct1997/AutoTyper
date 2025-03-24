using System.Runtime.InteropServices;

namespace Auto_Typer
{
    public class GlobalHotkey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private readonly int hotkeyId;
        private readonly IntPtr windowHandle;
        private readonly Keys hotkey;

        public GlobalHotkey(Keys key, Form form)
        {
            hotkey = key;
            windowHandle = form.Handle;
            hotkeyId = this.GetHashCode();
        }

        public bool Register()
        {
            bool success = RegisterHotKey(windowHandle, hotkeyId, 0, (int)hotkey);
            if (!success)
            {
                MessageBox.Show($"Failed to register hotkey {hotkey}. It might already be in use.", "Hotkey Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return success;
        }

        public void Unregister()
        {
            UnregisterHotKey(windowHandle, hotkeyId);
        }

        public override int GetHashCode()
        {
            return (int)hotkey ^ windowHandle.ToInt32();
        }
    }
}
