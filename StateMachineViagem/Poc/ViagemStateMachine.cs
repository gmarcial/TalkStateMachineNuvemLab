using Stateless;
using StateMachineViagem.Configuration;

namespace StateMachineViagem
{
    public class ViagemStateMachine
    {
        public static StateMachine<ViagemState, ViagemTriggers> Startup()
        {
            var viagemState = new StateMachine<ViagemState, ViagemTriggers>(ViagemState.AguardandoLiberacao);

            viagemState
                .Configure(ViagemState.AguardandoLiberacao)
                .Permit(ViagemTriggers.LiberarViagem, ViagemState.AguardandoCarregamento)
                .Permit(ViagemTriggers.RejeitarViagem, ViagemState.Rejeitada)
                .Permit(ViagemTriggers.Cancelar, ViagemState.Cancelado);

            viagemState
                .Configure(ViagemState.AguardandoCarregamento)
                .Permit(ViagemTriggers.InformarCarregamento, ViagemState.AguardandoAprovacaoCarregamento)
                .Permit(ViagemTriggers.Cancelar, ViagemState.Cancelado);

            viagemState
                .Configure(ViagemState.AguardandoAprovacaoCarregamento)
                .Permit(ViagemTriggers.AprovarCarregamento, ViagemState.Carregado)
                .Permit(ViagemTriggers.RejeitarCarregamento, ViagemState.CarregamentoRejeitado);

            viagemState
                .Configure(ViagemState.Carregado)
                .Permit(ViagemTriggers.Descarregar, ViagemState.Descarregado);

            return viagemState;
        }
    }
}