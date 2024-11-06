using UnityEngine;

namespace N19
{
    public class Draw : MonoBehaviour
    {
        /// <summary>
        /// пускает луч
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="distance"></param>
        /// <param name="color"></param>
        public static void DrawRay(Ray ray, float distance, Color color)
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, color);
        }

        /// <summary>
        /// Пускает луч и создает сферу в точке попадания
        /// </summary>
        /// <param name="ray"></param>
        /// <param name="hitPosition">Точка спавна сферы</param>
        /// <param name="distance"></param>
        /// <param name="colorRay"></param>
        /// <param name="colorSphere"></param>
        /// <param name="radius">Радиус сферы</param>
        public static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color colorRay, Color colorSphere, float radius = .15f)
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, colorRay);

            Gizmos.color = colorSphere;
            Gizmos.DrawSphere(hitPosition, radius);
        }
    }
}