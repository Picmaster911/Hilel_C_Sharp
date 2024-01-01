using System.Windows;
using Test_Http_WPF.Commands.Base;

namespace Test_Http_WPF.Commands
{
    class CloseAplicationCommand : CommandBase
    {
        public override bool CanExecute(object? parameter) => true;

        public override void Execute(object? parameter) => Application.Current.Shutdown();
    }
}
