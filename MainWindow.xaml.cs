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

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }

        private void SetUpGame()
        {
            var matchList = InitiliseList();
            var random = new Random();

            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                if (matchList.Count <= 0)
                {
                    break;
                }

                var listIndex = random.Next(matchList.Count());
                string nextMatchedValue = matchList[listIndex];

                textBlock.Text = nextMatchedValue;
                matchList.RemoveAt(listIndex);
            }
        }
        private List<string> InitiliseList(string whatToMatch = "")
        {
            List<string> emojiList = new List<string>()
            {
                "🐱‍👓", "🐱‍👓",
                "🌹", "🌹",
                "👀", "👀",
                "🐱‍🚀", "🐱‍🚀",
                "🐱‍👤", "🐱‍👤",
                "❤", "❤",
                "🤷‍♂️", "🤷‍♂️",
                "🎂", "🎂",
                "🐱‍🏍", "🐱‍🏍",
                "🐱‍💻", "🐱‍💻",
            };

            List<string> numbersList = new List<string>()
            {
                "1", "1",
                "2", "2",
                "3", "3",
                "4", "4",
                "5", "5",
                "6", "6",
                "7", "7",
                "8", "8",
                "9", "9",
                "10", "10",
            };

            return emojiList;
        }

        private TextBlock lastTextBlockClicked;
        private bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var textBlock = sender as TextBlock;

            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textBlock;
                findingMatch = true;
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }
        }
    }
}
