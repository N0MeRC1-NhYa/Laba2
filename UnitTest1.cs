using System;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestExecutor;
using Lab_1_2;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void stringFromFile()
        {
            String s = "10 20 30";
            int[] expected = new int[3] { 10, 20, 30 };
            int[] actual = Program.ParseResult(s);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LogicTest()
        {
            int[] dats = new int[3] { 1, 2, 3 };
            string actual = Program.Logic(dats);
            string expected = "0,68333";
            Assert.Equal(expected, actual);
        }
    }
}