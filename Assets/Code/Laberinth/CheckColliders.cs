using System.Collections.Generic;
using UnityEngine;


namespace Code
{
    internal sealed class CheckColliders
    {
        private int _sizeX;
        private int _sizeZ;
        private int _radius;
        private int _maxCollider;
        private float _count;

        internal static Dictionary<float, bool> laberinthColliders { get; }
        
        internal void CheckLaberinthColliders(Data data)
        {
            _sizeX = data.LabyrinthSizeX;
            _sizeZ = data.LabyrinthSizeZ;
            _maxCollider = _sizeX * _sizeZ;
            _count = 0;
               
            if (_sizeX > _sizeZ)
            {
                _radius = _sizeZ;
            }
            else
            {
                _radius = _sizeX;
            }

            for (int i = 0; i <= _sizeX; i++)
            {
                for (int j = 0; j < _sizeZ; j++)
                {
                    _count++;
                    bool isColliderExist;
                    Vector3 vector3 = new Vector3(i, j, 0);
                    Collider[] colliders = new Collider[_maxCollider];
                    
                    if (Physics.OverlapSphereNonAlloc(vector3, _radius, colliders, 6) != 0)
                    {
                        isColliderExist = true;
                    }
                    else
                    {
                        isColliderExist = false;
                    }
                    
                    laberinthColliders.Add(_count, isColliderExist);
                }
            }
        }
    }
}