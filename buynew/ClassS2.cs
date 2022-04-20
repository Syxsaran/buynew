using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buynew
{
    internal class ClassS2
    {
        private string _name;
        private string _mail;
        private string _number;
        private string _location;

        public ClassS2(string name, string mail, string number, string location)
        {
            this._name = name;
            this._mail = mail;
            this._number = number;
            this._location = location;
        }
        public string getName()
        {
            return _name;
        }
        public string getMail()
        {
            return _mail;
        }
        public string getNumber()
        {
            return _number;
        }
        public string getLocation()
        {
            return _location;
        }
    }
}
