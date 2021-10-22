using Core.Person.Group.Events;
using Core.Person.Movable;
using UnityEngine;

namespace Core.Person.Group.Joining
{
    /// <summary>
    /// Класс, активирующий поведение игрового персонажа после его присоединения в группу
    /// </summary>
    public class PlayablePersonAfterJoinActivate : MonoBehaviour
    {
        [SerializeField]private GroupablePerson groupablePerson;
        [SerializeField]private GameObject nonDummyBehaviour;

        private void OnEnable()
        {
            groupablePerson.PersonJoinedGroupEvent.AddListener(OnJoinedGroup);
        }

        private void OnJoinedGroup(PersonJoinedGroupArgs arg0)
        {
            nonDummyBehaviour.SetActive(true);
        }

        private void OnDisable()
        {
            groupablePerson.PersonJoinedGroupEvent.RemoveListener(OnJoinedGroup);
        }
    }
}