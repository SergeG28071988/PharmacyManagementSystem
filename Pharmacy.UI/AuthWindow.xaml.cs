using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Pharmacy.UI
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле заполнено неверно";
                textBoxLogin.Background = Brushes.Gray;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле заполнено неверно";
                passBox.Background = Brushes.Gray;
            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;

                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authuser = null;

                using (AppDBContext db = new AppDBContext())
                {
                    authuser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authuser != null)
                {
                    MessageBox.Show("Всё хорошо!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Проверьте введенные данные еще раз! Вы ввели что-то не так!");
            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
    }
}
