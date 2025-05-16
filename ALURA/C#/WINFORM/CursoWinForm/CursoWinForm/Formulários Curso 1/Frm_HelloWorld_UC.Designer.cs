namespace CursoWinForm
{
    partial class Frm_HelloWorld_UC
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXT_Conteudo_Label = new System.Windows.Forms.TextBox();
            this.Btn_Mudar_Label = new System.Windows.Forms.Button();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TXT_Conteudo_Label
            // 
            this.TXT_Conteudo_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_Conteudo_Label.Location = new System.Drawing.Point(17, 113);
            this.TXT_Conteudo_Label.Name = "TXT_Conteudo_Label";
            this.TXT_Conteudo_Label.Size = new System.Drawing.Size(494, 20);
            this.TXT_Conteudo_Label.TabIndex = 6;
            // 
            // Btn_Mudar_Label
            // 
            this.Btn_Mudar_Label.Location = new System.Drawing.Point(17, 63);
            this.Btn_Mudar_Label.Name = "Btn_Mudar_Label";
            this.Btn_Mudar_Label.Size = new System.Drawing.Size(157, 28);
            this.Btn_Mudar_Label.TabIndex = 5;
            this.Btn_Mudar_Label.Text = "Mudar Label";
            this.Btn_Mudar_Label.UseVisualStyleBackColor = true;
            this.Btn_Mudar_Label.Click += new System.EventHandler(this.Btn_Mudar_Label_Click);
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.Location = new System.Drawing.Point(14, 24);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(160, 13);
            this.lbl_Titulo.TabIndex = 4;
            this.lbl_Titulo.Text = "Visual Studio .NET Version";
            // 
            // Frm_HelloWorld_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TXT_Conteudo_Label);
            this.Controls.Add(this.Btn_Mudar_Label);
            this.Controls.Add(this.lbl_Titulo);
            this.Name = "Frm_HelloWorld_UC";
            this.Size = new System.Drawing.Size(537, 330);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXT_Conteudo_Label;
        private System.Windows.Forms.Button Btn_Mudar_Label;
        private System.Windows.Forms.Label lbl_Titulo;
    }
}
