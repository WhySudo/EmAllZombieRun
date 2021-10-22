using UnityEngine;
using UnityEngine.Events;

namespace Core.WinLose.Events
{
    /// <summary>
    /// Событие проигрыша в игре
    /// </summary>
    public class GameLoseEvent : UnityEvent<GameLoseArgs>
    {
    }

    public class GameLoseArgs
    {
    }
}