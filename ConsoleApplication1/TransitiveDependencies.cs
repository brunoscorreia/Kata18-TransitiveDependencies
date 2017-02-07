using ConsoleApplication1.Model;
using System;
using System.Collections.Generic;

namespace Kata18
{
    public class TransitiveDependencies
    {
        private List<Class> ClassDependencies; 

        private List<Class> FullSet; 
        
        public void AddDirect(string item, string[] dependencies)
        {
            GetClassDependencies(ClassDependencies);

            Class thisClass = SelectClass(item); 

            List<Class> newChildrens = new List<Class>();

            foreach (var dep in dependencies) 
            {
                Class Child = SelectClass(dep);

                if (Child == null) 
                {
                    Child = new Class(item);
                }

                newChildrens.Add(Child); 
            }

            if (thisClass == null) 
            {
                thisClass = new Class(item, newChildrens);
            }
            else
            {
                throw new Exception("This Class Children have already been assigned");
            }

            ClassDependencies.Add(thisClass); 
        }

        public string[] Dependecies_For(string item) 
        { 
            Class thisClass = SelectClass(item); 

            if (thisClass == null) throw new Exception("Couldn't find the Class: " + item); 

            BuildFullClassDependencies(thisClass); 

            return GetFullSetDependenciesNames(FullSet);
        }

        private void BuildFullClassDependencies(Class thisClass) 
        {
            foreach (var child in thisClass.Childrens) 
            {
                CheckDirectDeadLock(thisClass, child);
                //Pending to review Deadlock
                FullSet.Add(child); 
            }

            foreach (var item in FullSet) 
            {
                BuildFullClassDependencies(item);
            }
        }

        private List<Class> GetClassDependencies(List<Class> ClassDependencies) 
        {
            if (ClassDependencies == null)
                return new List<Class>();
            else
                return ClassDependencies;
        }

        public string[] GetFullSetDependenciesNames(List<Class> fullSetDep) 
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

        public void CheckDirectDeadLock(Class parent, Class child) 
        {
            if (parent.Name.Equals(child.Name)) throw new Exception("Deadlock Detected!");
        }


        //TODO: Review this method
        public void CheckChildDeadLock(Class child)
        {
            if (FullSet.Contains(child)) throw new Exception("Deadlock Detected!");
        }

        private Class SelectClass(string letter) 
        {
            foreach (var item in ClassDependencies)
            {
                if (item.Name.Equals(letter)) return item;
            }

            return null;
        }
    }
}
