using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Shell
{

    class CreateOnForm
    {
        private Form form;
        private int _height;
        private DataSettings _data;

        /// <summary>
        /// Высота кнопки
        /// </summary>
        /// <value>The height button.</value>
        public int HeightButton
        {
            get
            {
                if (this._height != 0)
                {
                    return this._height;
                }

                this._height = (int)(form.Height / this._data.Count);
                return this._height;
            }
        }

        public CreateOnForm(Form form)
        {
            this.form = form;

            this._data = DataSettings.GetData();
            for (int i = 0; i < this._data.Items.Count; i++)
            {
                this.CreateButton(this._data.Items[i], i);
            }
        }

        private void CreateButton(ItemSettings item, int num)
        {
            Button button = new Button();
            button.Text = item.text;
            button.Parent = this.form;

            button.Location = new System.Drawing.Point(0, num * this.HeightButton);
            button.Width = this.form.Width;
            button.Height = this.HeightButton;
            button.Click += delegate(object sender, EventArgs e) {
                clickButton(sender, e, item);
            };

            button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
             | System.Windows.Forms.AnchorStyles.Right)));

            if (!String.IsNullOrEmpty(item.img))
            {
                button.BackgroundImage = Image.FromFile(item.getWorkPathImg());
                button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            }
        }

        private void clickButton(object sender, EventArgs e, ItemSettings item)
        {
            if (String.IsNullOrEmpty(item.exeFile))
            {
                MessageBox.Show("Не указан файл для запуска для кнопки: " + item.text);
                return;
            }

            item.Run();
        }
    }
}
