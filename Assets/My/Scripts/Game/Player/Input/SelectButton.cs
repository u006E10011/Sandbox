using UnityEngine;
using UnityEngine.EventSystems;

namespace Project
{
    public class SelectButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsSelected { get; private set; }

        public void OnPointerDown(PointerEventData eventData)
        {
            IsSelected = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            IsSelected = false;
        }
    }
}