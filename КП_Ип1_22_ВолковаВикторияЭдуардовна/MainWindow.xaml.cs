﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Media;
namespace КП_Ип1_22_ВолковаВикторияЭдуардовна
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer;

        public MainWindow()
        {
            InitializeComponent(); parentFrame.Content = new MainMenu(parentFrame);
            PlayBackgroundMusic();
        }
        private void PlayBackgroundMusic()
        {
            mediaPlayer = new MediaPlayer();
            string relativePath = "Res\\Music\\background_music.mp3"; // Относительный путь к вашему аудиофайлу
            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath); // Получаем полный путь
            mediaPlayer.Open(new Uri(fullPath));
            mediaPlayer.Volume = 0.3; // Уровень громкости (0.0 - 1.0)
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded; // Обработчик окончания воспроизведения
            mediaPlayer.Play();
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero; // Возвращаемся к началу аудиофайла
            mediaPlayer.Play(); // Повторное воспроизведение
        }

        protected override void OnClosed(EventArgs e)
        {
            mediaPlayer.Stop(); // Остановка воспроизведения при закрытии окна
            mediaPlayer.Close();
            base.OnClosed(e);
        }
    }
}
