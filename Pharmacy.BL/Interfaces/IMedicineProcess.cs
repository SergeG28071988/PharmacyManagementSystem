using Pharmacy.BL.Models;
using System.Collections.Generic;

namespace Pharmacy.BL.Interfaces
{
    /// <summary>
    /// Декларация действий по работе с препаратом
    /// </summary>
    public interface IMedicineProcess
    {
        /// <summary>
        /// Возвращает список препаратов
        /// </summary>
        /// <returns>список препаратов</returns>
        IList<MedicineDto> GetList();
        /// <summary>
        /// Возвращает препарат по id 
        /// </summary>
        /// <param name="id">id препарата</param>
        /// <returns>Препарат</returns>
        MedicineDto Get(int id);
        /// <summary>
        /// Добавляет препарат
        /// </summary>
        /// <param name="medicine"></param>
        void Add(MedicineDto medicine);
        /// <summary>
        /// Обновляет данные о препарате
        /// </summary>
        /// <param name="medicine">Препарат, изменения которого надо сохранить</param>
        void Update(MedicineDto medicine);
        /// <summary>
        /// Удаляет препарат
        /// </summary>
        /// <param name="id">id препарата, который надо удалить</param>
        void Delete(int id);    
    }
}
