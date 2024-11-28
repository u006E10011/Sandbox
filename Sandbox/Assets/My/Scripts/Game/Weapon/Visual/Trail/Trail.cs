﻿using UnityEngine;

namespace Project
{
    public class Trail : MonoBehaviour
    {

        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
}