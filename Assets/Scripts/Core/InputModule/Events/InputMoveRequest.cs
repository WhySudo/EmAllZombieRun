using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.InputModule.Events
{
    /// <summary>
    /// Событие о получении из инпута запроса на перемещение
    /// </summary>
    public class InputMoveRequestEvent : UnityEvent<InputMoveRequestArgs>
    {
    }

    [Serializable]
    public class InputMoveRequestArgs
    {
        public Vector3 deltaMove;

        public InputMoveRequestArgs(Vector3 deltaMove)
        {
            this.deltaMove = deltaMove;
        }
    }
}