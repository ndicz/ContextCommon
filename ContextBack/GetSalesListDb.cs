using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextCommon;
using R_Common;

namespace ContextBack
{
    public class GetSalesListDb
    {
        public List<SalesStreamDTO> GetSalesListdb(GetSalesListDbParameterDTO poParameter)
        {
            R_Exception loException = new R_Exception();
            List<SalesStreamDTO> loRtn = null;

            try
            {
                loRtn = new List<SalesStreamDTO>();
                for (int lnCount = 1; lnCount <= poParameter.SalesCount; lnCount++)
                {
                    loRtn.Add(new SalesStreamDTO()
                    {
                        CompanyId = poParameter.CompanyId,
                        DepartmentId = poParameter.DepartmentId
              
                    });
                }
                    
            }
            catch (Exception ex)
            {

                loException.Add(ex);
            }

       
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }
    }
}

