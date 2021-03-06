using System;


namespace Code
{
    public sealed class PCInputVertical : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(UnityEngine.Input.GetAxis(AxisManager.VERTICAL));
        }
    }
}