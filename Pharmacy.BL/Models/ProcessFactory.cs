using Pharmacy.BL.Interfaces;


namespace Pharmacy.BL.Models
{
    /// <summary>
    /// Фабрика классов бизнес-логики
    /// </summary>
    public class ProcessFactory
    {
        /// <summary>
        /// Возвращает объект, реализующий <seealso cref="IMedicineProcess"/>
        /// </summary>
        /// <returns></returns>
        public static IMedicineProcess GetMedicineProcess() { return new MedicineProcessDb(); }
    }
}
