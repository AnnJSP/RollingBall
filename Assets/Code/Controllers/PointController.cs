using System;
using UnityEngine;


namespace Code
{
    internal sealed class PointController : MonoBehaviour, IController
    {
        public event Action Action;
        
        private void OnCollisionEnter(Collision other)
        {
            Action?.Invoke();
        }
    }
}