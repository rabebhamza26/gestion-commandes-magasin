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
    public partial class gestionClients : Form
    {
        private string FichierClients = "clients.txt";

        public gestionClients()
        {
            InitializeComponent();
            ChargerClients();

        }

        // Méthode pour charger les clients depuis le fichier texte
        private void ChargerClients()
        {
            listBoxClient.Items.Clear();
            if (File.Exists(FichierClients))
            {
                var clients = File.ReadAllLines(FichierClients);
                listBoxClient.Items.AddRange(clients);
            }

        }

        

        private void gestion_clients_Load(object sender, EventArgs e)
        {
                        ChargerClients();
            listBoxClient.SelectedIndexChanged += listBoxClients_SelectedIndexChanged;

        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            string clientName = textBoxNomClient.Text.Trim(); // Récupérer le nom du client depuis le TextBox

            // Vérifier si le nom dépasse la limite de 20 caractères
            if (clientName.Length > 20)
            {
                MessageBox.Show("Le nom du client ne doit pas dépasser 20 caractères.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Vérifier si le champ n'est pas vide
            if (!string.IsNullOrEmpty(clientName))
            {
                // Ajouter le client au fichier
                File.AppendAllText(FichierClients, clientName + Environment.NewLine);
                ChargerClients(); // Recharger la liste des clients
                textBoxNomClient.Clear(); // Effacer le champ TextBox

                // Afficher une alerte de succès
                MessageBox.Show($"Le client '{clientName}' a été ajouté avec succès.", "Ajout réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Alerte si le champ est vide
                MessageBox.Show("Veuillez entrer un nom de client.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void listBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vérifier si un élément est sélectionné
            if (listBoxClient.SelectedIndex >= 0)
            {
                // Récupérer le nom du client sélectionné et l'afficher dans le TextBox
                textBoxNomClient.Text = listBoxClient.SelectedItem.ToString();
            }
        }


        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // Vérifier si un élément est sélectionné dans la ListBox
            if (listBoxClient.SelectedIndex >= 0)
            {
                int selectedIndex = listBoxClient.SelectedIndex;
                string Nom_precedent = listBoxClient.Items[selectedIndex].ToString(); 
                string Nom_suivant = textBoxNomClient.Text.Trim(); 

                // Vérifier que le nouveau nom est valide
                if (string.IsNullOrEmpty(Nom_suivant))
                {
                    MessageBox.Show("Veuillez entrer un nom de client valide.");
                    return;
                }

                if (Nom_suivant.Length > 20)
                {
                    MessageBox.Show("Le nom du client ne doit pas dépasser 20 caractères.");
                    return;
                }

                // Mettre à jour le client dans la ListBox
                listBoxClient.Items[selectedIndex] = Nom_suivant;

                // Mettre à jour le client dans le fichier
                var clients = File.ReadAllLines(FichierClients);
                clients[selectedIndex] = Nom_suivant; // Mise à jour de l'entrée correspondante
                File.WriteAllLines(FichierClients, clients); // Sauvegarder les modifications dans le fichier

                

                MessageBox.Show("Le client a été modifié avec succès !");
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client à modifier.");
            }
        }






        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (listBoxClient.SelectedIndex >= 0)
            {
                string clientNom = listBoxClient.SelectedItem.ToString(); 
                var clients = File.ReadAllLines(FichierClients); 
                var updatedClients = new List<string>(clients); 
                updatedClients.Remove(clientNom); // Supprimer le client sélectionné
                File.WriteAllLines(FichierClients, updatedClients); // Sauvegarder les modifications dans le fichier
                ChargerClients(); // Recharger la liste des clients dans la ListBox

                // Afficher une alerte de succès
                MessageBox.Show($"Le client '{clientNom}' a été supprimé avec succès.", "Suppression réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Alerte si aucun client n'est sélectionné
                MessageBox.Show("Veuillez sélectionner un client à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


       
        
       
        
        

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            gestionClients formClient = new gestionClients();
            formClient.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            gestionCommande formCammande = new gestionCommande();
            formCammande.Show();
        }
    }
}



