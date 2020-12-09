﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dNothi.Desktop.Interfaces
{
    public interface IUserControlFactory
    {
        UserControl CreateUserControl(Type formType);
    }
}
