using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextCommon;
using R_Common;

namespace ContextBack
{
    public class ContextCls
    {
        public List<SalesStreamDTO> GetSalesListDb(GetSalesListDbParameterDTO poParameter)
        {
            R_Exception loException = new R_Exception();
            List<SalesStreamDTO> loRtn = null;

            try
            {
                if (poParameter.SalesCount > 50)
                {
                    loException.Add("01", "Error Count>50");
                    goto EndBlock;
                }
                loRtn = new List<SalesStreamDTO>();
                for (int lnCount = 1; lnCount <= poParameter.SalesCount; lnCount++)
                {
                    loRtn.Add(new SalesStreamDTO()
                    {
                        CompanyId = poParameter.CompanyId,
                        DepartmentId = poParameter.DepartmentId,
                        SalesId = $"S-{lnCount}",
                        SalesName = $"Sales-{lnCount}"

                    });
                }

            }
            catch (Exception ex)
            {

                loException.Add(ex);
            }

        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }

        public List<OrderStreamDTO> GetOrderListDb(GetOrderListDbParameterDTO poParameter)
        {
            R_Exception loException = new R_Exception();
            List<OrderStreamDTO> loRtn = null;

            try
            {
                if (poParameter.OrderCount > 20)
                {
                    loException.Add("01", "Error Count>20");
                    goto EndBlock;
                }
                loRtn = new List<OrderStreamDTO>();
                for (int lnCount = 1; lnCount <= poParameter.OrderCount; lnCount++)
                {
                    loRtn.Add(new OrderStreamDTO()
                    {
                        CompanyId = poParameter.CompanyId,
                        DepartmentId = poParameter.DepartmentId,
                        SalesId = poParameter.SalesId,
                        OrderId = $"Order-{lnCount}",
                        ORderDate = DateTime.Now.ToString("yy-MM-dd")
                    });
                }

            }
            catch (Exception ex)
            {

                loException.Add(ex);
            }

        EndBlock:
            loException.ThrowExceptionIfErrors();
            return loRtn;
        }
    }
}
