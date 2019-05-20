using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Read : UserControl
    {
        private readonly DictionaryDbContext _dictionaryDbContext = new DictionaryDbContext();
        private readonly LearningBoxDbContext _learningBoxDbContext = new LearningBoxDbContext();
        private int _boxNumber = Properties.Settings.Default.DefaultBoxNumber;
        private List<Card> _cards2Read;
        private int _cards2ReadIndex = 0;
        private int _cards2ReadCount;

        public Read()
        {
            InitializeComponent();
        }

        private void userControlRead_Loaded(object sender, RoutedEventArgs e)
        {
            //IQueryable<Cards> allCards = 
            _cards2Read = _learningBoxDbContext.Cards.Where(a => a.BoxId == _boxNumber &&
                (
                    (a.GroupNumber == 1 && SqlFunctions.DateDiff("day", a.Date ,DateTime.Now )  >= 2 ) ||
                    (a.GroupNumber == 2 && SqlFunctions.DateDiff("day", a.Date, DateTime.Now) >= 4) ||
                    (a.GroupNumber == 3 && SqlFunctions.DateDiff("day", a.Date, DateTime.Now) >= 8) ||
                    (a.GroupNumber == 4 && SqlFunctions.DateDiff("day", a.Date, DateTime.Now) >= 16) ||
                    (a.GroupNumber == 5 && SqlFunctions.DateDiff("day", a.Date, DateTime.Now) >= 32) ||
                    (a.GroupNumber == 6 && SqlFunctions.DateDiff("day", a.Date, DateTime.Now) >= 180)
                )
            ).OrderByDescending(r => r.GroupNumber).ToList();

            _cards2ReadCount = _cards2Read.Count;
            progressBar1.Maximum = _cards2ReadCount;
            if (_cards2ReadCount > 0)
            {
                textBoxQuestion.Text = _cards2Read[0].Question;
                buttonAnswer.Visibility = Visibility.Visible;
            }
            else
            {
                buttonAnswer.Visibility = Visibility.Hidden;
            }
            buttonCorrect.Visibility = Visibility.Hidden;
            buttonUncorrect.Visibility = Visibility.Hidden;

            Window parentWindow = Window.GetWindow(this);
            parentWindow.Topmost = true;
        }

        private void buttonAnswer_Click(object sender, RoutedEventArgs e)
        {
            textBoxAnswer.Text = _cards2Read[_cards2ReadIndex].Answer;
            if (_dictionaryDbContext.DictionaryEnFas.Any(a => a.En == textBoxQuestion.Text))
            {
                textBoxDictionary.Text = _dictionaryDbContext.DictionaryEnFas.FirstOrDefault(a => a.En == textBoxQuestion.Text).Fa;
            }
            buttonAnswer.Visibility = Visibility.Hidden;
            buttonCorrect.Visibility = Visibility.Visible;
            buttonUncorrect.Visibility = Visibility.Visible;
        }

        private void buttonCorrect_Click(object sender, RoutedEventArgs e)
        {
            Card cardCurrent =
                _learningBoxDbContext.Cards.FirstOrDefault(
                    a => a.Question == textBoxQuestion.Text && a.BoxId == _boxNumber);
            cardCurrent.Date = DateTime.Now;
            if (cardCurrent.GroupNumber < 6)
            {
                cardCurrent.GroupNumber++;
            }

            if (_learningBoxDbContext.Scores.Any(r => r.BoxId == _boxNumber && r.Date == DateTime.Now))
            {
                Score score =_learningBoxDbContext.Scores.Where(r => r.BoxId == _boxNumber && r.Date == DateTime.Now).FirstOrDefault();
                score.AllAnswers++;
                score.CorrectAnswers++;
            }
            else
            {
                Score score = new Score();
                score.AllAnswers = 1;
                score.CorrectAnswers = 1;
                score.BoxId = _boxNumber;
                score.Date = DateTime.Now;
                _learningBoxDbContext.Scores.Add(score);
            }

            _learningBoxDbContext.SaveChanges();

            DisplayNextCard();
        }

        private void buttonUncorrect_Click(object sender, RoutedEventArgs e)
        {
            Card cardCurrent = _learningBoxDbContext.Cards.FirstOrDefault(a => a.Question == textBoxQuestion.Text && a.BoxId == _boxNumber);
            cardCurrent.Date = DateTime.Now;
            cardCurrent.GroupNumber = 1;

            if (_learningBoxDbContext.Scores.Any(r => r.BoxId == _boxNumber && r.Date == DateTime.Now))
            {
                Score score = _learningBoxDbContext.Scores.Where(r => r.BoxId == _boxNumber && r.Date == DateTime.Now).FirstOrDefault();
                score.AllAnswers++;
            }
            else
            {
                Score score = new Score();
                score.AllAnswers = 1;
                score.CorrectAnswers = 0;
                score.BoxId = _boxNumber;
                _learningBoxDbContext.Scores.Add(score);
            }

            _learningBoxDbContext.SaveChanges();

            DisplayNextCard();
        }

        private void buttonVoice_Click(object sender, RoutedEventArgs e)
        {
            SpeechLib.SpVoice SpVoice1 = new SpeechLib.SpVoice();
            SpVoice1.Speak(textBoxQuestion.Text);
        }

        private void MenuItemBoxes_Click(object sender, RoutedEventArgs e)
        {
            int[] groupWordsCount = new int[7];
            var cards = _learningBoxDbContext.Cards.Where(a => a.BoxId == _boxNumber);
            groupWordsCount[0] = cards.Count(a => a.GroupNumber == 0);
            groupWordsCount[1] = cards.Count(a => a.GroupNumber == 1);
            groupWordsCount[2] = cards.Count(a => a.GroupNumber == 2);
            groupWordsCount[3] = cards.Count(a => a.GroupNumber == 3);
            groupWordsCount[4] = cards.Count(a => a.GroupNumber == 4);
            groupWordsCount[5] = cards.Count(a => a.GroupNumber == 5);
            groupWordsCount[6] = cards.Count(a => a.GroupNumber == 6);

            string messageText = "گروه 0:   " + groupWordsCount[0] +
                "\nگروه 1:   " + groupWordsCount[1] +
                "\nگروه 2:   " + groupWordsCount[2] +
                "\nگروه 3:   " + groupWordsCount[3] +
                "\nگروه 4:   " + groupWordsCount[4] +
                "\nگروه 5:   " + groupWordsCount[5] +
                "\nگروه 6:   " + groupWordsCount[6];

            MessageBox.Show(messageText, "گروهای کارتها", MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        private void DisplayNextCard()
        {
            buttonCorrect.Visibility = Visibility.Hidden;
            buttonUncorrect.Visibility = Visibility.Hidden;
            textBoxQuestion.Text = string.Empty;
            textBoxAnswer.Text = string.Empty;
            textBoxDictionary.Text = string.Empty;

            _cards2ReadIndex++;
            progressBar1.Value = _cards2ReadIndex;


            if (_cards2ReadIndex < _cards2ReadCount)
            {
                textBoxQuestion.Text = _cards2Read[_cards2ReadIndex].Question;
                buttonAnswer.Visibility = Visibility.Visible;
            }
        }

        private void progressBar1_MouseEnter(object sender, MouseEventArgs e)
        {
            progressBar1.ToolTip = _cards2ReadIndex + "/" + _cards2ReadCount;
        }

        private void menuItemOnTop_Checked(object sender, RoutedEventArgs e)
        {
            //this.Parent.Topmost = true;
            //windowPageSwitcher.Topmost = true;
            //Window parentWindow = Window.GetWindow(this);
            //parentWindow.Topmost = true;
            try
            {
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Topmost = true;
            }
            catch
            { }
        }

        private void menuItemOnTop_Unchecked(object sender, RoutedEventArgs e)
        {
            //this.Topmost = false;
            Window parentWindow = Window.GetWindow(userControlRead);
            parentWindow.Topmost = false;
        }

        private void buttonJump100_Click(object sender, RoutedEventArgs e)
        {
            _cards2ReadIndex += 99;
            DisplayNextCard();
        }
    }
}

