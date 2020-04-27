using System;
using System.Collections.Generic;
using System.Text;

namespace RepLab_2
{
    class NewData
    {
        public int calc (int a, int b, char c)
        {
            switch (c)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
                default:
                    return 110011;
            } 
        }
    }
}
