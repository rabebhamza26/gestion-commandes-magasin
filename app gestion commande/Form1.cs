using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gestion_commande
{
    public partial class Form1 : Form
    {

        private DateTime startTime;
        private bool isRunning = false;  // Assuming you have a way to control this.

        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Naviguer vers Form
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                TimeSpan elapsedTime = DateTime.Now - startTime;
                labeldateheur.Text = string.Format("Temps écoulé: {0:hh\\:mm\\:ss}", elapsedTime);
            }

            // Affichage de l'heure et de la date système
            labeldateheur.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labeldateheur.Text = "00:00:00";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Naviguer vers Form
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Naviguer vers Form
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }

        private void labeldateheur_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            // Naviguer vers Form
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Naviguer vers Form
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void pictureBox2_Click_3(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }
    }
}
