using System;
using System.Drawing;
using System.Windows.Forms;

namespace SecurITMemory
{
    public partial class Form1 : Form
    {
        private JeuMemory jeu;
        private TableLayoutPanel grille;
        private Label lblEssais, lblTemps, lblMode, lblPaires;
        private Timer timerChrono, timerRetourner;

        private Carte c1 = null, c2 = null;
        private PictureBox pb1 = null, pb2 = null;

        private int essais = 0, secondes = 0, taille = 4, paires = 0;
        private bool blocage = false;

        public Form1()
        {
            InitializeComponent();
            UI();
        }

        private void UI()
        {
            Controls.Clear();
            Text = "SecurIT Memory";
            Size = new Size(1150, 850);
            BackColor = Color.FromArgb(10, 10, 20);

            Panel top = new Panel();
            top.Dock = DockStyle.Top;
            top.Height = 90;
            top.BackColor = Color.FromArgb(25, 25, 45);
            Controls.Add(top);

            lblEssais = Label("Essais : 0", 30);
            lblTemps = Label("Temps : 00:00", 180);
            lblMode = Label("Mode : 4x4", 350);
            lblPaires = Label("Paires : 0", 520);

            top.Controls.Add(lblEssais);
            top.Controls.Add(lblTemps);
            top.Controls.Add(lblMode);
            top.Controls.Add(lblPaires);

            top.Controls.Add(Btn("Jouer", 650, Color.FromArgb(0, 150, 255), (s, e) => Start()));
            top.Controls.Add(Btn("Recommencer", 780, Color.FromArgb(255, 180, 0), (s, e) => Start()));
            top.Controls.Add(Btn("Mode", 930, Color.FromArgb(140, 80, 200), Mode));
            top.Controls.Add(Btn("Comment jouer", 1080, Color.FromArgb(80, 80, 80), Help));
            top.Controls.Add(Btn("Quitter", 1230, Color.FromArgb(220, 50, 50), (s, e) => Application.Exit()));

            grille = new TableLayoutPanel();
            grille.Location = new Point(80, 140);
            grille.Size = new Size(960, 620);
            Controls.Add(grille);
        }

        private Label Label(string t, int x)
        {
            return new Label
            {
                Text = t,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(x, 30),
                AutoSize = true
            };
        }

        private Button Btn(string t, int x, Color c, EventHandler a)
        {
            Button b = new Button();
            b.Text = t;
            b.Size = new Size(130, 42);
            b.Location = new Point(x, 25);
            b.BackColor = c;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;

            b.MouseEnter += (s, e) => b.BackColor = ControlPaint.Light(c);
            b.MouseLeave += (s, e) => b.BackColor = c;

            b.Click += a;
            return b;
        }

        private void Help(object sender, EventArgs e)
        {
            MessageBox.Show(
                "🎮 BUT DU JEU\n\n" +
                "- Trouver toutes les paires\n" +
                "- Cliquer sur 2 cartes\n" +
                "- Si elles sont identiques → elles restent\n" +
                "- Sinon → elles se retournent\n\n" +
                "🏆 Moins d'essais = meilleur score",
                "Comment jouer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void Mode(object sender, EventArgs e)
        {
            var choix = MessageBox.Show(
                "Choisir la difficulté :\n\n" +
                "OUI = Mode facile (4x4)\n" +
                "NON = Mode difficile (6x6)",
                "Mode de jeu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            taille = choix == DialogResult.Yes ? 4 : 6;
            lblMode.Text = "Mode : " + taille + "x" + taille;
        }

        private void Start()
        {
            essais = 0;
            secondes = 0;
            paires = 0;
            blocage = false;

            lblEssais.Text = "Essais : 0";
            lblTemps.Text = "Temps : 00:00";
            lblPaires.Text = "Paires : 0";

            jeu = new JeuMemory((taille * taille) / 2);
            Grid();

            timerChrono = new Timer();
            timerChrono.Interval = 1000;
            timerChrono.Tick += (s, e) => {
                secondes++;
                lblTemps.Text = $"Temps : {secondes / 60:00}:{secondes % 60:00}";
            };
            timerChrono.Start();
        }

        private void Grid()
        {
            grille.Controls.Clear();
            grille.RowStyles.Clear();
            grille.ColumnStyles.Clear();

            grille.RowCount = taille;
            grille.ColumnCount = taille;

            for (int i = 0; i < taille; i++)
            {
                grille.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / taille));
                grille.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / taille));
            }

            for (int i = 0; i < jeu.Cartes.Count; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Dock = DockStyle.Fill;
                pb.Margin = new Padding(6);
                pb.BackColor = Color.FromArgb(30, 30, 50);
                pb.Tag = jeu.Cartes[i];
                pb.Cursor = Cursors.Hand;

                pb.Paint += Draw;
                pb.Click += Click;

                pb.MouseEnter += (s, e) => {
                    if (((Carte)pb.Tag).Etat == EtatCarte.Cachee)
                        pb.BackColor = Color.FromArgb(60, 60, 100);
                };

                pb.MouseLeave += (s, e) => {
                    if (((Carte)pb.Tag).Etat == EtatCarte.Cachee)
                        pb.BackColor = Color.FromArgb(30, 30, 50);
                };

                grille.Controls.Add(pb, i % taille, i / taille);
            }
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            var pb = sender as PictureBox;
            var c = pb.Tag as Carte;

            string txt = "?";

            if (c.Etat == EtatCarte.Revelee)
            {
                txt = c.Symbole;
                pb.BackColor = Color.FromArgb(0, 120, 255);
            }
            else if (c.Etat == EtatCarte.Trouvee)
            {
                txt = c.Symbole;
                pb.BackColor = Color.FromArgb(0, 200, 120);
            }
            else pb.BackColor = Color.FromArgb(30, 30, 50);

            TextRenderer.DrawText(e.Graphics, txt,
                new Font("Segoe UI Emoji", taille == 4 ? 36 : 24),
                pb.ClientRectangle,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void Click(object sender, EventArgs e)
        {
            if (blocage) return;

            var pb = sender as PictureBox;
            var c = pb.Tag as Carte;

            if (c.Etat != EtatCarte.Cachee) return;

            c.Etat = EtatCarte.Revelee;
            pb.Invalidate();

            if (c1 == null)
            {
                c1 = c; pb1 = pb;
                return;
            }

            c2 = c; pb2 = pb;

            essais++;
            lblEssais.Text = "Essais : " + essais;

            if (c1.IdPaire == c2.IdPaire)
            {
                c1.Etat = c2.Etat = EtatCarte.Trouvee;
                paires++;
                lblPaires.Text = "Paires : " + paires;

                c1 = null; c2 = null;

                if (jeu.PartieTerminee())
                {
                    timerChrono.Stop();
                    MessageBox.Show("🔥 Victoire !\n" + lblTemps.Text, "Bravo");
                }
            }
            else
            {
                blocage = true;
                timerRetourner = new Timer();
                timerRetourner.Interval = 700;
                timerRetourner.Tick += (s, e2) => {
                    timerRetourner.Stop();
                    c1.Etat = c2.Etat = EtatCarte.Cachee;
                    pb1.Invalidate();
                    pb2.Invalidate();
                    c1 = null; c2 = null;
                    blocage = false;
                };
                timerRetourner.Start();
            }
        }
    }
}