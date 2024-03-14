using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Pharmacy.UI
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();

            AppDBContext db = new AppDBContext();
            List<User> users = db.Users.ToList();

            listofUsers.ItemsSource = users;
        }

        private void Button_Splash_Click(object sender, RoutedEventArgs e)
        {
            SplashForm splash = new SplashForm();
            splash.Show();
            Hide();
        }
    }
}
