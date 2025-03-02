namespace BddReqnrollFramework.Tests
{
    public class Calculator
    {
        private int _firstNumber;
        private int _secondNumber;

        public void EnterNumber(int number)
        {
            if (_firstNumber == 0)
                _firstNumber = number;
            else
                _secondNumber = number;
        }

        public int Add()
        {
            return _firstNumber + _secondNumber;
        }

        public int Subtract()
        {
            return _firstNumber - _secondNumber;
        }
    }
}