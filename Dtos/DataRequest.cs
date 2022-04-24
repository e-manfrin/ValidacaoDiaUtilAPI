using System.ComponentModel.DataAnnotations;

namespace DataAPI.Dtos
{
    public class DataRequest
    {
        [Required(ErrorMessage = "O campo data é obrigatório")]
        public string Data { get; set; }
    }
}
