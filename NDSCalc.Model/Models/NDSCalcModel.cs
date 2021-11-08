using NDSCalc.Model.Structs;
using System;
using System.Threading.Tasks;

namespace NDSCalc.Model.Models
{
    public class NDSCalcModel
    {
        // Данные состояния Модели
        private CalculationData data;

        /// <summary>Событие извещающее об изменении данных.</summary>
        public event EventHandler DataChanged;

        /// <summary>Метод возвращающий данные Модели.</summary>
        /// <returns>Структура с Данными.</returns>
        public CalculationData GetData()
        {
            return data;
        }

        // Приватный асинхронный метод, который получает гарантированно
        // валидные данные и производит все вычисления.
        private Task ExecuteCalculationAsync(decimal amountWithoutNds, decimal ndsRate)
        {
            return Task.Run(() =>
                        {
                            decimal amountOfNds = amountWithoutNds * ndsRate;
                            data = new CalculationData
                            (
                                amountWithoutNds,
                                ndsRate,
                                amountOfNds,
                                amountWithoutNds + amountOfNds
                            );
                            DataChanged?.Invoke(this, EventArgs.Empty);
                        });
        }

        /// <summary>Публичный метод передающий порцию данных в Модель.</summary>
        /// <param name="amountWithoutNds">Сумма без НДС.</param>
        /// <param name="ndsRate">Ставка НДС.</param>
        /// <returns>Возвращает <see langword="true"/>, если данные валидны.</returns>
        public bool ExecuteCalculation(decimal amountWithoutNds, decimal ndsRate)
        {
            bool valid = amountWithoutNds > 0 && ndsRate > 0;
            if (valid)
            {
                _ = ExecuteCalculationAsync(amountWithoutNds, ndsRate);
            }

            return valid;
        }

    }
}
