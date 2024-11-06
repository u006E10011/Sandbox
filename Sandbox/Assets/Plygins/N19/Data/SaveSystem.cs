using UnityEngine;

namespace N19
{
    public static class SaveSystem
    {
        /// <summary>
        /// Используйте для сохранение простых типов данных: int, float, string
        /// </summary>
        /// <param name="path">Key</param>
        /// <param name="data">int, float, string</param>
        public static void Save(string path, object data)
        {
            System.Action action = data switch
            {
                int => () => PlayerPrefs.SetInt(path, (int)data),
                float => () => PlayerPrefs.SetFloat(path, (float)data),
                string => () => PlayerPrefs.SetString(path, (string)data),
                _ => () => Debug.Log($"<color=red>The current type <<color=yellow>{data.GetType()}</color>> is not suitable, you can only use: <color=green>int, float, string</color></color>")
            };

            action?.Invoke();
            PlayerPrefs.Save();
        }

        public static int GetInt(string path, int defaultValue = default) => PlayerPrefs.GetInt(path, defaultValue);
        public static float GetFloat(string path, float defaultValue = default) => PlayerPrefs.GetFloat(path, defaultValue);
        public static string GetString(string path, string defaultValue = default) => PlayerPrefs.GetString(path, defaultValue);

    }

    public static class Key
    {
        public const string SOUND_ENABLED = "IsSoundEnabled";
        public const string SOUND_VOLUME = "SoundVolume";
    }
}