using System;
using Core.Person;
using Core.Person.Group;
using UnityEngine;

namespace Core.Level
{
    /// <summary>
    /// Класс, настраивающий уровень перед запуском
    /// </summary>
    public class LevelConfigurator : MonoBehaviour
    {
        [SerializeField] private GroupablePerson startingPerson;
        [SerializeField] private GroupOfPersons personGroup;
        [SerializeField] private LevelProgressChecker levelProgressChecker;
        /// <summary>
        /// Настраивает загруженный уровень перед запуском
        /// </summary>
        public void ConfigureLevel()
        {
            startingPerson.JoinGroup(personGroup);//Создание "игрока" - единственного члена двигаемой группы
            levelProgressChecker.InitStartPoint(); //Иницализация начальной точки на уровне
        }
    }
}