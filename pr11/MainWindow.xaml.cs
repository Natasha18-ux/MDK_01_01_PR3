using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Windows.Threading;


namespace pr11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public PersonInfo Player = new PersonInfo("Student", 100, 10, 1,0, 0, 5);
        public List<PersonInfo> Enemys = new List<PersonInfo>();
        DispatcherTimer dispatherTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayr();

            Enemys.Add(new PersonInfo("Большой монстр", 150, 10, 1, 0, 15, 10));
            Enemys.Add(new PersonInfo("Средний монстр", 120, 15, 1, 0, 30, 15));
            Enemys.Add(new PersonInfo("Маленький монстр", 100, 20, 1, 0, 40, 20));

            dispatherTimer.Tick += AttackPlayer;
            dispatherTimer.Interval = new System.TimeSpan(0, 0, 10);
            dispatherTimer.Start();
        }

        private void AttackPlayer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


         public void UserInfoPlayr()
        {
            if (Player.Glasses > Player.Level * 100)
            {
                Player.Level++;
                Player.Glasses = 0;
                Player.Health += 100;
                Player.Damage++;
                Player.Armor++;
            }
            playerHealth.Content = "Жизненные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Mony;
        }

        private void AttackEnemy(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
