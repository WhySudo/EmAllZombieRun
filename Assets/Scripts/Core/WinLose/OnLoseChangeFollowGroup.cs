using Core.Person;
using Core.Person.Group;
using Core.WinLose.Events;
using UnityEngine;

namespace Core.WinLose
{
    /// <summary>
    /// Класс, меняющий группу следование при проигрыше
    /// </summary>
    public class OnLoseChangeFollowGroup : OnWinLoseAction
    {
        [SerializeField] private FollowGroupTransform followGroupTransform;
        [SerializeField] private GroupOfPersons loseFollowGroup;

        private void ChangeFollowGroup()
        {
            followGroupTransform.GroupOfPersons = loseFollowGroup;
        }

        protected override void OnGameLostAction()
        {
            ChangeFollowGroup();
        }

        protected override void OnGameWinAction()
        {
            
        }

    }
}