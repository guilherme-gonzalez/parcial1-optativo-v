using FluentValidation;
using Repository.Data;

namespace api.personas.Validation
{
    public class ClienteValidation : AbstractValidator<ClienteModel>
    {
        public ClienteValidation()
        {
            RuleFor(cliente => cliente.nombre)
                .NotEmpty().WithMessage("Nombre is required.")
                .MinimumLength(3).WithMessage("Nombre must be at least 3 characters long.");

            RuleFor(cliente => cliente.apellido)
                .NotEmpty().WithMessage("Apellido is required.")
                .MinimumLength(3).WithMessage("Apellido must be at least 3 characters long.");

            RuleFor(cliente => cliente.documento)
                .NotEmpty().WithMessage("Documento is required.")
                .MinimumLength(3).WithMessage("Documento must be at least 3 characters long.");

            RuleFor(cliente => cliente.celular)
                .MaximumLength(10).WithMessage("Celular cannot be longer than 10 digits.")
                .Matches("^[0-9]+$").WithMessage("Celular must contain only numbers.");

            RuleFor(cliente => cliente.id_banco)
                .NotEmpty().WithMessage("Id Banco is required.");

            RuleFor(cliente => cliente.direccion)
                .NotEmpty().WithMessage("Direccion is required.");

            RuleFor(cliente => cliente.mail)
                .NotEmpty().WithMessage("Mail is required.");

            RuleFor(cliente => cliente.estado)
                .NotEmpty().WithMessage("Estado is required.");
        }
    }
}