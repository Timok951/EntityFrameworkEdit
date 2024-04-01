using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Логика взаимодействия для WeaponsPage.xaml
    /// </summary>
    public partial class WeaponsPage : Page
    {
        private GameEntities context = new GameEntities();

        public WeaponsPage()
        {
            InitializeComponent();
            WeaponsGrid.ItemsSource = context.Weapon.ToList();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (WeaponsGrid.SelectedItem != null)
            {


                var selected = WeaponsGrid.SelectedItem as Weapon;


                selected.WeaponName = WpnN.Text;
                selected.WeaponDamage = Convert.ToInt32(WpnD.Text);
                selected.IDWeaponType = Convert.ToInt32(WpnT.Text);

                context.SaveChanges();
                WeaponsGrid.ItemsSource = context.Weapon.ToList();

            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {

            Weapon weapon = new Weapon();

            weapon.WeaponName = WpnN.Text;
            weapon.WeaponDamage = Convert.ToInt32(WpnD.Text);
            weapon.IDWeaponType =Convert.ToInt32(WpnT.Text) ;
            context.Weapon.Add(weapon);
            context.SaveChanges();
            WeaponsGrid.ItemsSource = context.Weapon.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WeaponsGrid.SelectedItem != null)
                {
                    context.Weapon.Remove(WeaponsGrid.SelectedItem as Weapon);
                    context.SaveChanges();
                    WeaponsGrid.ItemsSource = context.Weapon.ToList();
                }
            }

            catch {
                MessageBox.Show("Using in another table");

            }
        }

        private void WeaponsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (WeaponsGrid.SelectedItem != null)
            {
                var selected = WeaponsGrid.SelectedItem as Weapon;
                WpnN.Text = selected.WeaponName;
                WpnD.Text = Convert.ToString(selected.WeaponDamage);
                WpnT.Text = Convert.ToString(selected.IDWeaponType);
            }
        }
    }
}
