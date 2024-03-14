using Pharmacy.BL.Interfaces;

namespace Pharmacy.BL.Models
{
    public class DaoFactory
    {
        public static IMedicineDao GetMedicineDao()
        {
            return new MedicineDao();
        }
    }
}
