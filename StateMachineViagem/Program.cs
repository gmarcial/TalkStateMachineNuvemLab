using System;
using StateMachineViagem.Configuration;

namespace StateMachineViagem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Poc State
            var viagemStateMachine = ViagemStateMachine.Startup();
            var viagemPoc = new Viagem(viagemStateMachine);
            
            viagemPoc.Liberar();
            
            Console.WriteLine(viagemPoc.State);
        }
    }
}