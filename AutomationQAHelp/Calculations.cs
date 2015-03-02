using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.UIItems;
using System.Threading;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;

namespace AutomationQAHelp
{
    [TestClass]
    public class Calculations
    {
        private Application _application;

        [TestMethod]
        public void PlusTwoNumbers()
        {
            // открытие калькулятора
            _application = Application.Launch("C:\\Windows\\system32\\calc.exe");
            Assert.IsNotNull(_application);
            GetButton("2").Click();
            GetButton("Add").Click();
            GetButton("3").Click();
            GetButton("Equals").Click();
            Assert.AreEqual(ResultTextBox(), "5");
            _application.Close();
        }

        [TestMethod]
        public void MinusTwoNumbers()
        {
            _application = Application.Launch("C:\\Windows\\system32\\calc.exe");
            Assert.IsNotNull(_application);
            GetButton("Clear").Click();
            GetButton("4").Click();
            GetButton("Subtract").Click();
            GetButton("2").Click();
            GetButton("Equals").Click();
            Assert.AreEqual(ResultTextBox(), "2");
            _application.Close();
        }

        [TestMethod]
        public void MultiplyTwoNumbers()
        {
            _application = Application.Launch("C:\\Windows\\system32\\calc.exe");
            Assert.IsNotNull(_application);
            GetButton("Clear").Click();
            GetButton("3").Click();
            GetButton("Multiply").Click();
            GetButton("5").Click();
            GetButton("Equals").Click();
            Assert.AreEqual(ResultTextBox(), "15");
            _application.Close();
        }

        [TestMethod]
        public void DevideTwoNumbers()
        {
            _application = Application.Launch("C:\\Windows\\system32\\calc.exe");
            Assert.IsNotNull(_application);
            GetButton("Clear").Click();
            GetButton("8").Click();
            GetButton("Divide").Click();
            GetButton("2").Click();
            GetButton("Equals").Click();
            Assert.AreEqual(ResultTextBox(), "4");
            _application.Close();
        }

        // возврат результата операций 
        private object ResultTextBox()
        {
            return
                GetWindow().Get<Label>(SearchCriteria.ByAutomationId("150")).AutomationElement.
                    GetCurrentPropertyValue(AutomationElement.NameProperty).ToString();

        }

        // метод поиска кнопки
        public Button GetButton(string nameWindow)
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                var button = GetWindow().Get<Button>(SearchCriteria.ByText(nameWindow));
                if (button != null) return button;
            }

            return null;
        }

        // метод возврата главного окна калькулятора
        public Window GetWindow()
        {
            return _application.GetWindow("Calculator");
        }
    }
}
