using DataAPI.Models;
using System;

namespace DataAPI.Services
{
    public class FeriadoMovel
    {
        //Para anos entre 2020 e 2099:
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
            DateTime feriadoPascoa = new DateTime(ano, mesPascoa, diaPascoa);
            DateTime feriadoCarnaval = feriadoPascoa.AddDays(-47);
            DateTime feridadoCorpusChristi = feriadoPascoa.AddDays(60);
            if (dia == feriadoPascoa.Day && mes == feriadoPascoa.Month && ano == feriadoPascoa.Year)
            {
                DataCalendario dataCalendario = new DataCalendario(dia,mes,ano,true,false,"Páscoa");
                return dataCalendario;
            }
            else if (dia == feriadoCarnaval.Day && mes == feriadoCarnaval.Month && ano == feriadoCarnaval.Year)
            {
                DataCalendario dataCalendario = new DataCalendario(dia, mes, ano, true, false, "Carnaval");
                return dataCalendario;
            }
            else if (dia == feridadoCorpusChristi.Day && mes == feridadoCorpusChristi.Month && ano == feridadoCorpusChristi.Year)
            {
                DataCalendario dataCalendario = new DataCalendario(dia, mes, ano, true, false, "Corpus Christi");
                return dataCalendario;
            }
            else
            {
                return null;
            }
        }
    }
}
