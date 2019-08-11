using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Shell
{
    class DataSettings
    {
        private static string startupPath;
        protected static DataSettings settings;
        public List<ItemSettings> Items { get; set; }

        public static string PathWork
        {
            get
            {
                if (startupPath == null)
                {
                    startupPath = System.IO.Directory.GetCurrentDirectory();
                }

                return startupPath;
            }
        }

        /// <summary>
        /// Получение объета с данными
        /// </summary>
        /// <returns></returns>
        public static DataSettings GetData()
        {
            if (DataSettings.settings != null)
            {
                return DataSettings.settings;
            }

            DataSettings.settings = new DataSettings();
            return DataSettings.settings;
        }

        private void FakeData()
        {
            for(int i = 0; i < 5; i++)
            {
                ItemSettings setting = new ItemSettings();
                setting.text = "Тестовая кнопка " + (i + 1);
                //setting.img = "/home/boris/Изображения/!test/1200_2.jpg";
                setting.img = @"icon_gampad.jpg";

                this.Items.Add(setting);
            }
        }

        /// <summary>
        /// Загражаем параметры
        /// </summary>
        public void LoadData()
        {          
            this.FakeData();
        }

        public DataSettings()
        {
            this.Items = new List<ItemSettings>();
            this.LoadData();
        }

        public int Count
        {
            get
            {
                return this.Items.Count;
            }
        }
    }

    public class ItemSettings
    {

        protected string GetWorkPath(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new System.Exception("Не указан файл");
            }

            if (File.Exists(path))
            {
                return path;
            }

            string newPath = DataSettings.PathWork + path;
            if (File.Exists(newPath)) {
                return newPath;
            }

            throw new System.Exception("Файл не найден: " + path);
        }

        public void Run()
        {
            if (String.IsNullOrEmpty(this.exeFile))
            {
                throw new System.Exception("Не указаан файл для запуска");
            }

            string executable = this.GetWorkPath(this.exeFile);

            Process process = new Process();
            process.StartInfo.FileName = executable;
            process.StartInfo.Arguments = this.exeArguments;
            process.StartInfo.ErrorDialog = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            process.Start();
            process.WaitForExit();
        }

        /// <summary>
        /// Рабочий путь до изображения
        /// </summary>
        /// <returns>The work image.</returns>
        public string getWorkPathImg()
        {
            return this.GetWorkPath(this.img);
        }

        public string text { get; set; }
        public string exeFile { get; set; }
        public string exeArguments { get; set; }
        public string img { get; set; }
    }
}
