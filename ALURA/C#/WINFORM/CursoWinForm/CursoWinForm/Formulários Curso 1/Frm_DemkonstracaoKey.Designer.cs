namespace CursoWinForm
{
    partial class Frm_DemkonstracaoKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DemkonstracaoKey));
            this.Txt_Input = new System.Windows.Forms.TextBox();
            this.Txt_Msg = new System.Windows.Forms.TextBox();
            this.Btn_reset = new System.Windows.Forms.Button();
            this.Lbl_minus = new System.Windows.Forms.Label();
            this.Lbl_Maius = new System.Windows.Forms.Label();
            this.Lbl_Upper = new System.Windows.Forms.Label();
            this.Lbl_Lower = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Txt_Input
            // 
            this.Txt_Input.Location = new System.Drawing.Point(8, 8);
            this.Txt_Input.Name = "Txt_Input";
            this.Txt_Input.Size = new System.Drawing.Size(100, 20);
            this.Txt_Input.TabIndex = 0;
            this.Txt_Input.TextChanged += new System.EventHandler(this.Txt_Input_TextChanged);
            this.Txt_Input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_Input_KeyDown);
            // 
            // Txt_Msg
            // 
            this.Txt_Msg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Msg.Location = new System.Drawing.Point(8, 40);
            this.Txt_Msg.Multiline = true;
            this.Txt_Msg.Name = "Txt_Msg";
            this.Txt_Msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Txt_Msg.Size = new System.Drawing.Size(304, 232);
            this.Txt_Msg.TabIndex = 1;
            this.Txt_Msg.TabStop = false;
            this.Txt_Msg.TextChanged += new System.EventHandler(this.Txt_Msg_TextChanged);
            // 
            // Btn_reset
            // 
            this.Btn_reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_reset.Location = new System.Drawing.Point(328, 8);
            this.Btn_reset.Name = "Btn_reset";
            this.Btn_reset.Size = new System.Drawing.Size(75, 28);
            this.Btn_reset.TabIndex = 2;
            this.Btn_reset.Text = "Limpar";
            this.Btn_reset.UseVisualStyleBackColor = true;
            this.Btn_reset.Click += new System.EventHandler(this.button1_Click);
            // 
            // Lbl_minus
            // 
            this.Lbl_minus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_minus.AutoSize = true;
            this.Lbl_minus.Location = new System.Drawing.Point(320, 104);
            this.Lbl_minus.Name = "Lbl_minus";
            this.Lbl_minus.Size = new System.Drawing.Size(38, 13);
            this.Lbl_minus.TabIndex = 3;
            this.Lbl_minus.Text = "Minus.";
            this.Lbl_minus.Click += new System.EventHandler(this.Lbl_minus_Click);
            // 
            // Lbl_Maius
            // 
            this.Lbl_Maius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Maius.AutoSize = true;
            this.Lbl_Maius.Location = new System.Drawing.Point(320, 56);
            this.Lbl_Maius.Name = "Lbl_Maius";
            this.Lbl_Maius.Size = new System.Drawing.Size(38, 13);
            this.Lbl_Maius.TabIndex = 4;
            this.Lbl_Maius.Text = "Maius.";
            this.Lbl_Maius.Click += new System.EventHandler(this.Lbl_Maius_Click);
            // 
            // Lbl_Upper
            // 
            this.Lbl_Upper.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Upper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lbl_Upper.Location = new System.Drawing.Point(368, 56);
            this.Lbl_Upper.Name = "Lbl_Upper";
            this.Lbl_Upper.Size = new System.Drawing.Size(32, 23);
            this.Lbl_Upper.TabIndex = 5;
            this.Lbl_Upper.Click += new System.EventHandler(this.Lbl_Upper_Click);
            // 
            // Lbl_Lower
            // 
            this.Lbl_Lower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_Lower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lbl_Lower.Location = new System.Drawing.Point(368, 104);
            this.Lbl_Lower.Name = "Lbl_Lower";
            this.Lbl_Lower.Size = new System.Drawing.Size(32, 23);
            this.Lbl_Lower.TabIndex = 6;
            this.Lbl_Lower.Click += new System.EventHandler(this.Lbl_Lower_Click);
            // 
            // Frm_DemkonstracaoKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 281);
            this.Controls.Add(this.Lbl_Lower);
            this.Controls.Add(this.Lbl_Upper);
            this.Controls.Add(this.Lbl_Maius);
            this.Controls.Add(this.Lbl_minus);
            this.Controls.Add(this.Btn_reset);
            this.Controls.Add(this.Txt_Msg);
            this.Controls.Add(this.Txt_Input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_DemkonstracaoKey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Frm_DemkonstracaoKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Input;
        private System.Windows.Forms.TextBox Txt_Msg;
        private System.Windows.Forms.Button Btn_reset;
        private System.Windows.Forms.Label Lbl_minus;
        private System.Windows.Forms.Label Lbl_Maius;
        private System.Windows.Forms.Label Lbl_Upper;
        private System.Windows.Forms.Label Lbl_Lower;
    }
}