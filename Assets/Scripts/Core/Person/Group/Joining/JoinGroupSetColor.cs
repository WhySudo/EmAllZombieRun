using Core.Person.Group.Events;
using UnityEngine;

namespace Core.Person.Group.Joining
{
    /// <summary>
    /// Класс, меняющий цвет персонажу на цвет группы после его присоединения к группе
    /// </summary>
    public class JoinGroupSetColor : MonoBehaviour
    {
        [SerializeField]private GroupablePerson groupablePerson;
        [SerializeField]private PersonVisualisation personVisualisation;

        private void OnEnable()
        {
            groupablePerson.PersonJoinedGroupEvent.AddListener(OnJoinedGroup);
        }

        private void OnJoinedGroup(PersonJoinedGroupArgs arg0)
        {
            personVisualisation.SetPersonMaterial(arg0.groupOfPersons.GroupMaterial);
        }
        
        private void OnDisable()
        {
            groupablePerson.PersonJoinedGroupEvent.RemoveListener(OnJoinedGroup);
        }
    }
}