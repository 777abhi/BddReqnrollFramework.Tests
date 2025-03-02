# Here's how to set up a C# BDD automation framework with Reqnroll in VS Code

## Create the project structure (same as before):

```bash
mkdir BddReqnrollFramework
cd BddReqnrollFramework
code .
dotnet new sln -n BddReqnrollFramework
dotnet new classlib -n BddReqnrollFramework.Tests
dotnet sln add BddReqnrollFramework.Tests
cd BddReqnrollFramework.Tests
```

## Install Reqnroll NuGet packages (instead of SpecFlow)

```bash
dotnet add package Reqnroll
dotnet add package Reqnroll.NUnit
dotnet add package NUnit
dotnet add package NUnit3TestAdapter
dotnet add package Microsoft.NET.Test.Sdk
```

## Sample framework files with Reqnroll

```gherkin
// Feature file: Features/Calculator.feature
Feature: Calculator
    As a user
    I want to perform basic arithmetic operations
    So that I can do quick calculations

Scenario: Add two numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120

Scenario: Subtract two numbers
    Given I have entered 50 into the calculator
    And I have entered 30 into the calculator
    When I press subtract
    Then the result should be 20
```

```cs
// Step Definitions: Steps/CalculatorSteps.cs
using Reqnroll;  // Note: using Reqnroll instead of TechTalk.SpecFlow
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
            Assert.AreEqual(expectedResult, _result);
        }
    }
}
```

```cs
// Calculator Class: Calculator.cs (remains the same)
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
```

## VS Code configuration files (similar to previous example)

```json
// .vscode/launch.json
{
    "version": "0.2.0",
    "configurations": [
        {
            "name": ".NET Core Launch (console)",
            "type": "coreclr",
            "request": "launch",
            "preLaunchTask": "build",
            "program": "${workspaceFolder}/BddReqnrollFramework.Tests/bin/Debug/net6.0/BddReqnrollFramework.Tests.dll",
            "args": [],
            "cwd": "${workspaceFolder}/BddReqnrollFramework.Tests",
            "console": "internalConsole",
            "stopAtEntry": false
        }
    ]
}
```

```json
// .vscode/tasks.json
{
    "version": "2.0.0",
    "tasks": [
        {
            "label": "build",
            "command": "dotnet",
            "type": "process",
            "args": [
                "build",
                "${workspaceFolder}/BddReqnrollFramework.sln",
                "/property:GenerateFullPaths=true",
                "/consoleloggerparameters:NoSummary"
            ],
            "problemMatcher": "$msCompile"
        },
        {
            "label": "test",
            "command": "dotnet",
            "type": "process",
            "args": [
                "test",
                "${workspaceFolder}/BddReqnrollFramework.Tests"
            ],
            "problemMatcher": "$msCompile"
        }
    ]
}
```

## Hooks example with Reqnroll:

```cs
// Hooks file: Hooks/SetupHooks.cs
using Reqnroll;  // Note: using Reqnroll instead of TechTalk.SpecFlow

namespace BddReqnrollFramework.Tests.Hooks
{
    [Binding]
    public class SetupHooks
    {
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine($"Starting scenario: {scenarioContext.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Scenario completed");
        }
    }
}
```

## Configuration file (reqnroll.json instead of specflow.json):

```json
// reqnroll.json
{
    "language": {
        "feature": "en"
    },
    "bindingCulture": {
        "language": "en-US"
    }
}
```

Key differences from SpecFlow:

1. Namespace changed from `TechTalk.SpecFlow` to `Reqnroll`
2. Configuration file named `reqnroll.json` instead of `specflow.json`
3. More modern parameter syntax in step definitions (e.g., `{int}` instead of `(.*)`)
4. Improved tooling support and active development

To run the tests:

1. Build: `dotnet build`
2. Run tests: `dotnet test`

Additional setup notes:

- Reqnroll supports .NET 6+ (recommended to use latest .NET version)
- VS Code extension "C#" (ms-dotnettools.csharp) is still recommended
- The Reqnroll VS Code extension is in development, but you can use the terminal commands for now
