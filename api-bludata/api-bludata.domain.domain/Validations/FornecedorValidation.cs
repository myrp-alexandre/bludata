using api_bludata.domain.domain.models;
using FluentValidation;

namespace api_bludata.domain.domain.Validations
{
    public class FornecedorValidation : AbstractValidator<fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(x => x.empresa.estado.sigla)
                .Equal("PR")
                .WithMessage("Número da agência é obrigatório");

        }
    }
}
