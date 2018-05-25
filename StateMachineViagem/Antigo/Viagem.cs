using System;
using System.Text;
using StateMachineViagem.Configuration;
using StateMachineViagem.Helpers;

namespace StateMachineViagem.Antigo
{
    public class Viagem
    {
        private ViagemState _state;

        public string State => ViagemStateEnumToString.To(_state);
        
        public Viagem(ViagemState state) => _state = state;

        public void Liberar()
        {   
            if (_state != ViagemState.AguardandoLiberacao) NaoPermitirRealizarAcao();
            
            _state = ViagemState.AguardandoCarregamento;
        }

        public void Rejeitar()
        {
            if (_state != ViagemState.AguardandoLiberacao) NaoPermitirRealizarAcao();
            
            _state = ViagemState.Rejeitada;
        }

        public void InformarCarregamento()
        {
            if (_state != ViagemState.AguardandoCarregamento) NaoPermitirRealizarAcao();
            
            _state = ViagemState.AguardandoAprovacaoCarregamento;
        }

        public void AprovarCarregamento()
        {
            if (_state != ViagemState.AguardandoAprovacaoCarregamento) NaoPermitirRealizarAcao();

            _state = ViagemState.Carregado;
        }

        public void RejeitarCarregamento()
        {
            if (_state != ViagemState.AguardandoAprovacaoCarregamento) NaoPermitirRealizarAcao();

            _state = ViagemState.CarregamentoRejeitado;
        }

        public void Descarregar()
        {
            if (_state != ViagemState.Carregado) NaoPermitirRealizarAcao();
            
            _state = ViagemState.Descarregado;
        }

        public void Cancelar()
        {
            if (_state != ViagemState.AguardandoLiberacao &&
                _state != ViagemState.AguardandoCarregamento)
            
            _state = ViagemState.Cancelado;
        }

        private void NaoPermitirRealizarAcao() => throw new InvalidOperationException(
            $"A viagem não esta em um estado que pode realizar essa ação, o estado atual é: {State}");
    }
}