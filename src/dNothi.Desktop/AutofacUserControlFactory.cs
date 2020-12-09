using Autofac;
using dNothi.Desktop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop
{
    public class AutofacUserControlFactory : IUserControlFactory
    {
        private readonly ILifetimeScope currentScope;

        public AutofacUserControlFactory(ILifetimeScope currentScope)
        {
            this.currentScope = currentScope;
        }

        public UserControl CreateUserControl(Type controlType)
        {
            // begin a new lifetime scope for each form instance
            var scope = this.currentScope.BeginLifetimeScope();

            var userControl = (UserControl)scope.Resolve(controlType);

            userControl.Disposed += (s, e) =>
            {
                // finish the scope when the form is disposed (closed)
                scope.Dispose();
            };

            return userControl;
        }
    }
}
