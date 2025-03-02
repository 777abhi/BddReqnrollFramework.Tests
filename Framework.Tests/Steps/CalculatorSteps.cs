using Reqnroll;
using NUnit.Framework;

namespace BddReqnrollFramework.Tests.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private readonly Calculator _calculator = new Calculator();
        private int _result;

        [Given("I have entered {int} into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _calculator.EnterNumber(number);

        }

        [When("I press add")]
        public void WhenIPressAdd()
        {

                _result = _calculator.Add();

        }

        [When("I press subtract")]
        public void WhenIPressSubtract()
        {

                _result = _calculator.Subtract();
           
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int expectedResult)
        {

                Assert.That(_result, Is.EqualTo(expectedResult));
     
        }
    }
}