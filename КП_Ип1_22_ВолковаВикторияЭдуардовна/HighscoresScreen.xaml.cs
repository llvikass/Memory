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
using System.Windows.Shapes;
using System.Xml;

namespace КП_Ип1_22_ВолковаВикторияЭдуардовна
{
    /// <summary>
    /// Логика взаимодействия для HighscoresScreen.xaml
    /// </summary>
    public partial class HighscoresScreen : Page
    {
        Frame parentFrame;

        /// <summary>
        ///     Initialize a new highscores screen.
        /// </summary>
        /// <param name="parentFrame">The Frame to navigate between pages.</param>
        /// <param name="saveFile">The save file that contains the highscores.</param>
        /// <param name="highscoresElement">The root element of the save file.</param>
        public HighscoresScreen(Frame parentFrame, XmlDocument saveFile, XmlNode highscoresElement)
        {
            InitializeComponent();

            this.parentFrame = parentFrame;

            generateList(saveFile, highscoresElement);
        }

        /// <summary>
        ///     The click event of the back button.
        ///     This navigates to the main menu.
        /// </summary>
        /// <param name="sender">The object that is being clicked on.</param>
        /// <param name="args">The event arguments.</param>
        private void Back_Button_Click(object sender, RoutedEventArgs args)
        {
            this.parentFrame.Navigate(new MainMenu(this.parentFrame));
        }

        /// <summary>
        ///     Generate the highscores list.
        /// </summary>
        /// <param name="saveFile">The save file that contains the highscores.</param>
        /// <param name="highscoresElement">The root element of the save file.</param>
        private void generateList(XmlDocument saveFile, XmlNode highscoresElement)
        {
            // Create the row definitions of the list.
            for (int i = 0; i < 10; i++)
            {
                scoreGrid.RowDefinitions.Add(new RowDefinition());
            }

            // Create the column definitions of the list.
            for (int i = 0; i < 3; i++)
            {
                scoreGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Populate the list.
            for (int row = 0; row < highscoresElement.ChildNodes.Count; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    TextBlock text = new TextBlock();
                    text.TextAlignment = TextAlignment.Center;
                    text.FontFamily = new FontFamily("Arial");
                    text.Foreground = new SolidColorBrush(Colors.White);
                    text.FontSize = 30;
                    Border border = new Border()
                    {
                        BorderThickness = new Thickness()
                        {
                            Bottom = (row == 9) ? 2 : 1,
                            Top = (row == 0) ? 2 : 1,
                        },
                        BorderBrush = new SolidColorBrush(Colors.White)
                    };

                    switch (col)
                    {
                        // Rank
                        case 0:
                            text.Text = (row + 1).ToString();
                            break;
                        // Player name
                        case 1:
                            text.Text = highscoresElement.ChildNodes.Item(row).ChildNodes.Item(0).InnerText;
                            break;
                        // Score
                        case 2:
                            text.Text = highscoresElement.ChildNodes.Item(row).ChildNodes.Item(1).InnerText;
                            break;
                    }

                    Grid.SetColumn(text, col);
                    Grid.SetRow(text, row);
                    scoreGrid.Children.Add(text);

                    Grid.SetColumn(border, col);
                    Grid.SetRow(border, row);
                    scoreGrid.Children.Add(border);
                }
            }

        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double widthRatio = e.NewSize.Width / 800; // Исходная ширина окна
            double heightRatio = e.NewSize.Height / 450;

            // Пропорциональное изменение размера шрифта для всех кнопок в StackPanel
            foreach (var child in parentCanvas.Children)
            {
                if (child is Button button)
                {
                    button.FontSize = 16 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Width = 150 * widthRatio; // Изменяем размер шрифта кнопок
                    button.Height = 30 * widthRatio; // Изменяем размер шрифта кнопок
                }
                else if (child is TextBlock textBlock)
                {
                    textBlock.FontSize = 16 * widthRatio; // Изменяем размер шрифта для текстовых полей
                }
            }
        }
    }
}
