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
using CombatServeurSocketElfe.Classes;

namespace CombatServeurSocketElfe
{
    public partial class frmServeurSocketElfe : Form
    {
        Random m_r;
        Nain m_nain;
        Elfe m_elfe;
        TcpListener m_ServerListener;
        Socket m_client;
        Thread m_thCombat;

        public frmServeurSocketElfe()
        {
            InitializeComponent();
            m_r = new Random();
            
            btnReset.Enabled = false;

            //Démarre un serveur de socket (TcpListener)
            m_ServerListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7777);
            m_ServerListener.Start();

            lstReception.Items.Add("Serveur démarré !");
            lstReception.Items.Add("PRESSER : << attendre un client >>");
            lstReception.Update();
            Control.CheckForIllegalCrossThreadCalls = false;

            Reset();
        }
        void Reset()
        {
            m_nain = new Nain(1, 1, 0);
            picNain.Image = m_nain.Avatar;
            AfficheStatNain();

            m_elfe = new Elfe(m_r.Next(10, 20), m_r.Next(2, 6), m_r.Next(2, 6));
            picElfe.Image = m_elfe.Avatar;
            AfficheStatElfe();
        }

        void AfficheStatNain()
        {
            lblVieNain.Text = "Vie: " + m_nain.Vie.ToString();
            lblForceNain.Text = "Force: " + m_nain.Force.ToString();
            lblArmeNain.Text = "Arme: " + m_nain.Arme.ToString();

            this.Update(); // pour s'assurer de l'affichage via le thread
        }
        void AfficheStatElfe()
        {
            lblVieElfe.Text = "Vie: " + m_elfe.Vie.ToString();
            lblForceElfe.Text = "Force: " + m_elfe.Force.ToString();
            lblSortElfe.Text = "Sort: " + m_elfe.Sort.ToString();

            this.Update(); // pour s'assurer de l'affichage via le thread
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            Reset();
            lstReception.Items.Clear();
        }     

        private void btnAttente_Click(object sender, EventArgs e)
        {
            // Combat par un thread
            Combat();
        }
        public void Combat() 
        {
            // déclarations de variables locales 
            string reponseServeur = "aucune";
            string receptionClient = "rien";
            int nbOctetReception;
            int noArme = 0, vie = 0, force = 0;
            string arme = "";
            byte[] tByteReception = new byte[50];
            ASCIIEncoding textByte = new ASCIIEncoding();
            byte[] tByteEnvoie;

            string[] tReception;

            try
            {
                // tous le code de traitement
                // en boucle jusqu'à ce que l'elfe soit mort ou le nain soit mort
                while (m_nain.Vie > 0 && m_elfe.Vie > 0)
                {
                    // attend une connexion cliente socket
                    m_client = m_ServerListener.AcceptSocket(); // (bloquant)

                    lstReception.Items.Add("Client branché!");
                    lstReception.Update();
                    Thread.Sleep(500);

                    // reçoit les données cliente (nain)
                    nbOctetReception = m_client.Receive(tByteReception);
                    receptionClient = Encoding.ASCII.GetString(tByteReception);

                    lstReception.Items.Add("du client: " + receptionClient);
                    lstReception.Update();
                    // split sur le ';' pour récupérer les données d'un nain
                    tReception = receptionClient.Split(';');

                    lblVieNain.Text = tReception[0];
                    lblForceNain.Text = tReception[1];
                    lblArmeNain.Text = tReception[2];

                    //m_nain = new Nain(vie, force, noArme);
                    m_nain.Vie = Convert.ToInt32(tReception[0]);
                    m_nain.Force = Convert.ToInt32(tReception[1]);
                    m_nain.Arme = tReception[2];

                    AfficheStatNain();

                    // exécute Frapper
                    MessageBox.Show("Serveur: Frapper l'elfe ");
                    m_nain.Frapper(m_elfe);

                    // affiche les données de l'elfe membre
                    AfficheStatElfe();

                    // exécute LancerSort
                    MessageBox.Show("Serveur: Lancer un sort au nain");
                    m_elfe.LancerSort(m_nain);
                    // affiche les données au nain et de l'elfe membre
                    AfficheStatNain();
                    AfficheStatElfe();

                    // envoie les données au client sous cette forme:
                    // vieNain; forceNain; armeNain | vieElfe; forceElfe; sortElfe;
                    reponseServeur = m_nain.Vie.ToString() + ";" + m_nain.Force.ToString() + ";" + m_nain.Arme + ";" +
                                     m_elfe.Vie.ToString() + ";" + m_elfe.Force.ToString() + ";" + m_elfe.Sort.ToString();


                    lstReception.Items.Add(reponseServeur);
                    lstReception.Update();



                    tByteEnvoie = textByte.GetBytes(reponseServeur);



                    m_client.Send(tByteEnvoie);
                    Thread.Sleep(500);
                    

                    // vérifie s'il y a un gagnant

                    // En cas d'égalité
                    if (m_nain.Vie <= 0 && m_elfe.Vie <= 0)
                    {
                        btnReset.Enabled = true;
                        MessageBox.Show("Serveur: Égalité!!!");
                        return;
                    }

                    // Si le nain gagne
                    if (m_elfe.Vie <= 0)
                    {
                        btnReset.Enabled = true;
                        picElfe.Image = m_nain.Avatar;
                        MessageBox.Show("Serveur: Le nain a gagné!!!");
                        return;
                    }

                    // Si l'elfe gagne
                    if (m_nain.Vie <= 0)
                    {
                        btnReset.Enabled = true;
                        picNain.Image = m_elfe.Avatar;
                        MessageBox.Show("Serveur: L'elfe a gagné!!!");
                        return;
                    }
                    // ferme le socket
                    m_client.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            // il faut avoir un objet elfe et un objet nain instanciés
            m_elfe.Vie = 0;
            m_nain.Vie = 0;
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void frmServeurSocketElfe_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnFermer_Click(sender,e);
            try
            {
                // il faut avoir un objet TCPListener existant
                m_ServerListener.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}
