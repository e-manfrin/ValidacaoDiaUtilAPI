using DataAPI.Dtos;
using DataAPI.Models;
using System;
using System.Linq;

namespace DataAPI.Services
{
    public class DataService
    {
        public DataResponse ValidarData(DataRequest dataDto)
        {
            try
            {
                DateTime data = dataDto.Data;
                DataResponse dataResponse = VerificarDiaUtil(data);
                return dataResponse;
            }
            catch (Exception ex)
            {
                return null;
            }          
        }
        private DataResponse VerificarDiaUtil(DateTime data)
        {
            int dia = data.Day;
            int mes = data.Month;
            int ano = data.Year;

            DataCalendario feriadoFixo = FeriadosFixo.ConsultarFeriadoFixo(dia, mes);
            DataCalendario feriadoMovel = FeriadoMovel.ConsultarFeriadoMovel(dia, mes, ano);
            if (feriadoFixo != null)
            {
                DataResponse dataResponse = new DataResponse(data, feriadoFixo.NomeFeriado ,false, true);
                return dataResponse;
            }     
            else if (feriadoMovel != null)
            {
                DataResponse dataResponse = new DataResponse(data, feriadoMovel.NomeFeriado ,false, true);
                return dataResponse;
            }
            else if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                string nomeDiaDaSemana = ConversorDiasDaSemana(data);
                DataResponse dataResponse = new DataResponse(data,nomeDiaDaSemana ,false, false);
                return dataResponse;
            }            
            else
            {
                string nomeDiaDaSemana = ConversorDiasDaSemana(data);
                DataResponse dataResponse = new DataResponse(data,nomeDiaDaSemana,true, false);
                
                return dataResponse;
            }
        }
        private string ConversorDiasDaSemana(DateTime data)
        {
            int codigo = (int) data.DayOfWeek;
            if (codigo == 0)
            {
                return "Domingo";
            }
            else if (codigo == 1)
            {
                return "Segunda-feira";
            }
            else if (codigo == 2)
            {
                return "Terça-feira";
            }
            else if (codigo == 3)
            {
                return "Quarta-feira";
            }
            else if (codigo == 4)
            {
                return "Quinta-feira";
            }
            else if (codigo == 5)
            {
                return "Sexta-feira";
            }
            else 
            {
                return "Sábado";
            } 
        }
    } 
}
