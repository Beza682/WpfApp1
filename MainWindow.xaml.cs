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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        gr691_baoEntities1 db = new gr691_baoEntities1();

        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click_Ins_Directory(object sender, RoutedEventArgs e)
        {
            DirButton dirButton = new DirButton();
            dirButton.Insert(ID_D.Text, (CbDir.SelectedItem as Organization).Id, Work_Phone_D.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            DirGrid.ItemsSource = db.Search.ToList();
        }

        private void Button_Click_Del_Directory(object sender, RoutedEventArgs e)
        {
            DirButton dirButton = new DirButton();
            dirButton.Delete(ID_D.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            DirGrid.ItemsSource = db.Search.ToList();
        }

        private void Button_Click_Up_Directory(object sender, RoutedEventArgs e)
        {
            DirButton dirButton = new DirButton();
            dirButton.Update(ID_D.Text, (CbDir.SelectedItem as Organization).Id, Work_Phone_D.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            DirGrid.ItemsSource = db.Search.ToList();
        }

        private void Button_Click_Ins_Organization(object sender, RoutedEventArgs e)
        {
            OrgButton orgButton = new OrgButton();
            orgButton.Insert(Organization_O.Text,(CbOrg.SelectedItem as FieldOfActivity).Id, The_address_O.Text, Working_hours_O.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            CbOrg.SelectedIndex = -1;
            OrgGrid.ItemsSource = db.Organization.ToList();

        }

        private void Button_Click_Del_Organization(object sender, RoutedEventArgs e)
        {
            OrgButton orgButton = new OrgButton();
            orgButton.Delete(ID_O.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            OrgGrid.ItemsSource = db.Organization.ToList();
        }

        private void Button_Click_Up_Organization(object sender, RoutedEventArgs e)
        {
            OrgButton orgButton = new OrgButton();
            orgButton.Update(ID_O.Text, Organization_O.Text, (CbOrg.SelectedItem as FieldOfActivity).Id, The_address_O.Text, Working_hours_O.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            OrgGrid.ItemsSource = db.Organization.ToList();
        }


        private void Button_Click_Ins_Field_of_activity(object sender, RoutedEventArgs e)
        {
            FOAButton foa  = new FOAButton();
            foa.Insert(ID_FOA.Text, Field_of_activity_FOA.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            FOAGrid.ItemsSource = db.FieldOfActivity.ToList();
        }

        private void Button_Click_Del_Field_of_activity(object sender, RoutedEventArgs e)
        {
            FOAButton foa = new FOAButton();
            foa.Delete(ID_FOA.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            FOAGrid.ItemsSource = db.FieldOfActivity.ToList();
        }

        private void Button_Click_Up_Field_of_activity(object sender, RoutedEventArgs e)
        {
            FOAButton foa = new FOAButton();
            foa.Update(ID_FOA.Text, Field_of_activity_FOA.Text);
            gr691_baoEntities1 db = new gr691_baoEntities1();
            FOAGrid.ItemsSource = db.FieldOfActivity.ToList();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string WK = Search.Text;
            SearchGrid.ItemsSource = db.Search.Where(w => w.WorkPhone.Contains(WK) || w.Organization.Organization1.Contains(WK)).ToList();
        }

        private void CbOrg_Loaded(object sender, RoutedEventArgs e)
        {
            CbOrg.ItemsSource = db.FieldOfActivity.ToList();
        }

        private void CbDir_Loaded(object sender, RoutedEventArgs e)
        {
            CbDir.ItemsSource = db.Organization.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_baoEntities1();
            FOAGrid.ItemsSource = db.FieldOfActivity.ToList();
            OrgGrid.ItemsSource = db.Organization.ToList();
            DirGrid.ItemsSource = db.Search.ToList();
            SearchGrid.ItemsSource = db.Search.ToList();
            CbOrg.ItemsSource = db.FieldOfActivity.ToList();
            CbDir.ItemsSource = db.Organization.ToList();
        }
    }
}
