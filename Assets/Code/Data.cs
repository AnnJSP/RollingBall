using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject", order = 0)]
    public class Data : ScriptableObject
    {
        [SerializeField] private float _bonus;

        public float Bonus => _bonus;

        [SerializeField] private float _damage;

        public float Damage => _damage;

        [SerializeField] private float _healthPoint;

        public float HealthPoint
        {
            get => _healthPoint;
            set => _healthPoint = value;
        }

        [SerializeField] private float _speed;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        [SerializeField] private int _labyrinthSizeX;

        public int LabyrinthSizeX => _labyrinthSizeX;

        [SerializeField] private int _labyrinthSizeZ;

        public int LabyrinthSizeZ => _labyrinthSizeZ;
    }
}