using System.Collections.Generic;
using StateMachineViagem.Configuration;

namespace StateMachineViagem.Helpers
{
    public class ViagemStateEnumToString
    {
        private static readonly Dictionary<ViagemState, string> ViagemStateEnumDictionary =
            new Dictionary<ViagemState, string>
            {
                {ViagemState.AguardandoLiberacao, "Aguardando Liberação"},
                {ViagemState.AguardandoCarregamento, "Aguardando Carregamento"},
                {ViagemState.Rejeitada, "Rejeitada"},
                {ViagemState.AguardandoAprovacaoCarregamento, "Aguardando Aprovacão Carregamento"},
                {ViagemState.CarregamentoRejeitado, "Carregamento Rejeitado"},
                {ViagemState.Carregado, "Carregado"},
                {ViagemState.Descarregado, "Descarregado"},
                {ViagemState.Cancelado, "Cancelado"},
            };
        
        public static string To(ViagemState viagemState) => ViagemStateEnumDictionary[viagemState];
    }
}