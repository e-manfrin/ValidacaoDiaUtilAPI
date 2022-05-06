using DataAPI.Dtos;
using DataAPI.Models;
using System;
using System.Linq;

namespace DataAPI.Services
{
    public class DataService
    {
        public DataResponse VerificarDiaUtil(DateTime data)
        {
            int dia = data.Day;
            int mes = data.Month;
            int ano = data.Year;

            DataResponse dataResponse;

            var feriadoFixo = FeriadosFixo.ConsultarFeriadoFixo(dia, mes);
            if (feriadoFixo != null)
            {
                dataResponse = new DataResponse(data, feriadoFixo.NomeFeriado, false, true);

            }
            else {
                var feriadoMovel = FeriadoMovel.ConsultarFeriadoMovel(dia, mes, ano);
                if (feriadoMovel != null)
                {
                    dataResponse = new DataResponse(data, feriadoMovel.NomeFeriado, false, true);

                }
                else if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                {
                    var nomeDiaDaSemana = ConversorDiasDaSemana(data);
                    dataResponse = new DataResponse(data, nomeDiaDaSemana, false, false);
                    return dataResponse;
                }
                else
                {
                    var nomeDiaDaSemana = ConversorDiasDaSemana(data);
                    dataResponse = new DataResponse(data, nomeDiaDaSemana, true, false);
                }
            }
            return dataResponse;
            
        }
        public string ConversorDiasDaSemana(DateTime data)
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
