using Cysharp.Threading.Tasks;
using System;
using System.Threading;

using static UnityEngine.SceneManagement.SceneManager;

namespace N19
{
    public enum Scene
    {
        Lobby = 0,
        MainMenu = 1,
    }

    public static class SceneLoader
    {
        private static CancellationTokenSource Cts = new();
        private static CancellationToken Token = Cts.Token;

        #region Async
        /// <summary>
        /// Асихронная загрузка сцены из перечисления (N19.Scene)
        /// </summary>
        /// <returns></returns>
        public static async UniTask LoadAsync(Scene scene, float delay = 0)
        {
            Reload();

            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: Token);
                await LoadSceneAsync((int)scene);
            }
            catch (OperationCanceledException) { }
        }

        /// <summary>
        /// Асихронная загрузка сцены по индексу
        /// </summary>
        /// <returns></returns>
        public static async UniTask LoadAsync(int index, float delay = 0)
        {
            Reload();

            try
            {
                if (index <= sceneCountInBuildSettings)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: Token);
                    await LoadSceneAsync(index);
                }
                else
                    UnityEngine.Debug.LogError($"Запрашиваемый индекс: {index} не существует, максимальный индекс: {sceneCountInBuildSettings}");
            }
            catch (OperationCanceledException) { }
        }

        /// <summary>
        /// Асихронная загрузка следующей сцены
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public static async UniTask LoadNextSceneAsync(float delay = 0, bool isLoadMainMenuToException = true)
        {
            Reload();

            try
            {
                int next = GetActiveScene().buildIndex + 1;

                if (next < sceneCountInBuildSettings)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: Token);
                    await LoadSceneAsync(next);
                }
                else
                {
                    if (isLoadMainMenuToException)
                        await LoadAsync(Scene.MainMenu);
                    else
                        UnityEngine.Debug.LogError($"Запрашиваемый индекс: {GetActiveScene().buildIndex + 1} не существует, максимальный индекс: {sceneCountInBuildSettings}");
                }
            }
            catch (OperationCanceledException) { }

        }

        /// <summary>
        /// Асихронно загружает активную сцену
        /// </summary>
        /// <returns></returns>
        public static async UniTask LoadActiveSceneAsync() => await LoadSceneAsync(GetActiveScene().buildIndex);
        #endregion

        #region Default
        public static void LoadScene(int index) => LoadScene(index);
        public static void LoadActiveScene() => LoadScene(GetActiveScene().buildIndex);
        #endregion

        private static void Reload()
        {
            if (Cts != null && Cts.IsCancellationRequested == false)
            {
                Cts.Cancel();
                Cts.Dispose();
                Cts = null;
            }

            Cts = new();
            Token = Cts.Token;
        }
    }

    public static class OffsetScene
    {
        public const int OFFSET_VIEW = 1;
        public const int OFFSET_LOGICK = 2;
    }
}