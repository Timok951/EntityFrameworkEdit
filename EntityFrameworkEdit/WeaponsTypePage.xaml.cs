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
    /// Логика взаимодействия для WeaponsTypePage.xaml
    /// </summary>
    public partial class WeaponsTypePage : Page
    {
        private GameEntities context = new GameEntities();

        public WeaponsTypePage()
        {
            InitializeComponent();
            WeaponsTypeGrid.ItemsSource = context.WeaponType.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (WeaponsTypeGrid.SelectedItem != null)
            {


                var selected = WeaponsTypeGrid.SelectedItem as WeaponType;



                selected.WeaponTypeName = WpnT.Text;
                selected.WeaponDameBonus = Convert.ToInt32(DmgB.Text);

                context.SaveChanges();
                WeaponsTypeGrid.ItemsSource = context.WeaponType.ToList();

            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            WeaponType weapontypes = new WeaponType();

            weapontypes.WeaponTypeName = WpnT.Text;
            weapontypes.WeaponDameBonus = Convert.ToInt32(DmgB.Text);
            context.WeaponType.Add(weapontypes);
            context.SaveChanges();
            WeaponsTypeGrid.ItemsSource = context.Weapon.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WeaponsTypeGrid.SelectedItem != null)
                {
                    context.WeaponType.Remove(WeaponsTypeGrid.SelectedItem as WeaponType);
                    context.SaveChanges();
                    WeaponsTypeGrid.ItemsSource = context.WeaponType.ToList();
                }
            }

            catch
            {
                MessageBox.Show("Using in another table");

            }
        }

        private void WeaponsTypeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WeaponsTypeGrid.SelectedItem != null)
            {
                var selected = WeaponsTypeGrid.SelectedItem as WeaponType;
                WpnT.Text = selected.WeaponTypeName;
                DmgB.Text = Convert.ToString(selected.WeaponDameBonus);
            }
        }
    }
}
