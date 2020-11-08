using dNothi.Desktop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop
{
    public static class FormFactory
    {
        private static IFormFactory factory;

        public static void Use(IFormFactory factory)
        {
            if (FormFactory.factory != null)
            {
                throw new InvalidOperationException(@"Form factory has been already set up.");
            }

            FormFactory.factory = factory;
        }

        public static Form Create(Type formType)
        {
            if (factory == null)
            {
                throw new InvalidOperationException(@"Form factory has not been set up. Call the 'Use' method to inject an IFormFactory instance.");
            }

            return factory.CreateForm(formType);
        }

        public static T Create<T>() where T : Form
        {
            return (T)Create(typeof(T));
        }
    }
}
