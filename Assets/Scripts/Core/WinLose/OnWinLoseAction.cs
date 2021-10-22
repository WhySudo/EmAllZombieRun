using Core.WinLose.Events;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Абстрактный класс, описывающий поведение сущности на проигрыш и победу уровня
    /// </summary>
    public abstract class OnWinLoseAction : MonoBehaviour
    {
        [SerializeField] protected WinLoseChannel winLoseChannel;

        protected abstract void OnGameLostAction();
        protected abstract void OnGameWinAction();

        private void OnEnable()
        {
            winLoseChannel.GameLoseEvent.AddListener(OnGameLost);
            winLoseChannel.GameWinEvent.AddListener(OnGameWon);
        }

        private void OnGameLost(GameLoseArgs arg0)
        {
            OnGameLostAction();
        }

        private void OnGameWon(GameWinArgs arg0)
        {
            OnGameWinAction();
        }

        private void OnDisable()
        {
            winLoseChannel.GameLoseEvent.RemoveListener(OnGameLost);
            winLoseChannel.GameWinEvent.RemoveListener(OnGameWon);
        }
    }
}