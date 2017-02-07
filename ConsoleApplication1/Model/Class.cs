using System.Collections.Generic;

namespace ConsoleApplication1.Model
{
    public class Class
    {
        private string _name;

        private List<Class> _childrens;

        public Class (string name, List<Class> childrens = null)
        {
            this._name = name;

            this._childrens = childrens;
        }

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public List<Class> Childrens
        {
            get { return _childrens; }

            set { _childrens = value; }
        }


    }
}
