using System;
using Core;

namespace Calculation
{
    [ExportClass]
    public class Calculate
    {
        public int publicField = 17;
        private int privateField = 17;

        public int publicProperty { get; set; }
        private int privateProperty { get; set; }

        public int Add(int a, int b)
        {
            return a + b;
        }
        
        public int Sub(int a, int b)
        {
            return a - b;
        }
        
        private int Pow(int a)
        {
            return a * a;
        }
    }

    public class Abc
    {
        public int abs;
    }
    
    [ExportClass]
    public class Animal
    {
        public int count;
    }
}