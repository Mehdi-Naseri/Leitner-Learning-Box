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
using LearningBox.Data.DbContext;
using LearningBox.Data.Models;

namespace LearningBox.Pages
{
    /// <summary>
    /// Interaction logic for Boxes.xaml
    /// </summary>
    public partial class Boxes : UserControl
    {
        private readonly LearningBoxDbContext _learningBoxDbContext = new LearningBoxDbContext();


        public Boxes()
        {
            InitializeComponent();

        }

        private void UserControlBoxes_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxActivebox.ItemsSource = _learningBoxDbContext.Boxes.Select(a => a.Name).ToList();
            dataGridBoxes.ItemsSource = _learningBoxDbContext.Boxes.ToList();
            TextBoxBoxNumberTextChange();

            int boxId = Properties.Settings.Default.DefaultBoxNumber;
            comboBoxActivebox.SelectedItem = _learningBoxDbContext.Boxes.Find(boxId);
        }

        private void buttonCreateBox_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxBoxName.Text))
            {

                if (!_learningBoxDbContext.Boxes.Any(a => a.Name == textBoxBoxName.Text))
                {
                    Box box = new Box();
                    box.Name = textBoxBoxName.Text;
                    _learningBoxDbContext.Boxes.Add(box);
                    _learningBoxDbContext.SaveChanges();

                    dataGridBoxes.ItemsSource = _learningBoxDbContext.Boxes.ToList();
                    dataGridBoxes.Items.Refresh();
                    comboBoxActivebox.ItemsSource = _learningBoxDbContext.Boxes.Select(a => a.Name).ToList();
                    textBoxBoxName.Text = null;
                }
                else
                {
                    MessageBox.Show("جعبه ای با این نام قبلا ساخته شده است.", "خطا", MessageBoxButton.OK,
                        MessageBoxImage.Error, MessageBoxResult.OK,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("نام جعبه وارد نشده است.", "خطا", MessageBoxButton.OK,
                       MessageBoxImage.Error, MessageBoxResult.OK,
                       MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void buttonUpdateBox_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxBoxName.Text))
            {
                int boxNumber = int.Parse(textBoxBoxNumber.Text);
                if (_learningBoxDbContext.Boxes.Any(a => a.Id == boxNumber))
                {
                    if (!_learningBoxDbContext.Cards.Any(a => a.Question == textBoxBoxName.Text && a.Id != boxNumber))
                    {
                        Box box = new Box();
                        box = _learningBoxDbContext.Boxes.FirstOrDefault(a => a.Id == boxNumber);
                        box.Name = textBoxBoxName.Text;
                        _learningBoxDbContext.SaveChanges();

                        dataGridBoxes.ItemsSource = _learningBoxDbContext.Boxes.ToList();
                        dataGridBoxes.Items.Refresh();
                        comboBoxActivebox.ItemsSource = _learningBoxDbContext.Boxes.Select(a => a.Name).ToList();
                        textBoxBoxName.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("جعبه ای با این نام قبلا ساخته شده است.", "خطا", MessageBoxButton.OK,
                            MessageBoxImage.Error, MessageBoxResult.OK,
                            MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    MessageBox.Show("جعبه ای با این شماره وجود ندارد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("نام جعبه وارد نشده است.", "خطا", MessageBoxButton.OK,
                       MessageBoxImage.Error, MessageBoxResult.OK,
                       MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void buttonDeleteBox_Click(object sender, RoutedEventArgs e)
        {
            int boxNumber = int.Parse(textBoxBoxNumber.Text);
            if (_learningBoxDbContext.Boxes.Any(a => a.Id == boxNumber))
            {
                Box box = new Box();
                box = _learningBoxDbContext.Boxes.Find(boxNumber);
                _learningBoxDbContext.Boxes.Remove(box);
                _learningBoxDbContext.SaveChanges();

                dataGridBoxes.ItemsSource = _learningBoxDbContext.Boxes.ToList();
                dataGridBoxes.Items.Refresh();
                comboBoxActivebox.ItemsSource = _learningBoxDbContext.Boxes.Select(a => a.Name).ToList();
                textBoxBoxName.Text = null;
            }
            else
            {
                MessageBox.Show("جعبه ای با این شماره وجود ندارد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void textBoxBoxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxBoxNumberTextChange();
        }

        private void TextBoxBoxNumberTextChange()
        {
            if (string.IsNullOrEmpty(textBoxBoxNumber.Text))
            {
                buttonCreateBox.IsEnabled = true;
                buttonDeleteBox.IsEnabled = false;
                buttonUpdateBox.IsEnabled = false;
            }
            else
            {
                buttonCreateBox.IsEnabled = false;
                buttonDeleteBox.IsEnabled = true;
                buttonUpdateBox.IsEnabled = true;
            }
        }

        private void comboBoxActivebox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.DefaultBoxNumber = _learningBoxDbContext.Boxes.FirstOrDefault(a => a.Name == comboBoxActivebox.SelectedItem.ToString()).Id;
        }
    }
}
