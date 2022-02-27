using FluentValidation.Results;

namespace ApiProjetoFluentValidation.Core.Interfaces.Dtos
{
    public interface IResultDto
    {
        public bool Success { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public object Data { get; set; }
    }
}
