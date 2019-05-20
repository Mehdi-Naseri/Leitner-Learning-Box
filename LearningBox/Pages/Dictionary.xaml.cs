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

namespace LearningBox.Pages
{
    /// <summary>
    /// Interaction logic for Dictionary.xaml
    /// </summary>
    public partial class Dictionary : UserControl
    {
        public Dictionary()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    DictionaryDbContext dictionaryDbContext = new DictionaryDbContext();
        //    var value = dictionaryDbContext.DictionaryEnFas.FirstOrDefault(a => a.En == textboxEn.Text);
        //    if (value != null)
        //    {
        //        textblockFa.Text = value.Fa;
        //    }
        //}

        private void textboxEn_TextChanged(object sender, TextChangedEventArgs e)
        {
            DictionaryDbContext dictionaryDbContext = new DictionaryDbContext();
            var value = dictionaryDbContext.DictionaryEnFas.FirstOrDefault(a => a.En == textboxEn.Text);
            if (value != null)
            {
                textblockFa.Text = value.Fa;
            }
            else
            {
                textblockFa.Text = string.Empty;
            }
        }
    }
}
