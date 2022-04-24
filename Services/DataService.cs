﻿using DataAPI.Dtos;
using DataAPI.Models;
using System;
using System.Linq;

namespace DataAPI.Services
{
    public class DataService
    {
        public DataResponse validarData(DataRequest dataDto)
        {
            string data = dataDto.Data;
            int quantidadeCaracteres = data.Length;

            try
            {
                string dia = data.Substring(0, 2);
                string primeiraBarra = data.Substring(2, 1);
                string mes = data.Substring(3, 2);
                string segundaBarra = data.Substring(5, 1);
                string ano = data.Substring(6, 4);

                bool verificarFormatoData = verificarDataFormatoCorreto(dia, primeiraBarra, mes
               , segundaBarra, ano, quantidadeCaracteres);

                int diaInteiro = Int32.Parse(dia);
                int mesInteiro = Int32.Parse(mes);
                int anoInteiro = Int32.Parse(ano);

                bool verificarDtValida = verificarDataValida(diaInteiro, mesInteiro, anoInteiro);

                if (verificarFormatoData == true && verificarDtValida == true)
                {
                    DataResponse dataResponse = verificarDiaUtil(diaInteiro, mesInteiro, anoInteiro);
                    return dataResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return null;
            }          
        }

        private bool verificarDataFormatoCorreto(string dia
            ,string primeiraBarra, string mes, string segundaBarra, string ano
            , int quantidadeCaracteres)
        {
            
            if (quantidadeCaracteres != 10)
            {
                return false;
            }
            
            if (!dia.All(char.IsDigit))
            {
                return false;
            }

            if (!mes.All(char.IsDigit))
            {
                return false;
            }

            if (!ano.All(char.IsDigit))
            {
                return false;
            }

            if (!primeiraBarra.Equals("/"))
            {
                return false;
            }

            if (!segundaBarra.Equals("/"))
            {
                return false;
            }
            return true;
        }

        private bool verificarDataValida(int dia, int mes, int ano)
        {
            if ((dia <= 0 && dia > 31) || (mes <= 0 && mes > 12) || (ano <= 0))
            {
                return false;
            }
            else if ((mes == 4 || mes == 6 || mes == 9 || mes == 11) && !(dia >= 1 && dia <= 30))
            {
                return false;
            }
            else if ((mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 
                || mes == 12) && !(dia >= 1 && dia <= 31))
            {
                return false;
            }
            else if (mes == 2)
            {
                if (ano % 400 == 0)
                {
                    if (dia != 29)
                    {
                        return false;
                    }
                }
                else if ((ano % 4 == 0) && (ano % 100 != 0))
                {
                    if (dia > 29)
                    {
                        return false;
                    }
                }
                else
                {
                    if (dia > 28)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private DataResponse verificarDiaUtil(int dia, int mes, int ano)
        {
            DateTime data = new DateTime(ano, mes, dia);
            DataCalendario dataCalendario = FeriadosFixo.ConsultarFeriadoFixo(dia, mes);
            if (dataCalendario != null)
            {
                DataResponse dataResponse = new DataResponse(data, false, true);
                return dataResponse;
            }            
            else if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
            {
                DataResponse dataResponse = new DataResponse(data, false, false);
                return dataResponse;
            }            
            else
            {
                DataResponse dataResponse = new DataResponse(data, true, false);
                return dataResponse;
            }
        }
    } 
}