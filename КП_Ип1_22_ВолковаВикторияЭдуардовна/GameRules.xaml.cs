using System.Windows;
using System.Windows.Controls;

namespace КП_Ип1_22_ВолковаВикторияЭдуардовна
{
    /// <summary>
    /// Логика взаимодействия для GameRules.xaml
    /// </summary>
    public partial class GameRules : Page
    {
        Frame parentFrame;

        /// <summary>
        ///     Initialize the game rules page.
        /// </summary>
        /// <param name="parentFrame">The Frame to navigate between pages.</param>
        public GameRules(Frame parentFrame)
        {
            InitializeComponent();

            this.parentFrame = parentFrame;
        }

        /// <summary>
        ///     The click event to return to the main menu.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        private void returntoMenu_Button(object sender, RoutedEventArgs args)
        {
            this.parentFrame.Navigate(new MainMenu(this.parentFrame));
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double widthRatio = e.NewSize.Width / 800; // Исходная ширина окна
            double heightRatio = e.NewSize.Height / 450;

            // Пропорциональное изменение размера шрифта для всех кнопок в StackPanel
            foreach (var child in rules.Children)
            {
                if (child is Button button)
                {
                    button.FontSize = 16 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Width = 150 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Height = 30 * widthRatio; // Изменяем размер шрифта кнопок
                }
                else if (child is TextBlock textBlock)
                {
                    textBlock.FontSize = 20 * widthRatio; // Изменяем размер шрифта для текстовых полей
                }
            }
        }
    }
}
