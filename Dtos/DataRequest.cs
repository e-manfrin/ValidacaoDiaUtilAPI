using System;
using System.ComponentModel.DataAnnotations;

namespace DataAPI.Dtos
{
    public class DataRequest
    {
        [Required(ErrorMessage = "O campo data é obrigatório")]
        public DateTime Data { get; set; }
    }
}
