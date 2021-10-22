using System;
using UI;
using UnityEngine;

namespace Core.Person
{
    /// <summary>
    /// Класс, визуализирующий здоровье игрока и показывающий его на <see cref="ProgressBar"/>
    /// </summary>
    public class PersonHealthVisualizer : MonoBehaviour
    {
        [SerializeField] private Person person;
        [SerializeField] private ProgressBar progressBar;

        private void Update()
        {
            progressBar.SetProgress(person.NormalizedHealth);
        }
    }
}