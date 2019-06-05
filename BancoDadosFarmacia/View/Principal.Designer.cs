namespace View
{
    partial class Principal
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
            this.btnProdutosComestiveis = new System.Windows.Forms.Button();
            this.btnProdutosHigienicos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProdutosComestiveis
            // 
            this.btnProdutosComestiveis.Font = new System.Drawing.Font("Yu Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdutosComestiveis.Location = new System.Drawing.Point(12, 12);
            this.btnProdutosComestiveis.Name = "btnProdutosComestiveis";
            this.btnProdutosComestiveis.Size = new System.Drawing.Size(195, 116);
            this.btnProdutosComestiveis.TabIndex = 0;
            this.btnProdutosComestiveis.Text = "Produtos Comestiveis";
            this.btnProdutosComestiveis.UseVisualStyleBackColor = true;
            this.btnProdutosComestiveis.Click += new System.EventHandler(this.btnProdutosComestiveis_Click);
            // 
            // btnProdutosHigienicos
            // 
            this.btnProdutosHigienicos.Font = new System.Drawing.Font("Yu Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdutosHigienicos.Location = new System.Drawing.Point(213, 12);
            this.btnProdutosHigienicos.Name = "btnProdutosHigienicos";
            this.btnProdutosHigienicos.Size = new System.Drawing.Size(195, 116);
            this.btnProdutosHigienicos.TabIndex = 1;
            this.btnProdutosHigienicos.Text = "Produtos Higienicos";
            this.btnProdutosHigienicos.UseVisualStyleBackColor = true;
            this.btnProdutosHigienicos.Click += new System.EventHandler(this.btnProdutosHigienicos_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProdutosHigienicos);
            this.Controls.Add(this.btnProdutosComestiveis);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProdutosComestiveis;
        private System.Windows.Forms.Button btnProdutosHigienicos;
    }
}