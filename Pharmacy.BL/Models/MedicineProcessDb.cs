using Pharmacy.BL.Interfaces;
using System.Collections.Generic;

namespace Pharmacy.BL.Models
{
    public class MedicineProcessDb : IMedicineProcess
    {
        private readonly IMedicineDao _medicineDao;
        public MedicineProcessDb()
        {
            // Получаем объект для работы с препаратом в базе
            _medicineDao = DaoFactory.GetMedicineDao();
        }       

        public IList<MedicineDto> GetList()
        {
            return DtoConverter.Convert(_medicineDao.GetAll());
        }

        public MedicineDto Get(int id)
        {
            return DtoConverter.Convert(_medicineDao.Get(id));
        }

        public void Add(MedicineDto medicine)
        {
            _medicineDao.Add(DtoConverter.Convert(medicine));   
        }

        public void Update(MedicineDto medicine)
        {
            _medicineDao.Update(DtoConverter.Convert(medicine));
        }

        public void Delete(int id)
        {
            _medicineDao.Delete(id);
        }
    }
}
