namespace mercado
{
    partial class FormHort
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtPrecoKg;
        private System.Windows.Forms.TextBox txtEstoqueKg;
        private System.Windows.Forms.TextBox txtPesoTeste;
        private System.Windows.Forms.Label lblCodigoGerado;
        private System.Windows.Forms.Button btnGerarEtiqueta;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblCodigoLabel;
        private System.Windows.Forms.Label lblNomeLabel;
        private System.Windows.Forms.Label lblPrecoKgLabel;
        private System.Windows.Forms.Label lblEstoqueKgLabel;
        private System.Windows.Forms.Label lblPesoTesteLabel;
        private System.Windows.Forms.ToolTip toolTip1;

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
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtPrecoKg = new System.Windows.Forms.TextBox();
            this.txtEstoqueKg = new System.Windows.Forms.TextBox();
            this.txtPesoTeste = new System.Windows.Forms.TextBox();
            this.lblCodigoGerado = new System.Windows.Forms.Label();
            this.btnGerarEtiqueta = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblCodigoLabel = new System.Windows.Forms.Label();
            this.lblNomeLabel = new System.Windows.Forms.Label();
            this.lblPrecoKgLabel = new System.Windows.Forms.Label();
            this.lblEstoqueKgLabel = new System.Windows.Forms.Label();
            this.lblPesoTesteLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(20, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(120, 20);
            this.txtCodigo.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtCodigo, "Código curto do produto (inteiro). Ex: 1 - será formatado em 4 dígitos para etiqueta.");

            // lblCodigoLabel
            // 
            this.lblCodigoLabel.Location = new System.Drawing.Point(20, 2);
            this.lblCodigoLabel.Name = "lblCodigoLabel";
            this.lblCodigoLabel.Size = new System.Drawing.Size(120, 16);
            this.lblCodigoLabel.TabIndex = 10;
            this.lblCodigoLabel.Text = "Código (curto):";

            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(20, 50);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(360, 20);
            this.txtNome.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtNome, "Descrição do produto. Ex: BANANA PRATA");

            // lblNomeLabel
            // 
            this.lblNomeLabel.Location = new System.Drawing.Point(20, 32);
            this.lblNomeLabel.Name = "lblNomeLabel";
            this.lblNomeLabel.Size = new System.Drawing.Size(120, 16);
            this.lblNomeLabel.TabIndex = 11;
            this.lblNomeLabel.Text = "Descrição:";

            // 
            // txtPrecoKg
            // 
            this.txtPrecoKg.Location = new System.Drawing.Point(20, 80);
            this.txtPrecoKg.Name = "txtPrecoKg";
            this.txtPrecoKg.Size = new System.Drawing.Size(120, 20);
            this.txtPrecoKg.TabIndex = 2;
            this.toolTip1.SetToolTip(this.txtPrecoKg, "Preço por quilo (decimal). Ex: 5.00");

            // lblPrecoKgLabel
            // 
            this.lblPrecoKgLabel.Location = new System.Drawing.Point(20, 62);
            this.lblPrecoKgLabel.Name = "lblPrecoKgLabel";
            this.lblPrecoKgLabel.Size = new System.Drawing.Size(120, 16);
            this.lblPrecoKgLabel.TabIndex = 12;
            this.lblPrecoKgLabel.Text = "Preço / Kg:";

            // 
            // txtEstoqueKg
            // 
            this.txtEstoqueKg.Location = new System.Drawing.Point(160, 80);
            this.txtEstoqueKg.Name = "txtEstoqueKg";
            this.txtEstoqueKg.Size = new System.Drawing.Size(120, 20);
            this.txtEstoqueKg.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtEstoqueKg, "Quantidade em estoque (Kg). Ex: 12.500");

            // lblEstoqueKgLabel
            // 
            this.lblEstoqueKgLabel.Location = new System.Drawing.Point(160, 62);
            this.lblEstoqueKgLabel.Name = "lblEstoqueKgLabel";
            this.lblEstoqueKgLabel.Size = new System.Drawing.Size(120, 16);
            this.lblEstoqueKgLabel.TabIndex = 13;
            this.lblEstoqueKgLabel.Text = "Estoque (Kg):";

            // 
            // txtPesoTeste
            // 
            this.txtPesoTeste.Location = new System.Drawing.Point(20, 110);
            this.txtPesoTeste.Name = "txtPesoTeste";
            this.txtPesoTeste.Size = new System.Drawing.Size(120, 20);
            this.txtPesoTeste.TabIndex = 4;
            this.txtPesoTeste.Text = "5.190";
            this.toolTip1.SetToolTip(this.txtPesoTeste, "Peso de teste em Kg para gerar etiqueta. Ex: 5.190");

            // lblPesoTesteLabel
            // 
            this.lblPesoTesteLabel.Location = new System.Drawing.Point(20, 92);
            this.lblPesoTesteLabel.Name = "lblPesoTesteLabel";
            this.lblPesoTesteLabel.Size = new System.Drawing.Size(120, 16);
            this.lblPesoTesteLabel.TabIndex = 14;
            this.lblPesoTesteLabel.Text = "Peso (Kg):";
            // 
            // lblCodigoGerado
            // 
            this.lblCodigoGerado.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCodigoGerado.Location = new System.Drawing.Point(160, 110);
            this.lblCodigoGerado.Name = "lblCodigoGerado";
            this.lblCodigoGerado.Size = new System.Drawing.Size(220, 30);
            this.lblCodigoGerado.TabIndex = 5;
            this.lblCodigoGerado.Text = "000000000";
            this.lblCodigoGerado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGerarEtiqueta
            // 
            this.btnGerarEtiqueta.Location = new System.Drawing.Point(20, 150);
            this.btnGerarEtiqueta.Name = "btnGerarEtiqueta";
            this.btnGerarEtiqueta.Size = new System.Drawing.Size(120, 30);
            this.btnGerarEtiqueta.TabIndex = 6;
            this.btnGerarEtiqueta.Text = "Gerar Etiqueta";
            this.btnGerarEtiqueta.UseVisualStyleBackColor = true;
            this.btnGerarEtiqueta.Click += new System.EventHandler(this.btnGerarEtiqueta_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(160, 150);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 30);
            this.btnSalvar.TabIndex = 7;
            this.btnSalvar.Text = "Guardar Produto";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(300, 150);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(80, 30);
            this.btnVoltar.TabIndex = 8;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // FormHort
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigoLabel);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNomeLabel);
            this.Controls.Add(this.txtPrecoKg);
            this.Controls.Add(this.lblPrecoKgLabel);
            this.Controls.Add(this.txtEstoqueKg);
            this.Controls.Add(this.lblEstoqueKgLabel);
            this.Controls.Add(this.txtPesoTeste);
            this.Controls.Add(this.lblPesoTesteLabel);
            this.Controls.Add(this.lblCodigoGerado);
            this.Controls.Add(this.btnGerarEtiqueta);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Name = "FormHort";
            this.Text = "Hortifrúti - Gestão";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
