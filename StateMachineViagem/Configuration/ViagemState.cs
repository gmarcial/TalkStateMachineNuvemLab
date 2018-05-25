namespace StateMachineViagem.Configuration
{
    public enum ViagemState
    {
        AguardandoLiberacao = 10,
        AguardandoCarregamento = 20,
        Rejeitada = 30,
        AguardandoAprovacaoCarregamento = 40,
        CarregamentoRejeitado = 50,
        Carregado = 60,
        Descarregado = 70,
        Cancelado = 80
    }
}