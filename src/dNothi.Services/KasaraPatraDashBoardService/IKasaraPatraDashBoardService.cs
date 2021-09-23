
using dNothi.JsonParser.Entity.Dak;
using dNothi.Services.DakServices;
using dNothi.Services.DakServices.DakSharingService.Model;
using dNothi.Services.KasaraPatraDashBoardService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dNothi.Services.KasaraPatraDashBoardService
{
  public  interface IKasaraPatraDashBoardService
    {
        KasaraPotro GetList(DakUserParam dakListUserParam, int menuNo);
        PrapakerTalika GetPrapakerTalika(DakUserParam dakListUserParam, int potro);
        DakAttachmentResponse GetMulPattraAndSanjukti(DakUserParam dakListUserParam, KasaraPotro.Record record);
        DakAttachmentResponse GetLocalMulpotroSanjukti(int kosraid);
        
        ResponseModel KasaraDashBoardRecordCount(DakUserParam userParam);
    }
}
