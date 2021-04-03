using System;


namespace Code
{
    public class IUserInput
    {
        public interface IUserInputProxy
        {
            event Action<float> AxisOnChange;
            void GetAxis();
        }
    }
}