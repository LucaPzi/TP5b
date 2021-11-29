using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CombatClientSocketNaIn.Classes;


namespace CombatClientSocketNaIn
{
    public partial class frmClienSocketNain : Form
    {
        Random m_r;
        Elfe m_elfe;
        Nain m_nain;
        public frmClienSocketNain()
        {
            InitializeComponent();
            m_r = new Random();

            btnReset.Enabled = false;
            Control.CheckForIllegalCrossThreadCalls = false;

            Reset();
        }
        void Reset()
        {
            m_nain = new Nain(m_r.Next(10, 20), m_r.Next(2, 6), m_r.Next(0, 3));
            picNain.Image = m_nain.Avatar;
            lblVieNain.Text = "Vie: " + m_nain.Vie.ToString(); ;
            lblForceNain.Text = "Force: " + m_nain.Force.ToString();
            lblArmeNain.Text = "Arme: " + m_nain.Arme;

            m_elfe = new Elfe(1, 0, 0);
            picElfe.Image = m_elfe.Avatar;
            lblVieElfe.Text = "Vie: " + m_elfe.Vie.ToString();
            lblForceElfe.Text = "Force: " + m_elfe.Force.ToString();
            lblSortElfe.Text = "Sort: " + m_elfe.Sort.ToString();
        }

        private void btnFrappe_Click(object sender, EventArgs e)
        {
            Socket client;
            string envoie = m_nain.Vie.ToString() + ";" + m_nain.Force.ToString() + ";" + m_nain.Arme;
            string reponse = "aucune";
            int nbOctetReception;
            byte[] tByteReception = new byte[100];
            ASCIIEncoding textByte = new ASCIIEncoding();
            byte[] tByteEnvoie = textByte.GetBytes(envoie);

            string[] tReception;


            MessageBox.Show("assurez-vous que le serveur est en attente d'un client");
            try
            {
                // initialisation et connection du socket au serveur TCP
                client = new Socket(SocketType.Stream, ProtocolType.Tcp);
                client.Connect(IPAddress.Parse("127.0.0.1"), 7777);

                // vérification que la connection à fonctionné et traitement de transmission/réception
                if (client.Connected)
                {

                    //transmission
                    client.Send(tByteEnvoie);

                    Thread.Sleep(500);

                    // réception
                    nbOctetReception = client.Receive(tByteReception);

                    reponse = Encoding.ASCII.GetString(tByteReception);



                    tReception = reponse.Split(';');
                    //MessageBox.Show(tReception[0] + " " + tReception[1]);

                    m_nain.Vie = Convert.ToInt32(tReception[0]); // mettre a jour les points de vie du nain
                    m_nain.Force = Convert.ToInt32(tReception[1]); // mettre a jour la force du nain

                    lblVieNain.Text = "Vie: " + tReception[0];
                    lblForceNain.Text = "Force: " + tReception[1];
                    lblArmeNain.Text = "Arme: " + tReception[2];
                    lblVieElfe.Text = "Vie: " + tReception[3];
                    lblForceElfe.Text = "Force: " + tReception[4];
                    lblSortElfe.Text = "Sort: " + tReception[5];

                    // vérifier s'il y a un gagnant
                    // égalité
                    if (Convert.ToInt32(tReception[0]) <= 0 && Convert.ToInt32(tReception[3]) <= 0)
                    {
                        btnReset.Enabled = true;
                        btnFrappe.Enabled = false;
                        MessageBox.Show("Client: Égalité!!!");
                        return;
                    }
                    // l'elfe gagne
                    if (Convert.ToInt32(tReception[0]) <= 0)
                    {
                        btnReset.Enabled = true;
                        btnFrappe.Enabled = false;
                        picNain.Image = m_elfe.Avatar;
                        MessageBox.Show("Client: L'elfe gagne!");
                        return;
                    }
                    // le nain gagne
                    if (Convert.ToInt32(tReception[3]) <= 0)
                    {
                        btnReset.Enabled = true;
                        btnFrappe.Enabled = false;
                        picElfe.Image = m_nain.Avatar;
                        MessageBox.Show("Client: Le nain gagne!");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnFrappe.Enabled = true;
            btnReset.Enabled = false;
            Reset();
        }
    }
}
