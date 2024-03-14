using System.Windows;
using Pharmacy.BL.Models;
using Pharmacy.BL.Interfaces;
using System.Linq;

namespace Pharmacy.UI
{
    /// <summary>
    /// Логика взаимодействия для AddMedicinesWindow.xaml
    /// </summary>
    public partial class AddMedicinesWindow : Window
    {
        /// <summary>
        /// Список вида товаров
        /// </summary>
        private static readonly string[] Categories = { "Твердая форма", "Жидкая форма", "Специальная форма" };
        /// <summary>
        ///  Поле хранит идентификатор товара
        /// </summary>
        private int _id;
        public AddMedicinesWindow()
        {
            InitializeComponent();
            // Передаем допустимые значения
            cbCategory.ItemsSource = Categories;
            // Задаем начальное значение
            cbCategory.SelectedIndex = 0;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int? delivery = null; 

            if (string.IsNullOrEmpty(tbMedicineName.Text))
            {
                MessageBox.Show("Поле наименование не может быть пустым", "Проверка");
                return;
            }           

            if (!int.TryParse(tbOrderDate.Text, out int order))
            {
                MessageBox.Show("Дата заказа должна быть целым числом", "Проверка");
                return;
            }

            if (!string.IsNullOrEmpty(tbDeliveryDate.Text))
            {
                int intDelivery; 
                if (!int.TryParse(tbDeliveryDate.Text, out intDelivery))
                {
                    MessageBox.Show("Дата поставки должна быть целым числом", "Проверка");
                    return;
                }

                if (intDelivery < order)
                {
                    MessageBox.Show("Дата поставки должны быть больше даты заказа", "Проверка");
                    return;
                }
                delivery = intDelivery;
            }

            // Создаем объект для передачи данных
            MedicineDto medicine = new MedicineDto()
            {
                // Заполняем объект данными
                MedicineName = tbMedicineName.Text,                
                OrderDate = order,
                DeliveryDate = delivery,
                Category = cbCategory.SelectedItem.ToString()
            };
            // Именно тут запрашиваем реализованную раннее задачу по работе с товарами 
            IMedicineProcess medicineProcess = ProcessFactory.GetMedicineProcess();
            // если это новый объект -  сохраняем его
            if (_id == 0)
            {
                // Сохраняем товар
                medicineProcess.Add(medicine);
            }
            else // иначе обновляем
            {
                // копируем обратно идентификатор объекта
                medicine.Id = _id;
                // обновляем
                medicineProcess.Update(medicine);
            }
            // и закрываем форму
            Close();
        }

        public void Load(MedicineDto medicine)
        {
            // если объект не существует или его тип не в списке допустимых, выходим
            if (medicine == null || !Categories.Contains(medicine.Category))
            {
                return;
            }
            // сохраняем id нагрузки
            _id = medicine.Id;
            // заполняем визуальные компоненты для отображения данных
            tbMedicineName.Text = medicine.MedicineName;
            
            tbOrderDate.Text = medicine.OrderDate.ToString();
            if (medicine.DeliveryDate.HasValue)
            {
                tbDeliveryDate.Text = medicine.DeliveryDate.Value.ToString();
            }
            cbCategory.SelectedItem = medicine.Category;
        }
    }
}
