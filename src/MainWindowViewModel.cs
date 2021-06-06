using System;
using System.Collections.Generic;
using System.Linq;
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
            if (ComplexList.Any())
            {
                foreach (var complexType in ComplexList)
                {
                    complexType.A = GetRandom() > 50;
                    complexType.B = GetRandom() > 50;
                    complexType.C = GetRandom() > 50;
                    complexType.D = GetRandom() > 50;
                    complexType.E = GetRandom() > 50;
                    complexType.F = GetRandom() > 50;
                }
            }
            else
            {
                var result = new ComplexType[1_000_000];
                for (var i = 0; i < result.Length; i++)
                {
                    result[i] = new ComplexType
                    {
                        A = GetRandom() > 50,
                        B = GetRandom() > 50,
                        C = GetRandom() > 50,
                        D = GetRandom() > 50,
                        E = GetRandom() > 50,
                        F = GetRandom() > 50
                    };
                }

                ComplexList = result;
            }
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
            Price = GetRandom();
        }

        [Command]
        private void ShowMessageBox()
        {

        }

        private double GetRandom() => _rnd.NextDouble() * 100;
    }
}