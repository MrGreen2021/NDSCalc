using NDSCalc.Model.Models;
using NDSCalc.Model.Structs;
using NDSCalc.ViewModel.Interfaces;
using Simplified;
using System;
using System.Windows;

namespace NDSCalc.ViewModel.Windows
{

    // Часть отвечающая за связь с Моделью
    public partial class MainWindowViewModel : BaseInpc, INdsCalculationViewModel
    {
        private readonly NDSCalcModel model = new NDSCalcModel();

        public MainWindowViewModel()
        {
            model.DataChanged += OnDataChanged;
        }

        private void OnDataChanged(object sender, EventArgs e)
        {
            CalculationData data = ((NDSCalcModel)sender).GetData();
            AmountWithoutNds = data.AmountWithoutNds;
            NdsRate = data.NdsRate * 100;
            AmountOfNds = data.AmountOfNds;
            TotalAmount = data.TotalAmount;
        }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);

            if (propertyName == nameof(AmountWithoutNds) || propertyName == nameof(NdsRate))
            {
                if (!model.ExecuteCalculation(AmountWithoutNds, NdsRate / 100))
                {
                    MessageBox.Show("Чё-то тут не так!");
                }
            }
        }
    }
}
