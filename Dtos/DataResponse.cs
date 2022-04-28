using System;

namespace DataAPI.Dtos
{
    public class DataResponse
    {
        public DateTime Data { get; set; }
        public string Dia { get; set; }
        public bool DiaUtil { get; set; }
        public bool Feriado { get; set; }

        public DataResponse(DateTime data, string dia, bool diaUtil, bool feriado)
        {
            Data = data;
            Dia = dia;
            DiaUtil = diaUtil;
            Feriado = feriado;
        }
        public DataResponse(DateTime data, bool diaUtil, bool feriado)
        {
            Data = data;
            DiaUtil = diaUtil;
            Feriado = feriado;
        }
    }
}
