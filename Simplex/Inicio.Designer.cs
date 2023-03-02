namespace Simplex
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numVariables = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numRestricciones = new System.Windows.Forms.ComboBox();
            this.continuarBtn = new System.Windows.Forms.Button();
            this.salirBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.MaximumSize = new System.Drawing.Size(295, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bienvenido al solucionador del método Simplex";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingrese el numero de variables:";
            // 
            // numVariables
            // 
            this.numVariables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numVariables.DisplayMember = "1";
            this.numVariables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numVariables.FormattingEnabled = true;
            this.numVariables.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.numVariables.Location = new System.Drawing.Point(217, 65);
            this.numVariables.MaxDropDownItems = 5;
            this.numVariables.Name = "numVariables";
            this.numVariables.Size = new System.Drawing.Size(51, 21);
            this.numVariables.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ingrese el numero de restricciones:";
            // 
            // numRestricciones
            // 
            this.numRestricciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numRestricciones.DisplayMember = "1";
            this.numRestricciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numRestricciones.FormattingEnabled = true;
            this.numRestricciones.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.numRestricciones.Location = new System.Drawing.Point(217, 92);
            this.numRestricciones.MaxDropDownItems = 5;
            this.numRestricciones.Name = "numRestricciones";
            this.numRestricciones.Size = new System.Drawing.Size(51, 21);
            this.numRestricciones.TabIndex = 4;
            // 
            // continuarBtn
            // 
            this.continuarBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.continuarBtn.Location = new System.Drawing.Point(78, 132);
            this.continuarBtn.Name = "continuarBtn";
            this.continuarBtn.Size = new System.Drawing.Size(92, 22);
            this.continuarBtn.TabIndex = 5;
            this.continuarBtn.Text = "Continuar";
            this.continuarBtn.UseVisualStyleBackColor = true;
            this.continuarBtn.Click += new System.EventHandler(this.continuarBtn_Click);
            // 
            // salirBtn
            // 
            this.salirBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.salirBtn.Location = new System.Drawing.Point(176, 132);
            this.salirBtn.Name = "salirBtn";
            this.salirBtn.Size = new System.Drawing.Size(92, 22);
            this.salirBtn.TabIndex = 6;
            this.salirBtn.Text = "Salir";
            this.salirBtn.UseVisualStyleBackColor = true;
            this.salirBtn.Click += new System.EventHandler(this.salirBtn_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 162);
            this.Controls.Add(this.salirBtn);
            this.Controls.Add(this.continuarBtn);
            this.Controls.Add(this.numRestricciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numVariables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(296, 201);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solucionador Simplex";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Inicio_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox numVariables;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox numRestricciones;
        private System.Windows.Forms.Button continuarBtn;
        private System.Windows.Forms.Button salirBtn;
    }
}

