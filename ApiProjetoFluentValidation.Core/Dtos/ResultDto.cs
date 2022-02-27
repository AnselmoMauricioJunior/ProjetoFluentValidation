using ApiProjetoFluentValidation.Core.Interfaces.Dtos;
using FluentValidation.Results;

namespace ApiProjetoFluentValidation.Core.Dtos
{
    public class ResultDto: IResultDto
    {
        public bool Success { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public object Data { get; set; }

        public static ResultDto Sucesso(object data)
        {
            return new ResultDto
            {
                Success = true,
                Data = data
            };
        }

        public static ResultDto Erro(object data, ValidationResult validationResult)
        {
            return new ResultDto
            {
                Success = false,
                Data = data,
                ValidationResult = validationResult
            };
        }
    }
}
