using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern_Practice.Pattern
{
    // 전략 인터페이스. 껍데기만 제공
    public interface ICalculationStrategy
    {
        int Calculate(int num1, int num2);
    }


    // 덧셈 전략. 덧셈에 관한 실제 연산기능
    public class AddStrategy : ICalculationStrategy
    {
        public int Calculate(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    // 곱셈 전략. 곱셈에 관한 실제 연산기능
    public class MultiplyStrategy : ICalculationStrategy
    {
        public int Calculate(int num1, int num2)
        {
            return num1 * num2;
        }
    }

    public class CalculatorContext
    {
        private ICalculationStrategy? _strategy;

        // 전략 설정 메서드
        public void SetStrategy(ICalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        // 계산 메서드
        public int PerformCalculation(int num1, int num2)
        {
            if (_strategy == null)
            {
                throw new InvalidOperationException("전략이 설정되지 않았습니다.");
            }

            return _strategy.Calculate(num1, num2);
        }
    }


}
