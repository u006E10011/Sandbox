using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class SwitchContent : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _content = new();

        public void Switch(int index)
        {
            for (int i = 0; i < _content.Count; i++)
                _content[i].SetActive(i == index);
        }
    }
}