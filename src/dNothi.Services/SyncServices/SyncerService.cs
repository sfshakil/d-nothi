using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.SyncServices
{
    public class SyncerService
    {
        public SyncerService()
        {

        }
        /****************=========================================================================***************************
         ****************=========================================================================***************************
        //Define a synchronization operation on a source, destination and status repository syncto(src, dst, status) to be these two steps:

        //Calculate the set difference src - status, and copy these messages to dst and status.
        //Calculate the set difference status - src, and delete these messages from dst and status.
        //The full synchronization algorithm is then:

        //syncto(R, L, S) (download changes)
        //syncto(L, R, S) (upload changes)

        **************************==================================================================********************************
        **************************==================================================================*******************************/


        //src will be Remote and dst will be Local
        public void Synctolocal(List<long> src,List<long> dst,List<long> status)
        {
            List<long> diff = src.Except(status).ToList();
            SaveMessageToLocal(diff);
            SaveMessageToStatus(diff);
            status = GetUpdatedStatus();
            List<long> diff2 = status.Except(src).ToList();
            DeleteFromLocal(diff2);
            DeleteFromStatus(diff2);
        }
        public List<long> GetStatus()
        {
            
        }
        private void DeleteFromStatus(List<long> diff2)
        {
            throw new NotImplementedException();
        }

        private void DeleteFromLocal(List<long> diff2)
        {
            throw new NotImplementedException();
        }

        private List<long> GetUpdatedStatus()
        {
            throw new NotImplementedException();
        }

        private void SaveMessageToStatus(List<long> diff)
        {
            throw new NotImplementedException();
        }

        private void SaveMessageToLocal(List<long> diff)
        {
            throw new NotImplementedException();
        }

        
    }
}
