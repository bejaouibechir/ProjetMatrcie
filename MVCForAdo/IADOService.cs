using System.Collections.Generic;
using System.Data;

namespace MVCForAdo
{
    public interface IADOService
    {
        List<string> executeQueryConnectedMode();
        DataSet executeQueryDisconnectedMode();
        List<string> getqueryFromStoredProcedure(int id_inf, int id_sup);
    }
}