using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shell
{
    class DataSettings
    {
        protected static DataSettings settings;
        public List<ItemSettings> Items { get; set; }

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
            ItemSettings setting = new ItemSettings();
            setting.text = "Тестовая кнопка";
            //setting.img = "/home/boris/Изображения/!test/1200_2.jpg";
            setting.img = @"C:\Users\User\Pictures\Saved Pictures\icon_gampad.jpg";
            this.Items.Add(setting);
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
    }

    public class ItemSettings
    {
        public string text { get; set; }
        public string exeFile { get; set; }
        public string img { get; set; }
    }
}
