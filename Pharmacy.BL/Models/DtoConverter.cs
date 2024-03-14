using System.Collections.Generic;
using Pharmacy.BL.Entities;


namespace Pharmacy.BL.Models
{
    public class DtoConverter
    {
        public static MedicineDto Convert(Medicine medicine)
        {
            if (medicine == null) return null;            
            MedicineDto medicineDto = new MedicineDto();
            medicineDto.Id = medicine.MedicineId;
            medicineDto.MedicineName = medicine.MedicineName;
            medicineDto.OrderDate = medicine.OrderDate;
            medicineDto.DeliveryDate = medicine.DeliveryDate;
            medicineDto.Category = medicine.Category;
            return medicineDto;
        }

        public static Medicine Convert(MedicineDto medicineDto)
        {
            if (medicineDto == null) return null;
            Medicine medicine = new Medicine();
            medicine.MedicineId = medicineDto.Id;
            medicine.MedicineName = medicineDto.MedicineName;
            medicine.OrderDate = medicineDto.OrderDate;
            medicine.DeliveryDate = medicineDto.DeliveryDate;
            medicine.Category = medicineDto.Category;
            return medicine;
        }

        public static IList<MedicineDto> Convert(IList<Medicine> medicines)
        {
            if (medicines == null) return null;
            IList<MedicineDto> medicineDtos = new List<MedicineDto>();
            foreach(var medicine in medicines)
            {
                medicineDtos.Add(Convert(medicine));
            }
            return medicineDtos;
        }
    }
}
