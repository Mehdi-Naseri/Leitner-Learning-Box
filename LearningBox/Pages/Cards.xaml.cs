using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for LearningboxFull.xaml
    /// </summary>
    public partial class Cards : UserControl
    {
        private readonly LearningBoxDbContext _learningBoxDbContext = new LearningBoxDbContext();
        
        

        public Cards()
        {
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = cultureInfo;

            InitializeComponent();
        }

        private void UserControlCards_Loaded(object sender, RoutedEventArgs e)
        {
            int boxId = Properties.Settings.Default.DefaultBoxNumber;
            dataGridCards.ItemsSource = _learningBoxDbContext.Cards.Where(a => a.BoxId == boxId).ToList();
            TextBoxCardNumberTextChange();
            //datePicker.DisplayDate = DateTime.Now;
            datePicker.SelectedDate = DateTime.Today;


        }

        private void textBoxCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxCardNumberTextChange();
        }

        private void TextBoxCardNumberTextChange()
        {
            if (string.IsNullOrEmpty(textBoxCardNumber.Text))
            {
                ButtonCreateCard.IsEnabled = true;
                ButtonDeleteCard.IsEnabled = false;
                ButtonUpdateCard.IsEnabled = false;
            }
            else
            {
                ButtonCreateCard.IsEnabled = false;
                ButtonDeleteCard.IsEnabled = true;
                ButtonUpdateCard.IsEnabled = true;
            }
        }

        private void ButtonCreateCard_Click(object sender, RoutedEventArgs e)
        {
            if (!_learningBoxDbContext.Cards.Any(a => a.Question == textBoxQuestion.Text))
            {
                if (!string.IsNullOrEmpty(textBoxQuestion.Text) &&
                    !string.IsNullOrEmpty(textBoxAnswer.Text) &&
                    comboBoxGroupNumber.SelectedItem != null &&
                    datePicker.SelectedDate != null)
                {
                    Card card = new Card();
                    card.Question = textBoxQuestion.Text;
                    card.Answer = textBoxAnswer.Text;
                    card.GroupNumber = short.Parse(comboBoxGroupNumber.Text);
                    card.BoxId = Properties.Settings.Default.DefaultBoxNumber;
                    card.Date = datePicker.DisplayDate;
                    _learningBoxDbContext.Cards.Add(card);
                    _learningBoxDbContext.SaveChanges();

                    dataGridCards.ItemsSource = _learningBoxDbContext.Cards.ToList();
                    dataGridCards.Items.Refresh();

                    textBoxQuestion.Text = null;
                    textBoxAnswer.Text = null;
                    comboBoxGroupNumber.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("مقادیر ورودی به طور کامل وارد نشده اند.", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("کارتی با این سوال قبلا ساخته شده است.", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void ButtonUpdateCard_Click(object sender, RoutedEventArgs e)
        {
            int cardNumber = int.Parse(textBoxCardNumber.Text);
            if (_learningBoxDbContext.Boxes.Any(a => a.Id == cardNumber))
            {
                if (!string.IsNullOrEmpty(textBoxQuestion.Text) &&
                     !string.IsNullOrEmpty(textBoxAnswer.Text))
                {
                    if (!_learningBoxDbContext.Cards.Any(a => a.Question == textBoxQuestion.Text && a.Id != cardNumber))
                    {
                        Card card = _learningBoxDbContext.Cards.Find(cardNumber);
                        card.Question = textBoxQuestion.Text;
                        card.Answer = textBoxAnswer.Text;
                        card.GroupNumber = short.Parse(comboBoxGroupNumber.Text);
                        card.Date = datePicker.DisplayDate;
                        _learningBoxDbContext.SaveChanges();

                        dataGridCards.ItemsSource = _learningBoxDbContext.Cards.ToList();
                        dataGridCards.Items.Refresh();

                        textBoxQuestion.Text = null;
                        textBoxAnswer.Text = null;
                        comboBoxGroupNumber.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("این سوال قبلا ثبت گردیده است.", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    MessageBox.Show(" مقدار سوال یا پاسخ وارد نشده است.", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("جعبه ای با این شماره وجود ندارد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }

        private void ButtonDeleteCard_Click(object sender, RoutedEventArgs e)
        {
            int cardNumber = int.Parse(textBoxCardNumber.Text);
            if (_learningBoxDbContext.Cards.Any(a => a.Id == cardNumber))
            {
                Card card = _learningBoxDbContext.Cards.Find(cardNumber);
                _learningBoxDbContext.Cards.Remove(card);
                _learningBoxDbContext.SaveChanges();

                dataGridCards.ItemsSource = _learningBoxDbContext.Cards.ToList();
                dataGridCards.Items.Refresh();

                //textBoxcarName.Text = null;
            }
            else
            {
                MessageBox.Show("جعبه ای با این شماره وجود ندارد", "خطا", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
            }
        }
    }
}
