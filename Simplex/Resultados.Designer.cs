namespace Simplex
{
    partial class Resultados
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
            this.label = new System.Windows.Forms.Label();
            this.funcionLabel = new System.Windows.Forms.Label();
            this.labelRestricciones = new System.Windows.Forms.Label();
            this.continuarBtn = new System.Windows.Forms.Button();
            this.salirBtn = new System.Windows.Forms.Button();
            this.labelMovimientos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(51, 40);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(30, 20);
            this.label.TabIndex = 1;
            this.label.Text = "s.a";
            // 
            // funcionLabel
            // 
            this.funcionLabel.AutoSize = true;
            this.funcionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionLabel.Location = new System.Drawing.Point(12, 15);
            this.funcionLabel.Name = "funcionLabel";
            this.funcionLabel.Size = new System.Drawing.Size(46, 20);
            this.funcionLabel.TabIndex = 0;
            this.funcionLabel.Text = "Pᴱ:    ";
            // 
            // labelRestricciones
            // 
            this.labelRestricciones.AutoSize = true;
            this.labelRestricciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRestricciones.Location = new System.Drawing.Point(108, 40);
            this.labelRestricciones.Name = "labelRestricciones";
            this.labelRestricciones.Size = new System.Drawing.Size(0, 20);
            this.labelRestricciones.TabIndex = 2;
            // 
            // continuarBtn
            // 
            this.continuarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continuarBtn.Location = new System.Drawing.Point(202, 256);
            this.continuarBtn.Name = "continuarBtn";
            this.continuarBtn.Size = new System.Drawing.Size(92, 22);
            this.continuarBtn.TabIndex = 7;
            this.continuarBtn.Text = "Continuar";
            this.continuarBtn.UseVisualStyleBackColor = true;
            this.continuarBtn.Click += new System.EventHandler(this.continuarBtn_Click);
            // 
            // salirBtn
            // 
            this.salirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.salirBtn.Location = new System.Drawing.Point(300, 256);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(92, 22);
            this.salirBtn.TabIndex = 8;
            this.salirBtn.Text = "Cancelar";
            this.salirBtn.UseVisualStyleBackColor = true;
            this.salirBtn.Click += new System.EventHandler(this.salirBtn_Click);
            // 
            // labelMovimientos
            // 
            this.labelMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMovimientos.AutoSize = true;
            this.labelMovimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovimientos.Location = new System.Drawing.Point(12, 255);
            this.labelMovimientos.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.labelMovimientos.MaximumSize = new System.Drawing.Size(280, 0);
            this.labelMovimientos.Name = "labelMovimientos";
            this.labelMovimientos.Size = new System.Drawing.Size(107, 20);
            this.labelMovimientos.TabIndex = 9;
            this.labelMovimientos.Text = "Entra x, sale y";
            this.labelMovimientos.Visible = false;
            // 
            // Resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(404, 290);
            this.Controls.Add(this.labelMovimientos);
            this.Controls.Add(this.salirBtn);
            this.Controls.Add(this.continuarBtn);
            this.Controls.Add(this.labelRestricciones);
            this.Controls.Add(this.label);
            this.Controls.Add(this.funcionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 39);
            this.Name = "Resultados";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultados";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Resultados_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label funcionLabel;
        private System.Windows.Forms.Label labelRestricciones;
        private System.Windows.Forms.Button continuarBtn;
        private System.Windows.Forms.Button salirBtn;
        private System.Windows.Forms.Label labelMovimientos;
    }
}