namespace Pharmacy.BL.Models
{
    /// <summary>
    /// Класс - препарат (лекарство) 
    /// </summary>
    public class MedicineDto
    {
        /// <summary>
        /// id препарата
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// наименование
        /// </summary>
        public string MedicineName { get; set; }
        /// <summary>
        /// дата заказа
        /// </summary>
        public int OrderDate { get; set; }
        /// <summary>
        /// дата поступления заказа
        /// </summary>
        public int? DeliveryDate { get; set; }
        /// <summary>
        /// категория
        /// </summary>
        public string Category { get; set; }
    }
}
