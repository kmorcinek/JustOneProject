using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace JustOneProject.VariousStuff
{
    public class TwoNumbers
    {
        public TwoNumbers(int first, int second)
        {
            First = first;
            Second = second;
        }

        public int First { get; }
        public int Second { get; }
    }

    public class GenerateCalculations
    {
        readonly Random _random = new Random();

        public string GetOne()
        {
            var list = new List<string>();
            for (int i = 0; i < 16; i++)
            {
                var additionNumbers = GetAdditionNumbers();
                var calculation = GetCalculation(additionNumbers);
                list.Add(calculation);
            }

            var twoCalculationsList = new List<string>();

            for (int i = 0; i < 16; i += 2)
            {
                twoCalculationsList.Add(list[i] + string.Join("", Enumerable.Repeat("\t", 7)) + list[i + 1]);
            }

            var together = string.Join(Environment.NewLine + Environment.NewLine, twoCalculationsList);

            return together;
        }

        string GetCalculation(TwoNumbers twoNumbers)
        {
            return $"{twoNumbers.First} + {twoNumbers.Second} = ";
        }

        [Pure]
        TwoNumbers GetAdditionNumbers()
        {
            while (true)
            {
                var twoNumbers = GetTwoNumber();

                if (twoNumbers.First + twoNumbers.Second < 19)
                {
                    return twoNumbers;
                }
            }
        }

        [Pure]
        TwoNumbers GetTwoNumber()
        {
            var upper = GetUpper();

            var first = _random.Next(1, upper);
            upper = GetUpper();
            var second = _random.Next(1, upper);

            return new TwoNumbers(first, second);
        }

        int GetUpper()
        {
            var next = _random.Next(4);
            return next == 0 ? 5 : 10;
        }
    }
}