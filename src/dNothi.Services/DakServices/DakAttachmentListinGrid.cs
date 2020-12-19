using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.DakServices
{
   public class DakAttachmentinGrid
    {
        public  bool mul_potro { get; set; }
        public  string attachment_source { get; set; }
        public  string attachment_Name { get; set; }
        public  int attachment_id { get; set; }
       
    }

    public class DakAttachmentListinGrid
    { 
        public List<DakAttachmentinGrid> dakAttachmentinGrids { get; set; }

       public DakAttachmentListinGrid()
        {
            dakAttachmentinGrids = new List<DakAttachmentinGrid>();
            DakAttachmentinGrid dakAttachmentinGrid = new DakAttachmentinGrid { attachment_id = 1, attachment_Name = "nothi.jpg", attachment_source = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDgxMDE5OTEsImlhdCI6MTYwODAxNDk5MSwianRpIjoiTVRZd09EQXhORGs1TVE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDgwMTQ5OTEsImRhdGEiOnsiZmlsZSI6ImlyOVltTGZuZ1hBb2VhU0FmZGVBT2RVZkdaMUdLZWlrZk1xQ3ZsaHg3Y2NYRTk4R0xSSnl6VHJNYmt1dzdmSDRCZGNwOHFuWWpnQ3J3dDNBcDhOMmVkdEYzRUU1eTlcL002Z05ETXJsVlowXC9mTzZYRCtvSit1ZFBnWE9Qekl0RkU0UkxMeXFaYllpaWNHaUt0WXlPN1pvb0RqTStzWXZCS0RvczhLTVNIeGM3QWRhOUFIQUo3YmRoT2p3ZmhpYXlJblAydER4aVZaeWRQck0wRnZSTHhVQT09IiwiZGVzaWduYXRpb24iOiJpelVDc1FpMmlVdnRDY2ZFeVNzdWtiUGRYbnlBNzZ1YkkxYzlIZEhhdGc4ckEwZjlSMnRlRmpPcU5aZlY3RlEzRHVib1RBeXVPQmY4bW1FSmcyWjhSZz09In19.hy9ucyPd7mguP4zOQZQPGOzDKppA46cpDcGMokk3iOI6dNVDsKBd-H9BunzH3Lm6L0qYt9EplX8Oc2GwHfGxRg", mul_potro = true };
            DakAttachmentinGrid dakAttachmentinGrid2 = new DakAttachmentinGrid { attachment_id = 1, attachment_Name = "nothi.jpg", attachment_source = "https://nothibs.tappware.com/api/content/view?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJleHAiOjE2MDgxMDE5OTEsImlhdCI6MTYwODAxNDk5MSwianRpIjoiTVRZd09EQXhORGs1TVE9PSIsImlzcyI6Imh0dHA6XC9cL25vdGhpYnMudGFwcHdhcmUuY29tXC8iLCJuYmYiOjE2MDgwMTQ5OTEsImRhdGEiOnsiZmlsZSI6ImlyOVltTGZuZ1hBb2VhU0FmZGVBT2RVZkdaMUdLZWlrZk1xQ3ZsaHg3Y2NYRTk4R0xSSnl6VHJNYmt1dzdmSDRCZGNwOHFuWWpnQ3J3dDNBcDhOMmVkdEYzRUU1eTlcL002Z05ETXJsVlowXC9mTzZYRCtvSit1ZFBnWE9Qekl0RkU0UkxMeXFaYllpaWNHaUt0WXlPN1pvb0RqTStzWXZCS0RvczhLTVNIeGM3QWRhOUFIQUo3YmRoT2p3ZmhpYXlJblAydER4aVZaeWRQck0wRnZSTHhVQT09IiwiZGVzaWduYXRpb24iOiJpelVDc1FpMmlVdnRDY2ZFeVNzdWtiUGRYbnlBNzZ1YkkxYzlIZEhhdGc4ckEwZjlSMnRlRmpPcU5aZlY3RlEzRHVib1RBeXVPQmY4bW1FSmcyWjhSZz09In19.hy9ucyPd7mguP4zOQZQPGOzDKppA46cpDcGMokk3iOI6dNVDsKBd-H9BunzH3Lm6L0qYt9EplX8Oc2GwHfGxRg", mul_potro = true };
            dakAttachmentinGrids.Add(dakAttachmentinGrid);
            dakAttachmentinGrids.Add(dakAttachmentinGrid2);
        }
    
    }

}
