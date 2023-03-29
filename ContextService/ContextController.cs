using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextBack;
using ContextCommon;
using R_Common;
using R_BackEnd;
using R_CommonFrontBackAPI;
using Microsoft.AspNetCore.Mvc;


namespace ContextService
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContextController : ControllerBase, IContextProgram
    {
        [HttpPost]
        public async IAsyncEnumerable<SalesStreamDTO> GetSalesList()
        {
            ProgramContextDTO loProgramContext;
            GetSalesListContextDTO loContextParameter;
            GetSalesListDbParameterDTO loBackParameter = new GetSalesListDbParameterDTO();
            List<SalesStreamDTO> loSalesList;

            ContextCls loCls = null;

            loProgramContext = R_Utility.R_GetContext<ProgramContextDTO>(ContextConstant.PROGRAM_CONTEXT);

            loContextParameter =
                R_Utility.R_GetStreamingContext<GetSalesListContextDTO>(ContextConstant.SALES_STREAM_CONTEXT);


            loBackParameter.CompanyId = R_BackGlobalVar.COMPANY_ID;
            loBackParameter.DepartmentId = loProgramContext.DepartmentId;
            loBackParameter.SalesCount = loContextParameter.SalesCount;

            loCls = new ContextCls();
            loSalesList = loCls.GetSalesListDb(loBackParameter);

            foreach (SalesStreamDTO loSales in loSalesList)
            {
                await Task.Delay(1000);
                yield return loSales;
            }


        }

        [HttpPost]
        public IAsyncEnumerable<OrderStreamDTO> GetOrderList()
        {
            R_Exception loException = new R_Exception();
            ProgramContextDTO loProgramContex;
            GetOrderListContextDTO loContextParameter;
            GetOrderListDbParameterDTO loBackParameter = null;

            try
            {
                loBackParameter = new GetOrderListDbParameterDTO();

                loProgramContex = R_Utility.R_GetContext<ProgramContextDTO>(ContextConstant.PROGRAM_CONTEXT);
                loContextParameter =
                    R_Utility.R_GetStreamingContext<GetOrderListContextDTO>(ContextConstant.ORDER_STREAM_CONTEXT);

                loBackParameter.CompanyId = R_BackGlobalVar.COMPANY_ID;
                loBackParameter.DepartmentId = loProgramContex.DepartmentId;
                loBackParameter.OrderCount = loContextParameter.OrderCount;
                loBackParameter.SalesId = loContextParameter.SalesId;


            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }

            loException.ThrowExceptionIfErrors();

            return FetchOrderItem(loBackParameter);


        }

        private async IAsyncEnumerable<OrderStreamDTO> FetchOrderItem(GetOrderListDbParameterDTO poBackParameter)
        {

            ContextCls loCls = null;
            List<OrderStreamDTO> loOrderList = new();
            loCls = new ContextCls();
            loOrderList = loCls.GetOrderListDb(poBackParameter);
            foreach (OrderStreamDTO loOrder in loOrderList)
            {
                yield return loOrder;
            }
        }




    }
}
