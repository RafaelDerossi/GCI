namespace CondominioApp.BS.App.Services.Interfaces
{
    public interface IBoletoService
    {
        Boleto ObterBoletosDoCpf(string CaminhoBase,string cpf, string NomeDaPasta);
    }
}
