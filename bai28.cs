using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace nguyenquocduong_2122110443 
{
    
    public partial class bai28 : Form
    {

        public bai28()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("../../Images/ba1.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Level2 level2 = new Level2();
            level2.Show();
        }
    }
}
        
    

