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
            this.funcionLabel = new System.Windows.Forms.Label();
            this.restriccionesLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // funcionLabel
            // 
            this.funcionLabel.AutoSize = true;
            this.funcionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionLabel.Location = new System.Drawing.Point(12, 21);
            this.funcionLabel.Name = "funcionLabel";
            this.funcionLabel.Size = new System.Drawing.Size(46, 20);
            this.funcionLabel.TabIndex = 0;
            this.funcionLabel.Text = "Pᴱ:    ";
            // 
            // restriccionesLbl
            // 
            this.restriccionesLbl.AutoSize = true;
            this.restriccionesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restriccionesLbl.Location = new System.Drawing.Point(12, 57);
            this.restriccionesLbl.Name = "restriccionesLbl";
            this.restriccionesLbl.Size = new System.Drawing.Size(30, 20);
            this.restriccionesLbl.TabIndex = 1;
            this.restriccionesLbl.Text = "s.a";
            // 
            // Resultados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 536);
            this.Controls.Add(this.restriccionesLbl);
            this.Controls.Add(this.funcionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Resultados";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultados";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Resultados_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label funcionLabel;
        private System.Windows.Forms.Label restriccionesLbl;
    }
}