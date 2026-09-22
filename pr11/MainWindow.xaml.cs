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
        public pr11.PersonInfo Enemy;

        public MainWindow()
        {
            InitializeComponent();
            UserInfoPlayr();

            Enemys.Add(new PersonInfo("Большой монстр", 150, 10, 1, 0, 15, 10));
            Enemys.Add(new PersonInfo("Средний монстр", 120, 15, 1, 0, 30, 15));
            Enemys.Add(new PersonInfo("Маленький монстр", 100, 20, 1, 0, 40, 20));

            dispatherTimer.Tick += AttackPlayer;
            dispatherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatherTimer.Start();

            SelectEnemy();
        }

        private void AttackPlayer(object sender, EventArgs e)
        {
            Player.Health -= Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));
            UserInfoPlayr();
        }

        public void SelectEnemy()
        {
            int id = new Random().Next(0, Enemys.Count);
            Enemy = new PersonInfo(
                Enemys[id].Name,
                Enemys[id].Health,
                Enemys[id].Armor,
                Enemys[id].Level,
                Enemys[id].Glasses,
                Enemys[id].Mony,
                Enemys[id].Damage
                );

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
