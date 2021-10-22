using Core.Other;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Класс, меняющий параметры следования по победе и проигрышу
    /// </summary>
    public class OnWinLoseChangeFollowPoint : OnWinLoseAction
    {
        [SerializeField] private SmoothFollowMovement followMovement;
        [SerializeField] private LookAtFollowed cameraRotation;
        [SerializeField] private Vector3 gameEndCameraOffset;
        protected override void OnGameLostAction()
        {
            ChangeGameView();
        }

        protected override void OnGameWinAction()
        {
            ChangeGameView();
        }

        private void ChangeGameView()
        {
            followMovement.Offset = gameEndCameraOffset;
            cameraRotation.enabled = true;
        }
    }
}