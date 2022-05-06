using DataAPI.Models;
using System;

namespace DataAPI.Services
{
    public class FeriadoMovel
    {
        public static DataCalendario ConsultarFeriadoMovel(int dia, int mes, int ano)
        {
            int diaPascoa;
            int mesPascoa;
            int calculoEclesiasticoX = 24;
            int calculoEclesiasticoY = 5;
            int anosSolares = ano % 19;
            int semanasMensais = ano % 4;
            int diasNaSemana = ano % 7;
            int diasCorridos = (19 * anosSolares + calculoEclesiasticoX) % 30;
            int diasFaltantesCompletarMes = 
                (2 * semanasMensais + 4 * diasNaSemana + 6 * diasCorridos + calculoEclesiasticoY) % 7;
            if (diasCorridos + diasFaltantesCompletarMes > 9)
            {
                diaPascoa = (diasCorridos + diasFaltantesCompletarMes - 9);
                mesPascoa = 4;
            }
            else
            {
                diaPascoa = (diasCorridos + diasFaltantesCompletarMes + 22);
                mesPascoa = 3;
            }
            var feriadoPascoa = new DateTime(ano, mesPascoa, diaPascoa);
            var feriadoCarnaval = feriadoPascoa.AddDays(-47);
            var feridadoCorpusChristi = feriadoPascoa.AddDays(60);
            var feriadoSextaFeiraSanta = feriadoPascoa.AddDays(-2);

            DataCalendario dataCalendario;

            if (dia == feriadoPascoa.Day && mes == feriadoPascoa.Month && ano == feriadoPascoa.Year)
            {
                dataCalendario = new DataCalendario(dia,mes,ano,true,false,"Páscoa");
                
            }
            else if (dia == feriadoCarnaval.Day && mes == feriadoCarnaval.Month && ano == feriadoCarnaval.Year)
            {
                dataCalendario = new DataCalendario(dia, mes, ano, true, false, "Carnaval");
               
            }
            else if (dia == feridadoCorpusChristi.Day && mes == feridadoCorpusChristi.Month && ano == feridadoCorpusChristi.Year)
            {
                dataCalendario = new DataCalendario(dia, mes, ano, true, false, "Corpus Christi");
                
            }
            else if (dia == feriadoSextaFeiraSanta.Day && mes == feriadoSextaFeiraSanta.Month && ano == feriadoSextaFeiraSanta.Year)
            {
                dataCalendario = new DataCalendario(dia, mes, ano, true, false, "Sexta feira Santa");
               
            }
            else
            {
                return null;
            }
            return dataCalendario;
        }
    }
}
