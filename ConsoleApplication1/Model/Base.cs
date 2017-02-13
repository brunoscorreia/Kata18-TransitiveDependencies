// -----------------------------------------------------------------------
// <copyright file="Base.cs" company="Concrete-Solutions">
// Concrete Solutions all rights reserved
// </copyright>
// -----------------------------------------------------------------------

namespace TransitiveDependencies.Model
{
    using System.Collections.Generic;
    
    public class Base
    {
        private string _name;

        private List<Base> _childrens;

        public Base(string name, List<Base> childrens)
        {
            this._name = name;

            this._childrens = childrens;
        }

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public List<Base> Childrens
        {
            get { return _childrens; }

            set { _childrens = value; }
        }


    }
}
