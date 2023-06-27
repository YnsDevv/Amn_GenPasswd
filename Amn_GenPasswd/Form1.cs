using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Amn_GenPasswd
{
    public partial class Form1 : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        public static bool special_charactere;
        public static bool minuscule;
        public static bool majuscule;
        public static bool num;
        public static int lenght;
        public static int number_of_password;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += MainForm_MouseDown;
            special_charactere = guna2CheckBox_special_character.Checked;
            minuscule = guna2CheckBox_minuscule.Checked;
            majuscule = guna2CheckBox_majuscule.Checked;
            num = guna2CheckBox_number.Checked;
        }
        private void ForMain_Load(object sender, EventArgs e)
        {
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void guna2CircleButton_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void guna2CircleButton_hide_Click(object sender, EventArgs e)
        {
            // Minimiser l'application dans la barre des tâches
            this.WindowState = FormWindowState.Minimized;
        }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void guna2GroupBox_options_Click(object sender, EventArgs e)
        {
        }
        private void guna2GradientCircleButton_Gen_Click(object sender, EventArgs e)
        {
            GenPasswd();
        }

        private void GenPasswd()
        {
            try
            {
                number_of_password = int.Parse(guna2TextBox_number_of_password.Text);
                lenght = int.Parse(guna2TextBox_many_passwordguna2TextBox_lenght.Text);
                string[] passwords = Amn_GenPasswd.Outils.GeneratePasswords(number_of_password, lenght);
                string concatenedStr = String.Join("," + Environment.NewLine, passwords);
                guna2TextBox_textbox_gen.Text = concatenedStr;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur : veuillez cochez au moins une case s'ils vous plait !", "by amn...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2TextBox_textbox_gen_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2CheckBox_special_character_CheckedChanged(object sender, EventArgs e)
        {
            special_charactere = guna2CheckBox_special_character.Checked;
        }

        private void guna2CheckBox_number_CheckedChanged(object sender, EventArgs e)
        {
            num = guna2CheckBox_number.Checked;
        }

        private void guna2CheckBox_majuscule_CheckedChanged(object sender, EventArgs e)
        {
            majuscule = guna2CheckBox_majuscule.Checked;
        }

        private void guna2CheckBox_minuscule_CheckedChanged(object sender, EventArgs e)
        {
            minuscule = guna2CheckBox_minuscule.Checked;
        }

        private void guna2TextBox_number_of_password_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2HScrollBar_gen_passwd_Scroll(object sender, ScrollEventArgs e)
        {
            GenPasswd();
        }

        private void guna2CircleButton_about_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
    }
}