using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Code
{
    internal sealed class Player : IInitialization
    {
        private Transform _player;
        private Dictionary<float, bool> _laberinth;
        private int _sizeX;
        private int _sizeZ;
        private int _maxCollider;
        private GameObject _playerGameObject;

        public void Initialization()
        {
            _laberinth = CheckColliders.laberinthColliders;
            
            float _count = Random.Range(0, _maxCollider);
            while (_laberinth[_count] == true)
            {
                _count = Random.Range(0, _laberinth.Count);
            }
            
            if (_laberinth[_count] == false)
            {
                _playerGameObject = Resources.Load<GameObject>("Player");
            }
        }
        
        public Transform GetPlayer()
        {
            _player = _playerGameObject.GetComponent<Transform>();
            return _player;
        }
    }
}