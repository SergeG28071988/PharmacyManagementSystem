using Pharmacy.BL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy.BL.Models
{
    public class MedicineProcess : IMedicineProcess
    {
        private static readonly IDictionary<int, MedicineDto> Medications = new Dictionary<int, MedicineDto>();

        public IList<MedicineDto> GetList()
        {
            return new List<MedicineDto>(Medications.Values);
        }

        public MedicineDto Get(int id)
        {
            return Medications.ContainsKey(id) ? Medications[id] : null;
        }

        public void Add(MedicineDto medicine)
        {
            int max = Medications.Keys.Count == 0 ? 1 : Medications.Keys.Max(m => m) + 1;

            medicine.Id = max;
            Medications.Add(max, medicine);
        }

        public void Update(MedicineDto medicine)
        {
            if (Medications.ContainsKey(medicine.Id))
            {
                Medications[medicine.Id] = medicine;
            }
        }

        public void Delete(int id)
        {
            if(Medications.ContainsKey(id)) 
                Medications.Remove(id);
        }
    }
}
