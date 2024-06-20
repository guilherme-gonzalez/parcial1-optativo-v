using FluentValidation;
using Repository.Data;
using Services.Logica;
using Microsoft.Extensions.DependencyInjection;

namespace api.personas.Validation
{
    public class ClienteValidation : AbstractValidator<ClienteModel>
    {
        private readonly ClienteService _clienteService;

        public ClienteValidation(ClienteService clienteService)
        {
            _clienteService = clienteService;

            RuleFor(cliente => cliente.nombre)
                .NotEmpty().WithMessage("Nombre is required.")
                .MinimumLength(3).WithMessage("Nombre must be at least 3 characters long.");

            RuleFor(cliente => cliente.apellido)
                .NotEmpty().WithMessage("Apellido is required.")
                .MinimumLength(3).WithMessage("Apellido must be at least 3 characters long.");

            RuleFor(cliente => cliente.documento)
                .NotEmpty().WithMessage("Documento is required.")
                .MinimumLength(7).WithMessage("Documento must be at least 7 characters long.")
                .Must(documento => BeUniqueDocumento(documento)).WithMessage("Documento must be unique.");

            RuleFor(cliente => cliente.celular)
                .NotEmpty().WithMessage("Celular is required.")
                .MaximumLength(10).WithMessage("Celular cannot be longer than 10 digits.")
                .Matches("^[0-9]+$").WithMessage("Celular must contain only numbers.");

            RuleFor(cliente => cliente.id_banco)
                .NotEmpty().WithMessage("Id Banco is required.");

            RuleFor(cliente => cliente.direccion)
                .NotEmpty().WithMessage("Direccion is required.");

            RuleFor(cliente => cliente.mail)
                .NotEmpty().WithMessage("Mail is required.")
                .EmailAddress().WithMessage("Mail must be a valid email address.");

            RuleFor(cliente => cliente.estado)
                .NotEmpty().WithMessage("Estado is required.");

            RuleFor(cliente => cliente)
                .Must(cliente => IsActive(cliente.estado)).WithMessage("Customer data can only be retrieved if the status is active.");
        }

        private bool BeUniqueDocumento(string documento)
        {
            // Perform the uniqueness check synchronously
            return _clienteService.IsDocumentoUnique(documento).Result;
        }

        private bool IsActive(string estado)
        {
            return string.Equals(estado, "active", StringComparison.OrdinalIgnoreCase);
        }
    }
}
