using FluentValidation.Results;

namespace CondominioApp.ReservaAreaComum.Domain.ReservaStrategy.ReservaSobrepostaStrategy
{
    public interface IRegrasDeReservaSobreposta
    {
        ValidationResult Validar();
    }
}

