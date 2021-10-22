using System;
using Core.Person.Group;
using UnityEngine;

namespace Core.Person.Playable
{
    /// <summary>
    /// Класс описывающий персонажа, управляемого игроком
    /// </summary>
    public class PlayablePerson : Person
    {
        [Header("Playable Person Settings")]
        [SerializeField] private PlayablePersonConfiguration playablePersonConfiguration;
        
        public override PersonConfiguration PersonConfiguration => playablePersonConfiguration;
        public PlayablePersonConfiguration PlayablePersonConfiguration => playablePersonConfiguration;
        public bool IsDummy
        {
            get
            {
                if (groupablePerson is null) return false;
                return groupablePerson.GroupOfPersons is null;
            }
        }
        [SerializeField]
        private GroupablePerson groupablePerson;

    }
}