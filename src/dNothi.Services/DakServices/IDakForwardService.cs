using dNothi.JsonParser.Entity.Dak;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace dNothi.Services.DakServices
{
    public interface IDakForwardService
    {
        DakDecisionSetupResponse GetDakDecisionSetupResponse(DakUserParam dakListUserParam, string addJson, string deleteJson);

        DakDecisionListResponse GetDakDecisionListResponse(DakUserParam dakListUserParam);
        DakDecisionAddResponse GetDakDecisionAddResponse(DakUserParam dakListUserParam,DakDecisionDTO dakDecision);
        DakDecisionDeleteResponse GetDakDecisionDeleteResponse(DakUserParam dakListUserParam,DakDecisionDTO dakDecision);
        DesignationSealListResponse GetSealListResponse(DakUserParam dakListUserParam);
        DakForwardResponse GetDakForwardResponse(DakForwardRequestParam dakForwardResponse);
    }
}
