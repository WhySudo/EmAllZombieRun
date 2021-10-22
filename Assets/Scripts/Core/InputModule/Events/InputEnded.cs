using UnityEngine.Events;

namespace Core.InputModule.Events
{
    /// <summary>
    /// Событие о завершении инпута
    /// </summary>
    public class InputEndedEvent : UnityEvent<InputEndedArgs>
    {
    }

    public class InputEndedArgs
    {
        
    }
}