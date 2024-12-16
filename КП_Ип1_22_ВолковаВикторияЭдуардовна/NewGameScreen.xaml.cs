using КП_Ип1_22_ВолковаВикторияЭдуардовна.Properties;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace КП_Ип1_22_ВолковаВикторияЭдуардовна
{
    /// <summary>
    /// Логика взаимодействия для NewGameScreen.xaml
    /// </summary>
    public partial class NewGameScreen : Page
    {
        // The Frame to navigate between pages.
        Frame parentFrame;

        /// <summary>
        ///     Initialize a new new game screen.
        /// </summary>
        /// <param name="parentFrame">The Frame to navigate between pages.</param>
        public NewGameScreen(Frame parentFrame)
        {
            InitializeComponent();

            this.parentFrame = parentFrame;
        }

        /// <summary>
        ///     The click event for the start button.
        ///     This checks if the inputs are not empty and starts the game.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="e">The event arguments.</param>
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(InputP1.Text) || string.IsNullOrEmpty(InputP2.Text))
            {
                MessageBox.Show("Введите ник игрока");
                return;
            }

            string difficulty = Moeilijkheidsgraad.SelectedValue.ToString();
            int pairs;
            Player player1 = new Player(InputP1.Text, 0, true);
            Player player2 = new Player(InputP2.Text, 0, true);

            this.parentFrame.Navigate(new GameScreen(parentFrame, player1, player2, difficulty));
        }

        /// <summary>
        ///     The click event for the close popup button.
        ///     This closes the popup.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="e">The event arguments.</param>
        public void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        /// <summary>
        ///     The click event for the show popup button.
        ///     This opens the popup to select a theme.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="e">The event arguments.</param>
        public void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
        }

        /// <summary>
        ///     The load event for the dropdown in the popup.
        /// </summary>
        /// <param name="sender">The object that is being loaded.</param>
        /// <param name="e">The event arguments.</param>
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            //Get the ComboBox reference.
            var comboBox = sender as ComboBox;

            //Make the first item selected.
            comboBox.SelectedIndex = 0;
        }

        /// <summary>
        ///     The selection changed event for the dropdown.
        ///     This saves the selected value to the settings file.
        /// </summary>
        /// <param name="sender">The object where the selection is being changed.</param>
        /// <param name="e">The event arguments.</param>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the ComboBox.
            var comboBox = sender as ComboBox;

            int value = comboBox.SelectedIndex + 1;
            Settings.Default["ThemeNumber"] = value;
            Settings.Default.Save();
        }

        /// <summary>
        ///     The click event for the back button.
        ///     This navigates to the main menu.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        public void BackButtonClick(object sender, RoutedEventArgs args)
        {
            this.parentFrame.Navigate(new MainMenu(this.parentFrame));
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            /*double newWidth = e.NewSize.Width;
            double newHeight = e.NewSize.Height;

            NewGame.Width = newWidth * 0.35; // Пропорция для ширины StackPanel
            double fontSize = newHeight * 0.05; // Пример: 5% от высоты окна

            foreach (var child in NewGame.Children)
            {
                if (child is Button button)
                {
                    button.FontSize = fontSize;
                }
            }*/
        }

        private void page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            /*double widthRatio = e.NewSize.Width / 600; // Исходная ширина окна
            double heightRatio = e.NewSize.Height / 400; // Исходная высота окна

            // Пропорциональное изменение размеров элементов
            backButton.Width = 100 * widthRatio;
            backButton.Height = 30 * heightRatio;

            bt.Width = 100 * widthRatio;
            bt.Height = 30 * heightRatio;

           tb1.FontSize = 20 * Math.Min(widthRatio, heightRatio);

            StartButton.Width = 100 * widthRatio;
            StartButton.Height = 30 * heightRatio;

            label1.FontSize = 20 * Math.Min(widthRatio, heightRatio); // Изменяем размер шрифта пропорционально
           // label1.Margin = new Thickness(10 * widthRatio, 50 * heightRatio, 10 * widthRatio, 10 * heightRatio);

            label2.FontSize = 20 * Math.Min(widthRatio, heightRatio); // Изменяем размер шрифта пропорционально
           // label2.Margin = new Thickness(10 * widthRatio, 50 * heightRatio, 10 * widthRatio, 10 * heightRatio);

            label3.FontSize = 20 * Math.Min(widthRatio, heightRatio); // Изменяем размер шрифта пропорционально
           // label3.Margin = new Thickness(10 * widthRatio, 50 * heightRatio, 10 * widthRatio, 10 * heightRatio);


            Moeilijkheidsgraad.Width = 130 * widthRatio;
            Moeilijkheidsgraad.Height = 40 * heightRatio;
            Moeilijkheidsgraad.FontSize = 20 * Math.Min(widthRatio, heightRatio); // Изменяем размер шрифта пропорционально*/

            double widthRatio = e.NewSize.Width / 800; // Исходная ширина окна
            double heightRatio = e.NewSize.Height / 450;

            // Пропорциональное изменение размера шрифта для всех кнопок в StackPanel
            foreach (var child in NewGame.Children)
            {
                if (child is Button button)
                {
                    button.FontSize = 16 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Width = 150 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Height = 30 * widthRatio; // Изменяем размер шрифта кнопок
                }
                else if (child is Label label)
                {
                    label.FontSize = 20 * widthRatio; // Изменяем размер шрифта для меток
                }
                else if (child is TextBlock textBlock)
                {
                    textBlock.FontSize = 16 * widthRatio; // Изменяем размер шрифта для текстовых полей
                }
            }
        }
    }
}
