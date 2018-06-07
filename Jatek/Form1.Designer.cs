namespace Jatek
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonTamadas = new System.Windows.Forms.Button();
            this.buttonVedekezes = new System.Windows.Forms.Button();
            this.buttonUjraeledes = new System.Windows.Forms.Button();
            this.labelMeghaltal = new System.Windows.Forms.Label();
            this.buttonJutKard = new System.Windows.Forms.Button();
            this.buttonJutPajzs = new System.Windows.Forms.Button();
            this.buttonJutPancel = new System.Windows.Forms.Button();
            this.labelEllenfel = new System.Windows.Forms.Label();
            this.labelSelf_hp = new System.Windows.Forms.Label();
            this.labelEnemy_hp = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelmeret = new System.Windows.Forms.Label();
            this.textBoxmeret = new System.Windows.Forms.TextBox();
            this.buttonGeneralas = new System.Windows.Forms.Button();
            this.labelTerkep = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTamadas
            // 
            this.buttonTamadas.Enabled = false;
            this.buttonTamadas.Location = new System.Drawing.Point(125, 126);
            this.buttonTamadas.Name = "buttonTamadas";
            this.buttonTamadas.Size = new System.Drawing.Size(76, 38);
            this.buttonTamadas.TabIndex = 0;
            this.buttonTamadas.Text = "Támadás";
            this.buttonTamadas.UseVisualStyleBackColor = true;
            this.buttonTamadas.Visible = false;
            this.buttonTamadas.Click += new System.EventHandler(this.ButtonTamadas_Click);
            // 
            // buttonVedekezes
            // 
            this.buttonVedekezes.Enabled = false;
            this.buttonVedekezes.Location = new System.Drawing.Point(356, 126);
            this.buttonVedekezes.Name = "buttonVedekezes";
            this.buttonVedekezes.Size = new System.Drawing.Size(76, 38);
            this.buttonVedekezes.TabIndex = 1;
            this.buttonVedekezes.TabStop = false;
            this.buttonVedekezes.Text = "Védekezés";
            this.buttonVedekezes.UseVisualStyleBackColor = true;
            this.buttonVedekezes.Visible = false;
            this.buttonVedekezes.Click += new System.EventHandler(this.ButtonVedekezes_Click);
            // 
            // buttonUjraeledes
            // 
            this.buttonUjraeledes.Enabled = false;
            this.buttonUjraeledes.Location = new System.Drawing.Point(246, 134);
            this.buttonUjraeledes.Name = "buttonUjraeledes";
            this.buttonUjraeledes.Size = new System.Drawing.Size(75, 23);
            this.buttonUjraeledes.TabIndex = 2;
            this.buttonUjraeledes.Text = "Újraéledés";
            this.buttonUjraeledes.UseVisualStyleBackColor = true;
            this.buttonUjraeledes.Visible = false;
            this.buttonUjraeledes.Click += new System.EventHandler(this.ButtonUjraeledes_Click);
            // 
            // labelMeghaltal
            // 
            this.labelMeghaltal.AutoSize = true;
            this.labelMeghaltal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMeghaltal.Location = new System.Drawing.Point(238, 63);
            this.labelMeghaltal.Name = "labelMeghaltal";
            this.labelMeghaltal.Size = new System.Drawing.Size(91, 24);
            this.labelMeghaltal.TabIndex = 3;
            this.labelMeghaltal.Text = "Meghaltál";
            this.labelMeghaltal.Visible = false;
            // 
            // buttonJutKard
            // 
            this.buttonJutKard.Enabled = false;
            this.buttonJutKard.Location = new System.Drawing.Point(126, 134);
            this.buttonJutKard.Name = "buttonJutKard";
            this.buttonJutKard.Size = new System.Drawing.Size(75, 23);
            this.buttonJutKard.TabIndex = 4;
            this.buttonJutKard.Text = "Kard";
            this.buttonJutKard.UseVisualStyleBackColor = true;
            this.buttonJutKard.Visible = false;
            this.buttonJutKard.Click += new System.EventHandler(this.ButtonJutKard_Click);
            // 
            // buttonJutPajzs
            // 
            this.buttonJutPajzs.Enabled = false;
            this.buttonJutPajzs.Location = new System.Drawing.Point(246, 134);
            this.buttonJutPajzs.Name = "buttonJutPajzs";
            this.buttonJutPajzs.Size = new System.Drawing.Size(75, 23);
            this.buttonJutPajzs.TabIndex = 5;
            this.buttonJutPajzs.Text = "Pajzs";
            this.buttonJutPajzs.UseVisualStyleBackColor = true;
            this.buttonJutPajzs.Visible = false;
            this.buttonJutPajzs.Click += new System.EventHandler(this.ButtonJutPajzs_Click);
            // 
            // buttonJutPancel
            // 
            this.buttonJutPancel.Enabled = false;
            this.buttonJutPancel.Location = new System.Drawing.Point(356, 134);
            this.buttonJutPancel.Name = "buttonJutPancel";
            this.buttonJutPancel.Size = new System.Drawing.Size(75, 23);
            this.buttonJutPancel.TabIndex = 6;
            this.buttonJutPancel.Text = "Páncél";
            this.buttonJutPancel.UseVisualStyleBackColor = true;
            this.buttonJutPancel.Visible = false;
            this.buttonJutPancel.Click += new System.EventHandler(this.ButtonJutPancel_Click);
            // 
            // labelEllenfel
            // 
            this.labelEllenfel.AutoSize = true;
            this.labelEllenfel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEllenfel.Location = new System.Drawing.Point(197, 63);
            this.labelEllenfel.Name = "labelEllenfel";
            this.labelEllenfel.Size = new System.Drawing.Size(124, 24);
            this.labelEllenfel.TabIndex = 7;
            this.labelEllenfel.Text = "Az ellenfeled:";
            this.labelEllenfel.Visible = false;
            // 
            // labelSelf_hp
            // 
            this.labelSelf_hp.AutoSize = true;
            this.labelSelf_hp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSelf_hp.Location = new System.Drawing.Point(122, 66);
            this.labelSelf_hp.Name = "labelSelf_hp";
            this.labelSelf_hp.Size = new System.Drawing.Size(40, 20);
            this.labelSelf_hp.TabIndex = 8;
            this.labelSelf_hp.Text = "0 hp";
            this.labelSelf_hp.Visible = false;
            // 
            // labelEnemy_hp
            // 
            this.labelEnemy_hp.AutoSize = true;
            this.labelEnemy_hp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEnemy_hp.Location = new System.Drawing.Point(391, 66);
            this.labelEnemy_hp.Name = "labelEnemy_hp";
            this.labelEnemy_hp.Size = new System.Drawing.Size(40, 20);
            this.labelEnemy_hp.TabIndex = 9;
            this.labelEnemy_hp.Text = "0 hp";
            this.labelEnemy_hp.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "  __._._";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "/  *      \\";
            // 
            // labelmeret
            // 
            this.labelmeret.AutoSize = true;
            this.labelmeret.Location = new System.Drawing.Point(542, 91);
            this.labelmeret.Name = "labelmeret";
            this.labelmeret.Size = new System.Drawing.Size(98, 13);
            this.labelmeret.TabIndex = 12;
            this.labelmeret.Text = "A kazamata mérete";
            // 
            // textBoxmeret
            // 
            this.textBoxmeret.Location = new System.Drawing.Point(540, 126);
            this.textBoxmeret.Name = "textBoxmeret";
            this.textBoxmeret.Size = new System.Drawing.Size(100, 20);
            this.textBoxmeret.TabIndex = 13;
            this.textBoxmeret.Text = "4";
            // 
            // buttonGeneralas
            // 
            this.buttonGeneralas.Location = new System.Drawing.Point(545, 189);
            this.buttonGeneralas.Name = "buttonGeneralas";
            this.buttonGeneralas.Size = new System.Drawing.Size(127, 23);
            this.buttonGeneralas.TabIndex = 14;
            this.buttonGeneralas.Text = "Generálja a kazamatát!";
            this.buttonGeneralas.UseVisualStyleBackColor = true;
            this.buttonGeneralas.Click += new System.EventHandler(this.ButtonGeneralas_Click);
            // 
            // labelTerkep
            // 
            this.labelTerkep.AutoSize = true;
            this.labelTerkep.Location = new System.Drawing.Point(446, 306);
            this.labelTerkep.Name = "labelTerkep";
            this.labelTerkep.Size = new System.Drawing.Size(35, 13);
            this.labelTerkep.TabIndex = 15;
            this.labelTerkep.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 690);
            this.Controls.Add(this.labelTerkep);
            this.Controls.Add(this.buttonGeneralas);
            this.Controls.Add(this.textBoxmeret);
            this.Controls.Add(this.labelmeret);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEnemy_hp);
            this.Controls.Add(this.labelSelf_hp);
            this.Controls.Add(this.labelEllenfel);
            this.Controls.Add(this.buttonJutPancel);
            this.Controls.Add(this.buttonJutPajzs);
            this.Controls.Add(this.buttonJutKard);
            this.Controls.Add(this.labelMeghaltal);
            this.Controls.Add(this.buttonUjraeledes);
            this.Controls.Add(this.buttonVedekezes);
            this.Controls.Add(this.buttonTamadas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTamadas;
        private System.Windows.Forms.Button buttonVedekezes;
        private System.Windows.Forms.Button buttonUjraeledes;
        private System.Windows.Forms.Label labelMeghaltal;
        private System.Windows.Forms.Button buttonJutKard;
        private System.Windows.Forms.Button buttonJutPajzs;
        private System.Windows.Forms.Button buttonJutPancel;
        private System.Windows.Forms.Label labelEllenfel;
        private System.Windows.Forms.Label labelSelf_hp;
        private System.Windows.Forms.Label labelEnemy_hp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelmeret;
        private System.Windows.Forms.TextBox textBoxmeret;
        private System.Windows.Forms.Button buttonGeneralas;
        private System.Windows.Forms.Label labelTerkep;
    }
}

