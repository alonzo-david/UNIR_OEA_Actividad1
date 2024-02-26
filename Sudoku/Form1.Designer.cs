namespace Sudoku
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnNuevaPartida = new Button();
            btnVerificar = new Button();
            btnLimpiar = new Button();
            rbtnPrincipiante = new RadioButton();
            rbtnIntermedio = new RadioButton();
            rbtnExperto = new RadioButton();
            label1 = new Label();
            btnSolucionar = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(371, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(436, 407);
            panel1.TabIndex = 0;
            // 
            // btnNuevaPartida
            // 
            btnNuevaPartida.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNuevaPartida.Location = new Point(167, 108);
            btnNuevaPartida.Name = "btnNuevaPartida";
            btnNuevaPartida.Size = new Size(174, 47);
            btnNuevaPartida.TabIndex = 1;
            btnNuevaPartida.Text = "Nueva Partida";
            btnNuevaPartida.UseVisualStyleBackColor = true;
            btnNuevaPartida.Click += btnNuevaPartida_Click;
            // 
            // btnVerificar
            // 
            btnVerificar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerificar.Location = new Point(25, 216);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(136, 49);
            btnVerificar.TabIndex = 2;
            btnVerificar.Text = "Verificar";
            btnVerificar.UseVisualStyleBackColor = true;
            btnVerificar.Click += btnVerificar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLimpiar.Location = new Point(167, 216);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(145, 49);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // rbtnPrincipiante
            // 
            rbtnPrincipiante.AutoSize = true;
            rbtnPrincipiante.Checked = true;
            rbtnPrincipiante.Location = new Point(37, 61);
            rbtnPrincipiante.Name = "rbtnPrincipiante";
            rbtnPrincipiante.Size = new Size(108, 24);
            rbtnPrincipiante.TabIndex = 3;
            rbtnPrincipiante.TabStop = true;
            rbtnPrincipiante.Text = "Principiante";
            rbtnPrincipiante.UseVisualStyleBackColor = true;
            // 
            // rbtnIntermedio
            // 
            rbtnIntermedio.AutoSize = true;
            rbtnIntermedio.Location = new Point(37, 91);
            rbtnIntermedio.Name = "rbtnIntermedio";
            rbtnIntermedio.Size = new Size(103, 24);
            rbtnIntermedio.TabIndex = 3;
            rbtnIntermedio.Text = "Intermedio";
            rbtnIntermedio.UseVisualStyleBackColor = true;
            // 
            // rbtnExperto
            // 
            rbtnExperto.AutoSize = true;
            rbtnExperto.Location = new Point(37, 121);
            rbtnExperto.Name = "rbtnExperto";
            rbtnExperto.Size = new Size(81, 24);
            rbtnExperto.TabIndex = 3;
            rbtnExperto.Text = "Experto";
            rbtnExperto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 22);
            label1.Name = "label1";
            label1.Size = new Size(77, 29);
            label1.TabIndex = 4;
            label1.Text = "Nivel:";
            // 
            // btnSolucionar
            // 
            btnSolucionar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSolucionar.Location = new Point(25, 287);
            btnSolucionar.Name = "btnSolucionar";
            btnSolucionar.Size = new Size(287, 66);
            btnSolucionar.TabIndex = 5;
            btnSolucionar.Text = "Solucionar";
            btnSolucionar.UseVisualStyleBackColor = true;
            btnSolucionar.Click += btnSolucionar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 446);
            Controls.Add(btnSolucionar);
            Controls.Add(label1);
            Controls.Add(rbtnExperto);
            Controls.Add(rbtnIntermedio);
            Controls.Add(rbtnPrincipiante);
            Controls.Add(btnLimpiar);
            Controls.Add(btnVerificar);
            Controls.Add(btnNuevaPartida);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Sudoku";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNuevaPartida;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.RadioButton rbtnPrincipiante;
        private System.Windows.Forms.RadioButton rbtnIntermedio;
        private System.Windows.Forms.RadioButton rbtnExperto;
        private System.Windows.Forms.Label label1;
        private Button btnSolucionar;
    }
}
