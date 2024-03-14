using Pharmacy.BL.Entities;
using System.Collections.Generic;

namespace Pharmacy.BL.Interfaces
{
    /// <summary>
    /// Описание действий с объектом препарат в базе
    /// </summary>
    public interface IMedicineDao
    {
        /// <summary>
        /// Получить препарат по id 
        /// </summary>
        /// <param name="id">id препарата</param>
        /// <returns>препарат</returns>
        Medicine Get(int id);
        /// <summary>
        /// Получить список всех препаратов в базе
        /// </summary>
        /// <returns>список всех препаратов в базе</returns>
        IList<Medicine> GetAll();
        /// <summary>
        /// Добавить препарат в базу
        /// </summary>
        /// <param name="medicine">новый препарат</param>
        void Add(Medicine medicine);
        /// <summary>
        /// Обновить препарат
        /// </summary>
        /// <param name="medicine">обновленный препарат</param>
        void Update(Medicine medicine);
        /// <summary>
        /// Удалить препарат
        /// </summary>
        /// <param name="id">id удаляемого препарата</param>
        void Delete(int id);
    }
}
