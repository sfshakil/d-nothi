using dNothi.Desktop.Interfaces;
using System;
using System.Windows.Forms;

namespace dNothi.Desktop
{
    public static class UserControlFactory
    {
        private static IUserControlFactory factory;

        public static void Use(IUserControlFactory factory)
        {
            if (UserControlFactory.factory != null)
            {
                throw new InvalidOperationException(@"User Control factory has been already set up.");
            }

            UserControlFactory.factory = factory;
        }

        public static UserControl Create(Type controlType)
        {
            if (factory == null)
            {
                throw new InvalidOperationException(@"User Control factory has not been set up. Call the 'Use' method to inject an IUserControlFactory instance.");
            }

            return factory.CreateUserControl(controlType);
        }

        public static T Create<T>() where T : UserControl
        {
            return (T)Create(typeof(T));
        }
    }
}
