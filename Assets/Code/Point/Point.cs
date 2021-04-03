using Random = UnityEngine.Random;


namespace Code
{
    internal sealed class Point
    {
        private float _count = Random.Range(0, 5);
        private readonly PointController pointController = new PointController();
        private readonly float _bonus;
        private readonly float _damege;
        private float _speed;
        private float _healthPoint;

        public Point(Data data)
        {
            pointController.Action += Motion;
            _bonus = data.Bonus;
            _damege = data.Damage;
            _speed = data.Speed;
            _healthPoint = data.HealthPoint;
        }

        private void Motion()
        {
            switch (_count)
            {
                case 0:
                    _healthPoint *= _bonus;
                    break;
                case 1:
                    _speed *= _bonus;
                    break;
                case 2:
                    _healthPoint *= _bonus;
                    _speed *= _bonus;
                    break;
                case 3:
                    _healthPoint *= _damege;
                    break;
                case 4:
                    _speed *= _damege;
                    break;
                case 5:
                    _healthPoint *= _damege;
                    _speed *= _damege;
                    break;
            }
        }
    }
}