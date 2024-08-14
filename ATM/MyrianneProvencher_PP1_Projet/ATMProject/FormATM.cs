using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATMProject
{
    public partial class FormATM : Form
    {
        private string connectionString = "Data Source=DESKTOP-7H9TJC3\\SQLEXPRESS;Initial Catalog=ATMDatabase;Integrated Security=True;";
        private bool isEnteringID = true;


        public FormATM()
        {
            InitializeComponent();
            // Lier l'événement TextChanged de textBoxID pour détecter la fin de la saisie de l'ID
            textBoxID.TextChanged += textBoxID_TextChanged;

            // Empêcher la navigation vers le champ de texte de l'ID avec la souris
            textBoxID.TabStop = false;

            // Empêcher la navigation vers le champ de texte du PIN avec la souris
            textBoxPIN.TabStop = false;

            // Désactiver le changement de focus avec la souris et les modifications pour textBoxID & textBoxPIN
            textBoxID.ReadOnly = true; 
            textBoxID.Enabled = false;
            textBoxPIN.ReadOnly = true;
            textBoxPIN.Enabled = false;


        }

        private void NumericButton_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            if (btn != null)
            {
                
                if (!isEnteringID)
                {
                    // Ajouter le chiffre saisi au champ de texte du PIN
                    textBoxPIN.Text += btn.Text;
                }
                else
                {
                    // Ajouter le chiffre saisi au champ de texte de l'ID
                    textBoxID.Text += btn.Text;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            // Si l'utilisateur est en train de saisir l'ID
            if (isEnteringID)
            {
                string enteredID = textBoxID.Text;

                // Vérifier si l'ID est saisi
                if (string.IsNullOrEmpty(enteredID))
                {
                    MessageBox.Show("Veuillez saisir l'ID.");
                    return;
                }

                // Passer à la saisie du PIN
                isEnteringID = false;

                // Définir explicitement le focus sur textBoxPIN
                textBoxPIN.Focus();
            }
            else // Si l'utilisateur est en train de saisir le PIN
            {
                string enteredID = textBoxID.Text;
                string enteredPIN = textBoxPIN.Text;

                // Vérifier si les deux champs sont remplis pour validation
                if (!string.IsNullOrEmpty(enteredID) && !string.IsNullOrEmpty(enteredPIN))
                {
                    if (!ValidateIDAndPIN(enteredID, enteredPIN))
                    {
                        MessageBox.Show("L'ID ou le PIN est incorrect.");
                        return;
                    }

                    // Masquer les éléments et réinitialiser les champs de texte
                    HideElements();
                    ResetTextFields();

                    return; // Sortir de la méthode après avoir effectué les actions
                }

                MessageBox.Show("Veuillez saisir l'ID et le PIN.");
            }

        }

        private bool ValidateIDAndPIN(string id, string pin)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Customer WHERE CustomerId = @ID AND PIN = @PIN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@PIN", pin);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        private void HideElements()
        {
            labelID.Visible = false;
            textBoxID.Visible = false;
            labelPIN.Visible = false;
            textBoxPIN.Visible = false;
            //btnSave.Visible = false;
            //btnClear.Visible = false;
        }

        private void ResetTextFields()
        {
            textBoxID.Text = "";
            textBoxPIN.Text = "";
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            // Définir le focus sur le champ de texte du PIN après la saisie de l'ID
            textBoxPIN.Focus();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetTextFields(); // Réinitialiser les champs de texte
            isEnteringID = true; // Réinitialiser le mode de saisie à ID
            textBoxID.Focus(); // Remettre le focus sur le champ de texte de l'ID

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Réinitialiser les champs de texte
            ResetTextFields();

            // Réinitialiser le mode de saisie à ID
            isEnteringID = true;

            // Réafficher et réactiver les contrôles
            labelID.Visible = true;
            textBoxID.Visible = true;
            labelPIN.Visible = true;
            textBoxPIN.Visible = true;

            // Réinitialiser les TextBoxes pour les rendre modifiables et permettre la saisie
            textBoxID.ReadOnly = true;
            textBoxID.Enabled = false;
            textBoxPIN.ReadOnly = true;
            textBoxPIN.Enabled = false;

            // Empêcher la navigation vers le champ de texte avec la souris
            textBoxID.TabStop = false;
            textBoxPIN.TabStop = false;

            // Mettre le focus sur le champ de texte de l'ID
            textBoxID.Focus();

        }
    }
}
