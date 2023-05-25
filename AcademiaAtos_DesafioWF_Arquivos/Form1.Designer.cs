namespace AcademiaAtos_DesafioWF_Arquivos
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
            btnCarregar = new Button();
            labelTotalPessoas = new Label();
            labelTotalAlunos = new Label();
            textBoxArquivo = new TextBox();
            textBoxOrganizado = new TextBox();
            button1 = new Button();
            btnGravar = new Button();
            SuspendLayout();
            // 
            // btnCarregar
            // 
            btnCarregar.Location = new Point(12, 389);
            btnCarregar.Name = "btnCarregar";
            btnCarregar.Size = new Size(112, 23);
            btnCarregar.TabIndex = 0;
            btnCarregar.Text = "Carregar Arquivo";
            btnCarregar.UseVisualStyleBackColor = true;
            btnCarregar.Click += buttonCarregar_Click;
            // 
            // labelTotalPessoas
            // 
            labelTotalPessoas.AutoSize = true;
            labelTotalPessoas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTotalPessoas.ForeColor = Color.White;
            labelTotalPessoas.Location = new Point(475, 386);
            labelTotalPessoas.Name = "labelTotalPessoas";
            labelTotalPessoas.Size = new Size(100, 21);
            labelTotalPessoas.TabIndex = 2;
            labelTotalPessoas.Text = "Total Pessoas";
            // 
            // labelTotalAlunos
            // 
            labelTotalAlunos.AutoSize = true;
            labelTotalAlunos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTotalAlunos.ForeColor = Color.White;
            labelTotalAlunos.Location = new Point(710, 386);
            labelTotalAlunos.Name = "labelTotalAlunos";
            labelTotalAlunos.Size = new Size(94, 21);
            labelTotalAlunos.TabIndex = 3;
            labelTotalAlunos.Text = "Total Alunos";
            // 
            // textBoxArquivo
            // 
            textBoxArquivo.Location = new Point(12, 16);
            textBoxArquivo.Multiline = true;
            textBoxArquivo.Name = "textBoxArquivo";
            textBoxArquivo.ScrollBars = ScrollBars.Both;
            textBoxArquivo.Size = new Size(258, 368);
            textBoxArquivo.TabIndex = 5;
            // 
            // textBoxOrganizado
            // 
            textBoxOrganizado.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxOrganizado.Location = new Point(291, 16);
            textBoxOrganizado.Multiline = true;
            textBoxOrganizado.Name = "textBoxOrganizado";
            textBoxOrganizado.ScrollBars = ScrollBars.Both;
            textBoxOrganizado.Size = new Size(621, 367);
            textBoxOrganizado.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(130, 389);
            button1.Name = "button1";
            button1.Size = new Size(115, 24);
            button1.TabIndex = 7;
            button1.Text = "Organizar Arquivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonOrganizar_Click;
            // 
            // btnGravar
            // 
            btnGravar.Location = new Point(251, 389);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(115, 23);
            btnGravar.TabIndex = 8;
            btnGravar.Text = "Gravar Arquivo ";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += buttonGravar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(924, 425);
            Controls.Add(btnGravar);
            Controls.Add(button1);
            Controls.Add(textBoxOrganizado);
            Controls.Add(textBoxArquivo);
            Controls.Add(labelTotalAlunos);
            Controls.Add(labelTotalPessoas);
            Controls.Add(btnCarregar);
            Name = "Form1";
            Text = "Organizador de Arquivo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCarregar;
        private Label labelTotalPessoas;
        private Label labelTotalAlunos;
        private TextBox textBoxArquivo;
        private TextBox textBoxOrganizado;
        private Button button1;
        private Button btnGravar;
    }
}