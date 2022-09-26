using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaPlayerApp
{
    public partial class Form1 : Form
    {
        Timer t;
        
        public Form1()
        {
            InitializeComponent();

            
        }
        
        
        string[] paths, files;

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;

                for (int x = 0; x < files.Length; x++)
                {
                    listBox1.Items.Add(files[x]);
                }
            }

            //Müzikleri Import etmek için yazdığım kod alanı


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

             axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
            //Listbox mouse selected
        }

















       



        private void siticoneImageButton2_Click(object sender, EventArgs e)
        {

            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

      
        private void siticoneTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {

            axWindowsMediaPlayer1.settings.volume = siticoneTrackBar2.Value;
            siticoneTrackBar2.Minimum = 0;
            siticoneTrackBar2.Maximum = 100;

            //Volume TrackBar'ının kodları

        }



        private void siticoneImageButton6_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            pictureBox1.Hide();

            // Play ikonu kodları
        }




        private void siticoneImageButton4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }
            //Sıradaki şarkıya geçiş butonu kodları
        }

        private void siticoneImageButton5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)

            {
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;

            }
            // Bir önceki şarkıya geçiş butonu kodları
        }

        private void siticoneTrackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            siticoneTrackBar1.Value = 0;
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = axWindowsMediaPlayer1.currentMedia.duration * e.X / siticoneTrackBar1.Width;
        }

        private void axWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            if (axWindowsMediaPlayer1.openState == WMPLib.WMPOpenState.wmposMediaOpen)
            {
                siticoneTrackBar1.Maximum = (int)axWindowsMediaPlayer1.currentMedia.duration;
                t.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "";
            t = new Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(timer1_Tick);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            siticoneTrackBar1.Value = (int)this.axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
        }

        private void label7_Click(object sender, EventArgs e)
        {
          Form3 f3 = new Form3();
          f3.ShowDialog();  
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            lblPlaying.ForeColor = (lblPlaying.ForeColor = Color.Maroon);
            //görsel hover
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            lblPlaying.ForeColor = (lblPlaying.ForeColor = Color.LightCoral);
            //görsel hover
        }

        private void lblExplore_MouseHover(object sender, EventArgs e)
        {
            lblExplore.ForeColor = (lblExplore.ForeColor = Color.Maroon);
        }

        private void lblExplore_MouseLeave(object sender, EventArgs e)
        {
            lblExplore.ForeColor = (lblExplore.ForeColor = Color.LightCoral);
        }
        private void lblAlbum_MouseHover(object sender, EventArgs e)
        {
            
            lblAlbum.ForeColor = (lblAlbum.ForeColor = Color.Maroon);
        }

        private void lblAlbum_MouseLeave(object sender, EventArgs e)
        {
            lblAlbum.ForeColor = (lblAlbum.ForeColor = Color.LightCoral);
        }

        private void lblPlaylists_MouseHover(object sender, EventArgs e)
        {
            
            lblPlaylists.ForeColor = (lblPlaylists.ForeColor = Color.Maroon);
        }

        private void lblPlaylists_MouseLeave(object sender, EventArgs e)
        {
            lblPlaylists.ForeColor = (lblPlaylists.ForeColor = Color.LightCoral);
        }

     

       








    }
}





















