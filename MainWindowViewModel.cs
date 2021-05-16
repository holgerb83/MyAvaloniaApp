using System;
using System.Collections.Generic;
using MvvmGen;

namespace MyAvaloniaApp
{
    [ViewModel(typeof(MainWindowModel))]
    public partial class MainWindowViewModel
    {
        [Property] private IReadOnlyList<ComplexType> _complexList = Array.Empty<ComplexType>();
        private int _counter;
        private readonly Random _rnd = new();

        [Command]
        private void FillDataGrid()
        {
            var result = new ComplexType[1_000_000];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new ComplexType(GetRandom(), GetRandom(), GetRandom(), GetRandom(), GetRandom(), GetRandom());
            }

            ComplexList = result;
        }

        partial void OnInitialize()
        {
            Model = new MainWindowModel();
        }

        [Command]
        private void ChangeTitle()
        {
            _counter++;
            Title = $"Wuff, wuff, Cool! {_counter}";
            BigNose = GetRandom();
        }

        private double GetRandom() => _rnd.NextDouble() * 100;
    }
}