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
        public static CancellationTokenSource Cts = new();
        public static CancellationToken Token = Cts.Token;

        public static async UniTask LoadAsync(Scene scene, float delay = 0)
        {
            Reload();

            Cts = new();
            Token = Cts.Token;

            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: Token);

                LoadScene((int)scene);
            }
            catch (OperationCanceledException) { }
        }

        public static async UniTask LoadAsync(int index, float delay = 0)
        {
            Reload();

            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: Token);
                LoadScene(index);
            }
            catch (OperationCanceledException) { }
        }

        public static async UniTask LoadNextSceneAsync(float delay = 0)
        {
            Reload();

            try
            {
                int next = GetActiveScene().buildIndex + 1;

                if (next < sceneCountInBuildSettings)
                {
                    await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken: Token);

                    LoadScene(next);
                }
                else
                    await LoadAsync(Scene.MainMenu);
            }
            catch (OperationCanceledException) { }

        }

        public static void LoadSceneToIndex(int index) => LoadScene(index);

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