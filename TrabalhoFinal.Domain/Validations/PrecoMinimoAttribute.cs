using System.ComponentModel.DataAnnotations;

namespace TrabalhoFinal.Domain.Validations;

/// <summary>
/// Validação customizada 2: Valida que o preço deve ser maior que zero
/// </summary>
public class PrecoMinimoAttribute : ValidationAttribute
{
    private readonly decimal _precoMinimo;

    public PrecoMinimoAttribute(double precoMinimo = 0.01)
    {
        _precoMinimo = (decimal)precoMinimo;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        if (value is decimal preco)
        {
            if (preco < _precoMinimo)
            {
                return new ValidationResult(
                    ErrorMessage ?? $"O preço deve ser no mínimo R$ {_precoMinimo:F2}."
                );
            }
        }

        return ValidationResult.Success;
    }
}
