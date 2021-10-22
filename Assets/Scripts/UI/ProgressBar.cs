using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace UI
{
    /// <summary>
    /// Прогрессбар, показывающий прогресс какого либо события
    /// </summary>
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Image fillingElement;
        [SerializeField] private Image background;

        /// <summary>
        /// Устанавливает прогрессбару заданную величину
        /// </summary>
        /// <param name="value">процент заполненности прогрессбара</param>
        public void SetProgress(float value)
        {
            var realValue = Mathf.Clamp01(value);
            fillingElement.rectTransform.anchorMin = new Vector2(0f, 0f);
            fillingElement.rectTransform.anchorMax = new Vector2(realValue, 1);
        }
    }
}