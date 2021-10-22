using Core.InputModule.Events;
using UnityEngine;

namespace Core.InputModule
{
    /// <summary>
    /// Канал, связывающий инпут и сущности, которые подписываются на инпут
    /// </summary>
    [CreateAssetMenu(fileName = "inputChannel", menuName = "Channels/Input Channel", order = 0)]
    public class InputChannel : ScriptableObject
    {
        public readonly InputMoveRequestEvent InputMoveRequestEvent = new InputMoveRequestEvent();
        public readonly InputBeganEvent InputBeganEvent = new InputBeganEvent();
        public readonly InputEndedEvent InputEndedEvent = new InputEndedEvent();
        
        public void Move(Vector3 deltaMove)
        {
            InputMoveRequestEvent.Invoke(new InputMoveRequestArgs(deltaMove));
        }

        public void InputBegan()
        {
            InputBeganEvent.Invoke(new InputBeganArgs());
        } 
        public void InputEnded()
        {
            InputEndedEvent.Invoke(new InputEndedArgs());
        }
    }
}