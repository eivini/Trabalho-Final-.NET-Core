using System.ComponentModel.DataAnnotations;

namespace TrabalhoFinal.Domain.Validations;

/// <summary>
/// Validação customizada 1: Valida que um ano não pode ser no futuro
/// </summary>
public class AnoFuturoAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is int ano)
        {
            var anoAtual = DateTime.Now.Year;
            
            if (ano > anoAtual)
            {
                return new ValidationResult(
                    ErrorMessage ?? $"O ano não pode ser maior que {anoAtual}."
                );
            }
        }

        return ValidationResult.Success;
    }
}
