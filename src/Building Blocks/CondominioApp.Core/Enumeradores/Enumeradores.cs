namespace CondominioApp.Core.Enumeradores
{
    public enum Sexo
    {
        NI = 0,
        MASCULINO = 1,
        FEMININO = 2
    }

    public enum TipoDeUsuario
    {
        ADMINISTRADORA = 0,
        ADM = 1,
        FUNCIONARIO = 2,
        CLIENTE = 3,
        SUPERADMIN = 4,
        LOJISTA = 5
    }

    public enum Permissao
    {
        USUARIO = 0,
        ADMIN = 1
    }

    public enum StatusPreCadastro
    {
        PENDENTE = 1,
        APROVADO = 2,
        CANCELADO = 3
    }

    public enum TipoDeDocumento
    {
        CPF = 1,
        CNPJ = 2,
        RG = 3,
        OUTROS = 4
    }

    public enum TipoDeGrupo
    {
        QUADRA = 1,
        BLOCO = 2,
        RUA = 3,
        LOTES = 4
    }

    public enum TipoDePlano
    {
        BASIC = 1,
        STANDART = 2
    }

    public enum TipoDeUnidade
    {
        APARTAMENTO = 1,
        CASA = 2,
        SALA = 3
    }

    public enum StatusCorrespondencia
    {
        PENDENTE = 0,
        RETIRADO = 1,
        DEVOLVIDO = 2,
    }
}