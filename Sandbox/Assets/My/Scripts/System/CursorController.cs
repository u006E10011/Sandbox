using UnityEngine;

namespace Project
{
    public static class CursorController
    {
        public static bool Visible;

        public static void CursorState(bool isVisible)
        {
            Visible = isVisible;

            Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isVisible;
        }

        public static void CursorState()
        {
            Visible = !Visible;

            Cursor.lockState = Visible ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = Visible;
        }
    }
}