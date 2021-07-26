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
        MORADOR = 3,
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
        SEM_CONTRATO = 0,
        FREE = 1,
        STANDARD = 2,
        PREMIUM = 3
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
        DEVOLVIDO = 2
    }

    public enum CategoriaComunicado
    {
        COMUNICADO = 0,
        ATA = 1,
        URGENCIA = 2,
        BALANCETE = 3,
        COBRANÇA = 4,
        MANUTENÇÃO = 5,
        AVISO = 6,
        OBRA_REFORMA = 7,
        OUTROS = 8
    }

    public enum VisibilidadeComunicado
    {
        PUBLICO = 0,
        PROPRIETARIOS = 1,
        UNIDADES = 2,
        PROPRIETARIOS_UNIDADES = 3      
    }

    public enum TipoDeVisitante
    {
        PARTICULAR = 0,
        SERVICO = 1
    }

    public enum StatusVisita
    {
        PENDENTE = 1,    //Quando visita é criada pela portaria        
        APROVADA = 2,    //Quando visita é criada pelo condômino        
        REPROVADA = 3,   //Visita foi reprovada e não aconteceu
        INICIADA = 4,    //Visita esta em andamento
        TERMINADA = 5,   //Visita ja terminou
        EXPIRADA = 6     //Visita nao aconteceu
    }

    public enum TipoApiAutomacao
    {
        EWELINK = 1,
        WEBHOOK = 2
    }

    public enum TipoDePush
    {
        MORADOR = 0,
        SINDICO = 1
    }

    public enum CategoriaDaPastaDeSistema
    {
        COMUNICADO = 1,
        ATA = 2,
        URGENCIA = 3,
        BALANCETE = 4,
        COBRANÇA = 5,
        MANUTENÇÃO = 6,
        AVISO = 7,
        OBRA_REFORMA = 8,
        OUTROS = 9        
    }

    public enum StatusDaOcorrencia
    {
        PENDENTE = 0,
        EM_ANDAMENTO = 1,
        RESOLVIDA = 2
    }

    public enum TipoDoAutor
    {
        ADMINISTRACAO = 1,
        MORADOR = 2,
        SISTEMA = 3
    }

    public enum StatusReserva
    {
        PROCESSANDO = 0,
        APROVADA = 1,
        REPROVADA = 2,
        AGUARDANDO_APROVACAO = 3,
        NA_FILA = 4,
        CANCELADA = 5,
        EXPIRADA = 6,
        REMOVIDA = 7
    }

    public enum AcoesReserva
    {
        SOLICITADA = 0,
        APROVADA = 1,
        REPROVADA = 2,
        AGUARDAR_APROVACAO = 3,
        ENVIADA_PARA_FILA = 4,
        RETIRADA_DA_FILA = 5,
        CANCELADA = 6,
        EXPIRADA = 7,
        REMOVIDA = 8
    }

    public enum CategoriaParceiro
    {
        PADRAO = 0,
        CLUBE_DE_VANTAGENS = 1
    }

    public enum AcoesCorrespondencia
    {
        CADASTRO = 0,
        NOTIFICACAO = 1,
        RETIRADA = 2,
        DEVOLUCAO = 3,
        EXCLUSAO = 4
    }
}
