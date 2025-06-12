using N19;
using UnityEngine;

using static YG.YandexGame;

namespace Project
{
    public class StatsWindow : MonoBehaviour
    {
        [SerializeField] private Translate _gametimeText;
        [SerializeField] private Translate _killsText;
        [SerializeField] private Translate _diedPlayerText;
        [SerializeField] private Translate _damageText;
        [SerializeField] private Translate _headshotText;

        private void OnEnable() => View();
        private void OnDisable() => View();

        protected void View()
        {
            _gametimeText.Add(savesData.Gametime);
            _killsText.Add(savesData.Kills);
            _diedPlayerText.Add(savesData.Died);
            _damageText.Add(savesData.Damage);
            _headshotText.Add(savesData.HeadShot);
        }
    }
}