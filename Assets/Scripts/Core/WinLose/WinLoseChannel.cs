using Core.WinLose.Events;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Канал, связывающий систему проигрыша и победы и сущности, которые подписываются на данные события
    /// </summary>
    [CreateAssetMenu(fileName = "winLoseChannel", menuName = "Channels/Win Lose Channel", order = 0)]
    public class WinLoseChannel : ScriptableObject
    {
        public readonly GameLoseEvent GameLoseEvent = new GameLoseEvent();
        public readonly GameWinEvent GameWinEvent = new GameWinEvent();

        private bool _receiveEvents = false;

        /// <summary>
        /// Сброс запрета на прием событий после завершения уровня
        /// </summary>
        public void EnableReceiving()
        {
            _receiveEvents = true;
        }
        public void Win()
        {
            if (!_receiveEvents) return;
            GameWinEvent.Invoke(new GameWinArgs());
        }

        public void Lose()
        {
            if (!_receiveEvents) return;
            GameLoseEvent.Invoke(new GameLoseArgs());
        }
    }
}