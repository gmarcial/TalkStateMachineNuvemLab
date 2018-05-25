using System;
using Stateless;
using StateMachineViagem.Configuration;
using StateMachineViagem.Helpers;

namespace StateMachineViagem
{
    public class Viagem
    {
        private StateMachine<ViagemState, ViagemTriggers> StateMachine;
        public string State => ViagemStateEnumToString.To(StateMachine.State);

        public Viagem(StateMachine<ViagemState, ViagemTriggers> state) => StateMachine = state;

        public void Liberar()
        {
            GarantirQuePodeRealizarAcao(ViagemTriggers.LiberarViagem);
            StateMachine.Fire(ViagemTriggers.LiberarViagem);
        }

        public void Rejeitar()
        {
            GarantirQuePodeRealizarAcao(ViagemTriggers.RejeitarViagem);
            StateMachine.Fire(ViagemTriggers.RejeitarViagem);
        }

        public void InformarCarregamento()
        {
            GarantirQuePodeRealizarAcao(ViagemTriggers.InformarCarregamento);
            StateMachine.Fire(ViagemTriggers.InformarCarregamento);
        }

        public void AprovarCarregamento()
        {
            GarantirQuePodeRealizarAcao(ViagemTriggers.AprovarCarregamento);
            StateMachine.Fire(ViagemTriggers.AprovarCarregamento);
        }

        public void RejeitarCarregamento()
        {
            GarantirQuePodeRealizarAcao(ViagemTriggers.RejeitarCarregamento);
            StateMachine.Fire(ViagemTriggers.RejeitarCarregamento);
        }

        public void Descarregar()
        {
            GarantirQuePodeRealizarAcao(ViagemTriggers.Descarregar);
            StateMachine.Fire(ViagemTriggers.Descarregar);
        }

        public void Cancelar()
        {
            GarantirQuePodeRealizarAcao(ViagemTriggers.Cancelar);
            StateMachine.Fire(ViagemTriggers.Cancelar);
        }

        private void GarantirQuePodeRealizarAcao(ViagemTriggers viagemTriggers)
        {
            if (!StateMachine.CanFire(viagemTriggers))
                throw new InvalidOperationException(
                    $"A viagem não esta em um estado que pode realizar essa ação, o estado atual é: {State}");
        }
    }
}