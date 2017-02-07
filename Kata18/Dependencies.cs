﻿using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata18
{
    [TestClass]
    public class Dependencies
    {
        TransitiveDependencies _dependencies;

        public void SetUp()
        {
            _dependencies = new TransitiveDependencies();

            _dependencies.AddDirect("A", new[] { "B", "C" });

            _dependencies.AddDirect("B", new[] { "C", "E" });

            _dependencies.AddDirect("C", new[] { "G" });

            _dependencies.AddDirect("D", new[] { "A", "F" });

            _dependencies.AddDirect("E", new[] { "F" });

            _dependencies.AddDirect("F", new[] { "H" });
        }

        /*TODO Unit
         - Check a case where there is no class in which user want to know the children           
         - Check DeadLock from a class recursive (same type A->A)         
         - Try to create diferents childrens for same class         
        */
        [Test]

        [TestCase("A", new[] { "B", "C", "E", "F", "G", "H" })]

        [TestCase("B", new[] { "C", "E", "F", "G", "H" })]

        [TestCase("C", new[] { "G" })]

        [TestCase("D", new[] { "A", "B", "C", "E", "F", "G", "H" })]

        [TestCase("E", new[] { "F", "H" })]

        [TestCase("F", new[] { "H" })]

        [TestCase("A", null)]

        [TestCase("B", new string [] { })]
        public void FindsDependencies(string item, string[] dependencies)
        {
            NUnit.Framework.Assert.That(_dependencies.Dependecies_For(item), Is.EqualTo(dependencies));
        }
    }
}
