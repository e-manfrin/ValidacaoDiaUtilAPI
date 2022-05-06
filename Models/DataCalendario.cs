namespace DataAPI.Models
{
    public class DataCalendario
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool Feriado { get; set; }
        public string NomeFeriado { get; set; }
        public bool DiaUtil { get; set; }

        public DataCalendario(int dia, int mes, int ano, bool feriado, bool diaUtil, string nomeFeriado)
        {
            Dia = dia;
            Mes = mes;
            Ano = ano;
            Feriado = feriado;
            NomeFeriado = nomeFeriado;
            DiaUtil = diaUtil;
        }
        public DataCalendario(int dia, int mes, bool feriado, bool diaUtil, string nomeFeriado)
        {
            Dia = dia;
            Mes = mes;
            Feriado = feriado;
            NomeFeriado = nomeFeriado;
            DiaUtil = diaUtil;
        }
    }
}
