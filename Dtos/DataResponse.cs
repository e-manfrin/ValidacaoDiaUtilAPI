using System;

namespace DataAPI.Dtos
{
    public class DataResponse
    {
        public DateTime Data { get; set; }
        public bool DiaUtil { get; set; }
        public bool Feriado { get; set; }

        public DataResponse(DateTime data, bool diaUtil, bool feriado)
        {
            Data = data;
            DiaUtil = diaUtil;
            Feriado = feriado;
        }
    }
}
