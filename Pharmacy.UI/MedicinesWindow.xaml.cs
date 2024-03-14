using Pharmacy.BL.Models;
using System.Windows;

namespace Pharmacy.UI
{
    /// <summary>
    /// Логика взаимодействия для MedicinesWindow.xaml
    /// </summary>
    public partial class MedicinesWindow : Window
    {
        public MedicinesWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMedicinesWindow window = new AddMedicinesWindow();
            window.ShowDialog();

            // Получаем список товаров и передаем его на отображение таблице
            dgMedications.ItemsSource = ProcessFactory.GetMedicineProcess().GetList();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            // Получаем список товаров и передаем его на отображение таблице
            dgMedications.ItemsSource = ProcessFactory.GetMedicineProcess().GetList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выделенную строку с объектом товар
            MedicineDto item = dgMedications.SelectedItem as MedicineDto;
            // если там не товар или пользователь ничего не выбрал сообщаем об этом
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление товара");
            }
            // Просим подтвердить удаление
            MessageBoxResult result = MessageBox.Show("Удалить товар " + item.MedicineName + "?",
                "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            // Если пользователь не подтвердил, выходим
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            // Если все проверки пройдены и подтверждение получено, удаляем товар
            ProcessFactory.GetMedicineProcess().Delete(item.Id);
            // И перезагружаем список товаров
            BtnRefresh_Click(sender, e);
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выделенную строку с объектом товара 
            // если там не товар или пользователь ничего не выбрал сообщаем об этом
            if (!(dgMedications.SelectedItem is MedicineDto item))
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            // Создаем окно
            AddMedicinesWindow window = new AddMedicinesWindow();
            // Передаем объект на редактирование
            window.Load(item);
            // Отображаем окно с данными
            window.ShowDialog();
            // Перезагружаем список объектов
            BtnRefresh_Click(sender, e);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            Hide();
        }
    }
}
