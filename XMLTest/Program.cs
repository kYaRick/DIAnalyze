using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using CNTDLYCalculator.DesignSpace.VariableScope;

namespace XMLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement test = XElement.Load("test.xml").Element("variable");
            Variables.VariableTagAnalyzer(test, true);
            List<VariableElement> a = Variables.Info;

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
