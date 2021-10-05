using dNothi.Core.Entities;
using dNothi.Core.Interfaces;
using dNothi.Services.DakServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.SettingServices
{
  public class SettingServices: ISettingServices
    {
        IRepository<SettingsList> _settingsList;

        public SettingServices(IRepository<SettingsList> settingsList)
        {
            _settingsList = settingsList;
        }
        public SettingsList GetSettingList(DakUserParam _dakuserparam)
        {
            var settings= _settingsList.Table.FirstOrDefault(a => a.office_id == _dakuserparam.office_id && a.designation_id == _dakuserparam.designation_id);
            if(settings==null)
            {
                settings = new SettingsList();
            }

            return settings;
        }
    }
    public interface ISettingServices
    {
         SettingsList GetSettingList(DakUserParam _dakuserparam);

    }
}
