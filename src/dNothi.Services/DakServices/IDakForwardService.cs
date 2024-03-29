﻿using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dNothi.Services.DakServices
{
    public interface IDakForwardService
    {
          bool Is_Locally_Forward_Reverted(int dak_id);
        bool SendDakForwardRevertedFromLocal();
        bool SendDakForwardFromLocal();
        bool Is_Locally_Forwarde(int dak_id);
        DakForwardRevertResponse GetDakForwardRevertResponse(DakUserParam dakListUserParam, int dak_id, string dak_type, int is_copied_dak);

        DakDecisionSetupResponse GetDakDecisionSetupResponse(DakUserParam dakListUserParam, string addJson, string deleteJson);

        DakDecisionListResponse GetDakDecisionListResponse(DakUserParam dakListUserParam);
        DakDecisionAddResponse GetDakDecisionAddResponse(DakUserParam dakListUserParam,DakDecisionDTO dakDecision);
        DakDecisionDeleteResponse GetDakDecisionDeleteResponse(DakUserParam dakListUserParam,DakDecisionDTO dakDecision);
        DesignationSealListResponse GetSealListResponse(DakUserParam dakListUserParam);
        DakForwardResponse GetDakForwardResponse(DakForwardRequestParam dakForwardResponse);
    }
}
