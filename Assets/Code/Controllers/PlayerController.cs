using UnityEngine;


namespace Code
{
    internal sealed class PlayerController : IController, IFixedRun
    {
        private float _horizontal; 
        private float _vertical;
        private float _speed;
        private Vector3 _move;
        private readonly Transform _unit;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;
        
        public PlayerController(Transform getPlayer, (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) 
            input, Data data)
        {
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            _speed = data.Speed;
        }
        
        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        public void FixedRun(float deltaTime)
        {
            var speed = deltaTime * _speed;
            _move.Set(_horizontal * _speed, _vertical * _speed, 0.0f);
            _unit.localPosition += _move;
        }
        
        public void Clean()
        { 
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
            
        }
    }
}