using System;
using UnityEngine;

namespace N19
{
    public static class GameObjectExtern
    {
        public static void Destroy(this GameObject gameObject, Action action = null)
        {
            action?.Invoke();

            GameObject.Destroy(gameObject);
        }

        public static void Activate(this GameObject gameObject, Action action = null)
        {
            action?.Invoke();

            gameObject.SetActive(true);
        }

        public static void Deactivate(this GameObject gameObject, Action action = null)
        {
            action?.Invoke();

            gameObject.SetActive(false);
        }

    }
}