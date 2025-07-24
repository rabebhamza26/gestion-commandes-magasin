using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gestion_commande
{
    public partial class gestionCommande : Form
    {
        private string FichierCommandes = "commandes.txt";
        private string FichierClients = "clients.txt";

        public gestionCommande()
        {
            InitializeComponent();
            ChargerClients();

        }

        private void ChargerClients()
        {
            // Charger les clients dans la ComboBox
            if (File.Exists(FichierClients))
            {
                comboBoxNomClient.Items.Clear();
                var lignes = File.ReadAllLines(FichierClients);
                comboBoxNomClient.Items.AddRange(lignes);
            }
        }



        private void buttonEnregistrer_Click(object sender, EventArgs e)
        {
            // Contrôle de saisie pour le numéro de commande
            var numeroCommande = textBoxNumérocommande.Text.Trim();
            if (string.IsNullOrEmpty(numeroCommande))
            {
                MessageBox.Show("Le numéro de commande est requis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Contrôle de saisie pour le client
            var NomClient = comboBoxNomClient.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(NomClient))
            {
                MessageBox.Show("Veuillez sélectionner un client.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Contrôle de saisie pour les produits
            if (dataGridViewProduit.Rows.Count == 0 || dataGridViewProduit.Rows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Veuillez ajouter au moins un produit.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var date = dateTimePickerCommande.Value.ToString("dd/MM/yyyy");

            using (var writer = new StreamWriter(FichierCommandes, true))
            {
                
                writer.WriteLine($"Numéro de commande: {numeroCommande}");
                writer.WriteLine($"Client : {NomClient}");
                writer.WriteLine($"Date : {date}");
                writer.WriteLine("Produit demandé :");

                foreach (DataGridViewRow row in dataGridViewProduit.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        var produit = row.Cells[0].Value.ToString();
                        var quantite = row.Cells[1].Value.ToString();

                        writer.WriteLine($"{produit} {quantite} ;");
                    }
                }

                writer.WriteLine(); 
            }

            MessageBox.Show("Commande enregistrée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            

        }

        private void gestion_commande_Load(object sender, EventArgs e)
        {

        }

        private void buttonAfficher_Click(object sender, EventArgs e)
        {
            var nom_produit = textBoxNomProduit.Text.Trim();
            var quantite = textBoxQuantite.Text.Trim();

            // Vérification des champs de produit
            if (string.IsNullOrEmpty(nom_produit) || nom_produit.Length > 20)
            {
                MessageBox.Show("Le nom du produit est invalide (maximum 20 caractères).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            // Ajouter une ligne au DataGridView
            dataGridViewProduit.Rows.Add(nom_produit, quantite);

            textBoxNomProduit.Clear();
            textBoxQuantite.Clear();


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        

        private void label5_Click(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        

        private void label6_Click(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();

        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }
    }
}
