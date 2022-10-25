using ServiceOrion.Models;
using ServiceOrion.QueryExchangeRate;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceOrion.Selections
{
    public class QExchangeRate
    {
        public QExchangeRate()
        {

        }
        //2022-07-01T00:00:00.0000000Z
        //2022-07-10T23:59:59.9999999Z
        public  Response GetClient(string exchange1, string exchange2, QueryExchangeRateIn_V1Client queryExchange)
        {
            //  DateTime date = DateTime.Parse("2020-08-20T15:00:00Z");
            DateTime date = DateTime.Now;

            ExchangeRateByElementsQueryMessage_sync request = new ExchangeRateByElementsQueryMessage_sync();
            try
            {
                request.ExchangeRateSelectionByElements = new ExchangeRateSelectionByElements();
                request.ExchangeRateSelectionByElements.SelectionBySourceCurrencyCode = new ExchangeRateSelectionByCurrencyCode[1];
                request.ExchangeRateSelectionByElements.SelectionBySourceCurrencyCode[0] = new ExchangeRateSelectionByCurrencyCode();
                request.ExchangeRateSelectionByElements.SelectionBySourceCurrencyCode[0].InclusionExclusionCode = "I";
                request.ExchangeRateSelectionByElements.SelectionBySourceCurrencyCode[0].IntervalBoundaryTypeCode = "1";
                request.ExchangeRateSelectionByElements.SelectionBySourceCurrencyCode[0].LowerBoundaryCurrencyCode = exchange1;

                request.ExchangeRateSelectionByElements.SelectionByTargetCurrencyCode = new ExchangeRateSelectionByCurrencyCode[1];
                request.ExchangeRateSelectionByElements.SelectionByTargetCurrencyCode[0] = new ExchangeRateSelectionByCurrencyCode();
                request.ExchangeRateSelectionByElements.SelectionByTargetCurrencyCode[0].InclusionExclusionCode = "I";
                request.ExchangeRateSelectionByElements.SelectionByTargetCurrencyCode[0].IntervalBoundaryTypeCode = "1";
                request.ExchangeRateSelectionByElements.SelectionByTargetCurrencyCode[0].LowerBoundaryCurrencyCode = exchange2;

                request.ExchangeRateSelectionByElements.SelectionByValidFromDateTime = new GLOBAL_SelectionByDateTime[1];
                request.ExchangeRateSelectionByElements.SelectionByValidFromDateTime[0] = new GLOBAL_SelectionByDateTime();
                request.ExchangeRateSelectionByElements.SelectionByValidFromDateTime[0].InclusionExclusionCode = "I";
                request.ExchangeRateSelectionByElements.SelectionByValidFromDateTime[0].IntervalBoundaryTypeCode = "9";
                request.ExchangeRateSelectionByElements.SelectionByValidFromDateTime[0].LowerBoundaryDateTimeSpecified = true;
                request.ExchangeRateSelectionByElements.SelectionByValidFromDateTime[0].LowerBoundaryDateTime = date;


                request.ExchangeRateSelectionByElements.SelectionByValidToDateTime = new GLOBAL_SelectionByDateTime[1];
                request.ExchangeRateSelectionByElements.SelectionByValidToDateTime[0] = new GLOBAL_SelectionByDateTime();
                request.ExchangeRateSelectionByElements.SelectionByValidToDateTime[0].InclusionExclusionCode = "I";
                request.ExchangeRateSelectionByElements.SelectionByValidToDateTime[0].IntervalBoundaryTypeCode = "7";
                request.ExchangeRateSelectionByElements.SelectionByValidToDateTime[0].LowerBoundaryDateTimeSpecified = true;
                request.ExchangeRateSelectionByElements.SelectionByValidToDateTime[0].LowerBoundaryDateTime = date;

                request.ProcessingConditions = new QueryProcessingConditions();
                request.ProcessingConditions.QueryHitsMaximumNumberValue = 1;
                request.ProcessingConditions.QueryHitsUnlimitedIndicator = false;


                
                 var respuesta = queryExchange.FindByElements(request);

                var customer = respuesta.ExchangeRate[0].BidRate;
                return new Response
                {
                    IsSuccess = true,
                    Result = new QueryExchangeRateModel
                    {
                        Quantity = customer
                    }
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = new QueryExchangeRateModel
                    {
                        Quantity = 0
                    }
                };
            }

        }
        //
    }
}
