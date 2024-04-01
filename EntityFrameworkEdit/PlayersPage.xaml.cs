using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFrameworkEdit
{
    /// <summary>
    /// Логика взаимодействия для PlayersPage.xaml
    /// </summary>
    public partial class PlayersPage : Page
    {
        private GameEntities context = new GameEntities();

        public PlayersPage()
        {
            InitializeComponent();
            PlayersGrid.ItemsSource = context.Players.ToList();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (PlayersGrid.SelectedItem != null)
            {


                var selected = PlayersGrid.SelectedItem as Players;


                selected.PlayerName = PlrN.Text;
                selected.PlayerScore = Convert.ToInt32(PlrS.Text);
                selected.ID_Weapon = Convert.ToInt32(PlrW.Text);

                context.SaveChanges();
                PlayersGrid.ItemsSource = context.Weapon.ToList();

            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Players players = new Players();

            players.PlayerName = PlrN.Text;
            players.PlayerScore = Convert.ToInt32(PlrS.Text);
            players.ID_Weapon = Convert.ToInt32(PlrW.Text);
            context.Players.Add(players);
            context.SaveChanges();
            PlayersGrid.ItemsSource = context.Weapon.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PlayersGrid.SelectedItem != null)
                {
                    context.Players.Remove(PlayersGrid.SelectedItem as Players);
                    context.SaveChanges();
                    PlayersGrid.ItemsSource = context.Players.ToList();
                }
            }

            catch
            {
                MessageBox.Show("Using in another table");

            }
        }

        private void PlayersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PlayersGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (PlayersGrid.SelectedItem != null)
            {

                var selected = PlayersGrid.SelectedItem as Players;
                PlrN.Text = selected.PlayerName;
                PlrS.Text = Convert.ToString(selected.PlayerScore);
                PlrW.Text = Convert.ToString(selected.ID_Weapon);
            }
        }
    }
}
