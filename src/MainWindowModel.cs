using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyAvaloniaApp
{
    public class MainWindowModel
    {
        public MainWindowModel()
        {
            Task.Run(SayHelloAsync);
        }

        private async Task SayHelloAsync()
        {
            while (true)
            {
                await Task.Delay(1000);
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    Logs.Insert(0, $"{DateTime.Now} Test");
                });
            }
        }

        public string Title { get; set; } = "MyAvaloniaApp";
        
        public string Name { get; set; } = "";
        
        public double Price { get; set; }

        public ObservableCollection<string> Logs { get; set; } = new();
    }
}