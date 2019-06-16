using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoloKrzyzyk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Image kolko = Image.FromFile("o.jpg");
            Image krzyzyk = Image.FromFile("x.jpg");

            this.kolkoKrzyzyk1.Inicjalizuj(kolko, krzyzyk);

        }




        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nowaGraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jednoOsobowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wieloOsobowaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turboKółkoKrzyżykToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kolkoKrzyzyk1 = new KoloKrzyzyk.KolkoKrzyzyk();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.nowaGraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // nowaGraToolStripMenuItem
            // 
            this.nowaGraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jednoOsobowaToolStripMenuItem,
            this.wieloOsobowaToolStripMenuItem,
            this.turboKółkoKrzyżykToolStripMenuItem});
            this.nowaGraToolStripMenuItem.Name = "nowaGraToolStripMenuItem";
            this.nowaGraToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.nowaGraToolStripMenuItem.Text = "Nowa gra";
            // 
            // jednoOsobowaToolStripMenuItem
            // 
            this.jednoOsobowaToolStripMenuItem.Name = "jednoOsobowaToolStripMenuItem";
            this.jednoOsobowaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.jednoOsobowaToolStripMenuItem.Text = "Jedno osobowa";
            this.jednoOsobowaToolStripMenuItem.Click += new System.EventHandler(this.jednoOsobowaToolStripMenuItem_Click);
            // 
            // wieloOsobowaToolStripMenuItem
            // 
            this.wieloOsobowaToolStripMenuItem.Name = "wieloOsobowaToolStripMenuItem";
            this.wieloOsobowaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wieloOsobowaToolStripMenuItem.Text = "Wielo osobowa";
            this.wieloOsobowaToolStripMenuItem.Click += new System.EventHandler(this.wieloOsobowaToolStripMenuItem_Click);
            // 
            // turboKółkoKrzyżykToolStripMenuItem
            // 
            this.turboKółkoKrzyżykToolStripMenuItem.Name = "turboKółkoKrzyżykToolStripMenuItem";
            this.turboKółkoKrzyżykToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.turboKółkoKrzyżykToolStripMenuItem.Text = "Turbo kółko krzyżyk";
            this.turboKółkoKrzyżykToolStripMenuItem.Click += new System.EventHandler(this.turboKółkoKrzyżykToolStripMenuItem_Click);
            // 
            // kolkoKrzyzyk1
            // 
            this.kolkoKrzyzyk1.Location = new System.Drawing.Point(0, 27);
            this.kolkoKrzyzyk1.Name = "kolkoKrzyzyk1";
            this.kolkoKrzyzyk1.Size = new System.Drawing.Size(584, 561);
            this.kolkoKrzyzyk1.TabIndex = 1;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.kolkoKrzyzyk1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void jednoOsobowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           kolkoKrzyzyk1.Start(TypGry.jednoOsobowa);
        }

        private void wieloOsobowaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           kolkoKrzyzyk1.Start(TypGry.wieloosobowa);
        }

        private void turboKółkoKrzyżykToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kolkoKrzyzyk1.Start(TypGry.superGra);
        }
    }
}
