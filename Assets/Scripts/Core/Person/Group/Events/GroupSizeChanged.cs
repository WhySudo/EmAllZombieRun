using UnityEngine.Events;

namespace Core.Person.Group.Events
{
    /// <summary>
    /// Событие изменения размера группы
    /// </summary>
    public class GroupSizeChangedEvent : UnityEvent<GroupSizeChangedArgs>
    {
    }

    public class GroupSizeChangedArgs
    {
        
    }
}