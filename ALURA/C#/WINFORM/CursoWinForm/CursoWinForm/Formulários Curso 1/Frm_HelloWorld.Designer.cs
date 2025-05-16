namespace CursoWinForm
{
    partial class Frm_HelloWorld
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_HelloWorld));
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.Btn_Sair = new System.Windows.Forms.Button();
            this.Btn_Mudar_Label = new System.Windows.Forms.Button();
            this.TXT_Conteudo_Label = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.Location = new System.Drawing.Point(30, 30);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(160, 13);
            this.lbl_Titulo.TabIndex = 0;
            this.lbl_Titulo.Text = "Visual Studio .NET Version";
            this.lbl_Titulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // Btn_Sair
            // 
            this.Btn_Sair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Sair.Location = new System.Drawing.Point(708, 406);
            this.Btn_Sair.Name = "Btn_Sair";
            this.Btn_Sair.Size = new System.Drawing.Size(80, 32);
            this.Btn_Sair.TabIndex = 1;
            this.Btn_Sair.Text = "Sair";
            this.Btn_Sair.UseVisualStyleBackColor = true;
            this.Btn_Sair.Click += new System.EventHandler(this.Btn_Sair_Click);
            // 
            // Btn_Mudar_Label
            // 
            this.Btn_Mudar_Label.Location = new System.Drawing.Point(33, 69);
            this.Btn_Mudar_Label.Name = "Btn_Mudar_Label";
            this.Btn_Mudar_Label.Size = new System.Drawing.Size(157, 28);
            this.Btn_Mudar_Label.TabIndex = 2;
            this.Btn_Mudar_Label.Text = "Mudar Label";
            this.Btn_Mudar_Label.UseVisualStyleBackColor = true;
            this.Btn_Mudar_Label.Click += new System.EventHandler(this.button1_Click);
            // 
            // TXT_Conteudo_Label
            // 
            this.TXT_Conteudo_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_Conteudo_Label.Location = new System.Drawing.Point(33, 119);
            this.TXT_Conteudo_Label.Name = "TXT_Conteudo_Label";
            this.TXT_Conteudo_Label.Size = new System.Drawing.Size(243, 20);
            this.TXT_Conteudo_Label.TabIndex = 3;
            // 
            // Frm_HelloWorld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TXT_Conteudo_Label);
            this.Controls.Add(this.Btn_Mudar_Label);
            this.Controls.Add(this.Btn_Sair);
            this.Controls.Add(this.lbl_Titulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_HelloWorld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HelloWorld";
            this.Load += new System.EventHandler(this.Frm_HelloWorld_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Button Btn_Sair;
        private System.Windows.Forms.Button Btn_Mudar_Label;
        private System.Windows.Forms.TextBox TXT_Conteudo_Label;
    }
}

