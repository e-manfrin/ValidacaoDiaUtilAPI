using DataAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAPI.Services
{
    public static class FeriadosFixo
    {
        public static List<DataCalendario> lista = new List<DataCalendario>();

        private static void PopularFeriadosFixos()
        {
            lista.Add(new DataCalendario(1, 1, true, false, "Ano novo"));
            lista.Add(new DataCalendario(21, 4, true, false, "Tiradentes"));
            lista.Add(new DataCalendario(1, 5, true, false, "Dia do Trabalho"));
            lista.Add(new DataCalendario(7, 9, true, false, "Independência do Brasil"));
            lista.Add(new DataCalendario(12, 10, true, false, "Nossa Senhora Aparecida"));
            lista.Add(new DataCalendario(2, 11, true, false, "Finados"));
            lista.Add(new DataCalendario(15, 11, true, false, "Proclamação da República"));
            lista.Add(new DataCalendario(20, 11, true, false, "Consciência Negra"));
            lista.Add(new DataCalendario(25, 12, true, false, "Natal"));
        }
        public static DataCalendario ConsultarFeriadoFixo(int dia, int mes)
        { 
           if(lista.Count == 0)
           {
                PopularFeriadosFixos();
           }
            DataCalendario feriadoEncontrado = lista.FirstOrDefault(feriado => feriado.Dia == dia && feriado.Mes == mes);
            return feriadoEncontrado;
        }
    }
}
