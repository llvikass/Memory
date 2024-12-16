using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace КП_Ип1_22_ВолковаВикторияЭдуардовна
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        Frame parentFrame;

        public MainMenu(Frame parentFrame)
        {
            InitializeComponent();

            this.parentFrame = parentFrame;

        }

        /// <summary>
        ///     The click event for the new game button.
        ///     This navigates to the new game screen.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        private void newGameButton_Click(object sender, RoutedEventArgs args)
        {
            this.parentFrame.Navigate(new NewGameScreen(this.parentFrame));
        }

        /// <summary>
        ///     The click event of the continue button.
        ///     This reads the save file and checks if it exists and it is valid.
        ///     If it is falid, then it navigates to the game screen.
        ///     And if it's not valid, it shows a messagebox.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        private void continueButton_Click(object sender, RoutedEventArgs args)
        {
            if (!File.Exists("Saves/memory.sav"))
            {
                MessageBox.Show("Файл для хранения не найден. Начните новую игру.", "Продолжить");
            }
            else
            {
                XmlDocument saveFile = new XmlDocument();
                saveFile.Load("Saves/memory.sav");

                XmlNode player1Element = saveFile.GetElementsByTagName("player").Item(0);
                XmlNode player2Element = saveFile.GetElementsByTagName("player").Item(1);
                XmlNode cardsElement = saveFile.GetElementsByTagName("cards").Item(0);

                // Check if the save file contains the right elements.
                if (player1Element == null || player2Element == null || cardsElement == null)
                {
                    MessageBox.Show("Не удалось прочитать сохраненный файл.", "Продолжить");
                }
                else
                {
                    this.parentFrame.Navigate(new GameScreen(this.parentFrame, saveFile, player1Element, player2Element, cardsElement));
                }
            }
        }

        /// <summary>
        ///     The click event for the highscores button.
        ///     This reads the save file and checks if it exists and it is valid.
        ///     If it is falid, then it navigates to the highscores screen.
        ///     And if it's not valid, it shows a messagebox.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        private void highscoresButton_Click(object sender, RoutedEventArgs args)
        {
            if (!File.Exists("Saves/scores.sav"))
            {
                MessageBox.Show("Файл сохранения не найден.", "Лидеры");
            }
            else
            {
                XmlDocument saveFile = new XmlDocument();
                saveFile.Load("Saves/scores.sav");

                var highscoresElement = saveFile.GetElementsByTagName("highscores").Item(0);

                // Check if the save file contains the right elements.
                if (highscoresElement == null)
                {
                    MessageBox.Show("Файл сохранения не найден.", "Рекорды");
                }
                else
                {
                    this.parentFrame.Navigate(new HighscoresScreen(this.parentFrame, saveFile, highscoresElement));
                }
            }
        }

        /// <summary>
        ///     The click event for the shutdown button.
        ///     This exits the application.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        private void shutdownButton_Click(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        ///     The click event for the game rules button.
        ///     This navigates to the game rules screen.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        private void gameRulesButton_Click(object sender, RoutedEventArgs args)
        {
            this.parentFrame.Navigate(new GameRules(this.parentFrame));
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double widthRatio = e.NewSize.Width / 800; // Исходная ширина окна
            double heightRatio = e.NewSize.Height / 450;

            // Пропорциональное изменение размера шрифта для всех кнопок в StackPanel
            foreach (var child in menu.Children)
            {
                if (child is Button button)
                {
                    button.FontSize = 14 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Width = 200 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Height = 30 * widthRatio; // Изменяем размер шрифта кнопок
                }
            }
        }

        private void menu_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
