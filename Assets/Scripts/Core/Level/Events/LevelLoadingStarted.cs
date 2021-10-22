using System;

namespace Core.Level.Events
{
    /// <summary>
    /// Событие начала загрузки уровня
    /// </summary>
    public class LevelLoadingStartedEvent : UnityEngine.Events.UnityEvent<LevelLoadingStartedArgs>
    {
    }

    [Serializable]
    public class LevelLoadingStartedArgs
    {
        public int levelId;

        public LevelLoadingStartedArgs(int levelId)
        {
            this.levelId = levelId;
        }
    }
}