// -----------------------------------------------------------------------
// <copyright file="TransitiveDependencies.cs" company="Concrete-Solutions">
// Concrete Solutions all rights reserved
// </copyright>
// -----------------------------------------------------------------------

using TransitiveDependencies.Model;

namespace Kata18
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TransitiveDependencies
    {
        // All structure
        private List<Base> ClassDependencies; 
        
        // Recursive queue
        private List<Base> Queue; 

        //Branch of children
        private List<Base> fullSetDependencies;

        /// <summary>
        /// This method add the class and his children        
        /// </summary>
        /// <param name="item">Class to be selected</param>
        /// <param name="dependencies">Dependencies to be add</param>
        /// <returns>The class object filled</returns>        
        public Base AddDirect(string item, string[] dependencies)
        {
            ClassDependencies = this.GetClassDependencies(ClassDependencies); 

            Base thisClass = this.SelectClass(item); 

            List<Base> newChildrens = new List<Base>(); 

            foreach (var dep in dependencies) 
            {
                Base Child = SelectClass(dep);

                if (Child == null) 
                {
                    Child = new Base(dep, new List<Base>());

                    ClassDependencies.Add(Child); 
                }

                newChildrens.Add(Child); 
            }

            if (thisClass == null) 
            {
                thisClass = new Base(item, newChildrens);

                ClassDependencies.Add(thisClass); 
            }
            else
            {
                thisClass.Childrens = newChildrens;
            }

            return (thisClass);
        }

        /// <summary>
        /// This method will mount all children from a class     
        /// </summary>
        /// <param name="item">Class to be selected</param>        
        /// <returns>The list of string with children</returns>  
        public string[] Dependecies_For(string item) 
        {
            Queue = new List<Base>(); 

            fullSetDependencies = new List<Base>(); 

            Base thisClass = SelectClass(item);

            if (thisClass == null) throw new Exception("Couldn't find the Class: " + item); 

            Queue.Add(thisClass); 

            BuildFullClassDependencies(thisClass); 

            return GetFullSetDependenciesNames(fullSetDependencies); 
        }

        /// <summary>
        /// This method will mount all children from a class     
        /// </summary>
        /// <param name="thisClass">Class to be selected</param>        
        /// <returns>The list of string with children</returns> 
        private void BuildFullClassDependencies(Base thisClass)
        {
            fullSetDependencies.Add(Queue.First());

            Queue.Remove(Queue.First());

            foreach (var child in thisClass.Childrens) 
            {
                CheckDirectDeadLock(thisClass, child); 

                if (!Queue.Contains(child)) Queue.Add(child);               
            }

            if (Queue.Count <= 0)
            {
                return;
            }

            BuildFullClassDependencies(Queue.First());

            return;
        }

        /// <summary>
        /// This method will start the global class    
        /// </summary>
        /// <param name="ClassDependencies"></param>        
        /// <returns>Dependencies</returns> 
        private List<Base> GetClassDependencies(List<Base> ClassDependencies) 
        {
            if (ClassDependencies == null)
            {
                return new List<Base>();
            }
            else
            {
                return ClassDependencies;
            }
        }

        /// <summary>
        /// This method will change the list of class into a list of string with the names to return    
        /// </summary>
        /// <param name="fullSetDep">String list</param>        
        /// <returns>The list of string</returns> 
        public string[] GetFullSetDependenciesNames(List<Base> fullSetDep) 
        {
            string[] stringList = new string[fullSetDep.Count];

            int it = 0;

            foreach (var item in fullSetDep)
            {
                stringList[it] = item.Name;

                it++;
            }

            return stringList;
        }

        /// <summary>
        /// This method will check the deadlock  
        /// </summary>
        /// <param name="parent">Get the parent name to compare</param>        
        /// <param name="child">Get the name of child</param>        
        public void CheckDirectDeadLock(Base parent, Base child) 
        {
            if (parent.Name.Equals(child.Name)) throw new Exception("Deadlock Detected!");
        }

        // TO REVIEW
        // I need to use a nosql to support more items 
        public void CheckChildDeadLock(Base child)
        {
            if (Queue.Contains(child)) throw new Exception("Deadlock Detected!");
        }

        /// <summary>
        /// This method will search by letter in global list    
        /// </summary>
        /// <param name="letter">Letter return</param>        
        /// <returns>Null</returns> 
        private Base SelectClass(string letter)
        {
            if (ClassDependencies != null)
            {
                foreach (var item in ClassDependencies)
                {
                    if (item.Name.Equals(letter)) return item;
                }
            }

            return null;
        }
    }
}
