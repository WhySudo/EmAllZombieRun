using UnityEngine;

namespace Core.Level
{
    /// <summary>
    /// Класс, описывающий загружаемый уровень
    /// </summary>
    public class Level : MonoBehaviour
    {
        [SerializeField] private LevelConfigurator levelConfigurator;
        [SerializeField] private Transform followGroupTransform;
        [SerializeField] private LevelProgressChecker levelProgressChecker;
        [SerializeField] private Bounds bounds;
        public Bounds Bounds => bounds;
        public float LevelProgress => levelProgressChecker.Progress;

        public Transform CameraPointTransform => followGroupTransform;
        /// <summary>
        /// Запускает настройку уровня
        /// </summary>
        public void ConfigureLevel()
        {
            levelConfigurator.ConfigureLevel();
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(bounds.center, bounds.extents*2);
        }
        //TEMP
        private void Start()
        {
            ConfigureLevel();
        }
    }
}
