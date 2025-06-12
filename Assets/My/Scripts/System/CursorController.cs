using UnityEngine;

namespace Project
{
    public static class CursorController
    {
        public static bool Visible;

        public static void CursorVisible(bool isVisible)
        {
            Visible = isVisible;

            Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isVisible;
        }

        public static void Switch()
        {
            Visible = !Visible;

            Cursor.lockState = Visible ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = Visible;
        }
    }
}