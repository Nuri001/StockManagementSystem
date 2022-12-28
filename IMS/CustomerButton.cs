using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMS
{
    public partial class CustomerButton : PictureBox
    {
        public CustomerButton()
        {
            InitializeComponent();
        }


        public Boolean CurrentPage = false;
        private Image NormalImage;
        private Image HoverImage;


        public Image ImageNormal
        {
            get { return NormalImage; }
            set { NormalImage = value; }

        }
        public Image ImageHover
        {
            get { return HoverImage; }
            set { HoverImage = value; }

        }

        private void CustomerButton_MouseHover(object sender, EventArgs e)
        {
            if (!CurrentPage)
                this.Image = HoverImage;
        }

        private void CustomerButton_MouseLeave(object sender, EventArgs e)
        {
            if (!CurrentPage)
                this.Image = NormalImage;
        }


        public void makeCurrent(){
            this.Image = HoverImage;
            CurrentPage = true;        }

        public void makeNoteCurrent()
        {
            this.Image = NormalImage;
            CurrentPage = false;
        }


    }
}
