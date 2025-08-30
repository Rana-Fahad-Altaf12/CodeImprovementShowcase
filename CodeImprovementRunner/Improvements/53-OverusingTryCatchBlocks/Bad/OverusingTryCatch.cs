using Improvements.Common.Interfaces;
using System;

namespace Improvements._53_OverusingTryCatch.Bad
{
    public class OverusingTryCatch : IImprovementDemo
    {
        public void Run()
        {
            try
            {
                Console.WriteLine("Starting process...");

                try
                {
                    var result = Divide(10, 2);
                    Console.WriteLine($"Division result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Inner catch: {ex.Message}");
                }

                try
                {
                    var result = Divide(10, 0);
                    Console.WriteLine($"Division result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Inner catch: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Outer catch: {ex.Message}");
            }
        }

        private int Divide(int a, int b)
        {
            return a / b;
        }
    }
}
