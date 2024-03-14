using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Pharmacy.BL.Entities;
using Pharmacy.BL.Interfaces;

namespace Pharmacy.BL.Models
{
    public class MedicineDao : IMedicineDao
    {
        public Medicine Get(int id)
        {
            // Получаем объект подключения к базе
            using (var conn = GetConnection())
            {
                // Открываем соедитение
                conn.Open();
                // Создаем sql команду
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT MedicineId, MedicineName, OrderDate, " +
                        "DeliveryDate, Category FROM Medications WHERE MedicineId = @id";
                    // Добавляем значение параметра
                    cmd.Parameters.AddWithValue("@id", id);
                    // Открываем SqlDataReader для чтения полученных в результате выполнения запроса данных
                    using (var dataReader = cmd.ExecuteReader())
                    {
                        return !dataReader.Read() ? null : MedicineLoad(dataReader);
                    }
                }
            }
        }

        public IList<Medicine> GetAll()
        {
            IList<Medicine> medicines = new List<Medicine>();
            using (var conn = GetConnection())
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT MedicineId, MedicineName, OrderDate, DeliveryDate, Category FROM Medications";
                    using(var dataReader = cmd.ExecuteReader())
                    {
                        while(dataReader.Read())
                        {
                            medicines.Add(MedicineLoad(dataReader));
                        }
                    }
                }
            }
            return medicines;                      
        }

        public void Add(Medicine medicine)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Medications (MedicineName, OrderDate, DeliveryDate, Category) " +
                        "VALUES (@MedicineName, @OrderDate, @DeliveryDate, @Category)";
                    cmd.Parameters.AddWithValue("@MedicineName", medicine.MedicineName);
                    cmd.Parameters.AddWithValue("@OrderDate", medicine.OrderDate);
                    cmd.Parameters.AddWithValue("@Category", medicine.Category);
                    object delivery = medicine.DeliveryDate.HasValue ? 
                        (object)medicine.DeliveryDate.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DeliveryDate", delivery);
                    cmd.ExecuteNonQuery();  
                }
            }
        }

        public void Update(Medicine medicine)
        {
            using(var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Medications SET MedicineName = @MedicineName, OrderDate = @OrderDate, " +
                        "DeliveryDate = @DeliveryDate, Category = @Category WHERE MedicineId = @id";
                    cmd.Parameters.AddWithValue("@MedicineName", medicine.MedicineName);
                    cmd.Parameters.AddWithValue("@OrderDate", medicine.OrderDate);
                    cmd.Parameters.AddWithValue("@id", medicine.MedicineId);
                    cmd.Parameters.AddWithValue("@Category", medicine.Category);
                    object delivery = medicine.DeliveryDate.HasValue ?
                        (object)medicine.DeliveryDate.Value : DBNull.Value;
                    cmd.Parameters.AddWithValue("@DeliveryDate", delivery);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Medications WHERE MedicineId = @id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();  
                }
            }
        }

        private static Medicine MedicineLoad(SqlDataReader reader)
        {
            // Создаем пустой объект
            Medicine medicine = new Medicine();
            // Заполняем поля объекта в соответствии с названиями полей
            // результирующего набора данных
            medicine.MedicineId = reader.GetInt32(reader.GetOrdinal("MedicineId"));
            medicine.OrderDate = Convert.ToInt32(reader["OrderDate"]);
            // Помните, что у нас поле DeliveryDate может иметь значение NULL?
            // Следующие три строки корректно обрабатывают этот случай
            object delivery = reader["DeliveryDate"];
            if (delivery != DBNull.Value)
                medicine.DeliveryDate = Convert.ToInt32(delivery);
            medicine.MedicineName = reader.GetString(reader.GetOrdinal("MedicineName"));
            medicine.Category = reader.GetString(reader.GetOrdinal("Category"));

            return medicine;
        }

        /// <summary>
        /// Возвращает строку подключения к базе
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Accounting"].ConnectionString;
        }

        /// <summary>
        /// Возвращает объект подключения к базе
        /// </summary>
        /// <returns></returns>
        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }        
    }
}
