using UnityEngine.Events;

namespace Core.WinLose.Events
{
    /// <summary>
    /// Событие победы в игре
    /// </summary>
    public class GameWinEvent : UnityEvent<GameWinArgs>
    {
    }

    public class GameWinArgs
    {
        
    }
}