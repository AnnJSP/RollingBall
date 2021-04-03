using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Code
{
    internal sealed class PointInitialization
    {
        private Dictionary<float, bool> _laberinth;
        private int _sizeX;
        private int _sizeZ;
        private int _maxCollider;
        private GameObject _pointGameObject;
        private float _numberOfBonus;

        public void Initialization()
        {
            _laberinth = CheckColliders.laberinthColliders;
            _maxCollider = _laberinth.Count;

            if (_maxCollider % 5 == 0)
            {
                _numberOfBonus = _maxCollider / 5;
            }
            else if (_maxCollider % 3 == 0)
            {
                _numberOfBonus = _maxCollider / 9;

            }
            else if (_maxCollider % 2 == 0)
            {
                _numberOfBonus = _maxCollider / 8;
            }
            
            float _count = Random.Range(0, _maxCollider);
            
            while (_laberinth[_count] == true)
            {
                _count = Random.Range(0, _maxCollider);
            }

            for (int i = 0; i < _numberOfBonus; i++)
            {
                if (_laberinth[_count] == false)
                {
                    _pointGameObject = Resources.Load<GameObject>("Point");
                    _pointGameObject.AddComponent(typeof(Point));
                }
            }

        }
    }
}