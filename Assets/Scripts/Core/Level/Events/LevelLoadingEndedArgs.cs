using System;
using UnityEngine;

namespace Core.Level.Events
{
    /// <summary>
    /// Событие окончания загрузки уровня
    /// </summary>
    public class LevelLoadingEndedEvent : UnityEngine.Events.UnityEvent<LevelLoadingEndedArgs>
    {
    }

    [Serializable]
    public class LevelLoadingEndedArgs
    {
        public int levelId;

        public LevelLoadingEndedArgs(int levelId)
        {
            this.levelId = levelId;
        }
    }
}