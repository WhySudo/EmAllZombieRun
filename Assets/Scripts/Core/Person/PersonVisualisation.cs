using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Person
{
    /// <summary>
    /// Класс, описывающий визуал персонажа
    /// </summary>
    public class PersonVisualisation : MonoBehaviour
    {
        [SerializeField] private List<Renderer> renderers;
        /// <summary>
        /// Устанавливает заданный материал персонажу
        /// </summary>
        /// <param name="material">новый материал персонажа</param>
        public void SetPersonMaterial(Material material)
        {
            renderers.ForEach(render=>render.material = material); 
        }
        
    }
}