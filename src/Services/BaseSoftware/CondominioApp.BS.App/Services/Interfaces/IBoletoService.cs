namespace CondominioApp.BS.App.Services.Interfaces
{
    public interface IBoletoService
    {
        Boleto ObterBoletosDoCpf(string cpf, string NomeDaPasta);
    }
}
