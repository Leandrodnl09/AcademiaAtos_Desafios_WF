namespace AcademiaAtos_DesafioWF_Estacionamento
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
            labelDataHora = new Label();
            textBoxPlaca = new TextBox();
            buttonEntrada = new Button();
            buttonSaida = new Button();
            textBoxListaVeiculosEntrada = new TextBox();
            textBoxListaVeiculosSaida = new TextBox();
            labelBemVindo = new Label();
            lblDigitarPlaca = new Label();
            textBoxModelo = new TextBox();
            lblDigitarModelo = new Label();
            label3 = new Label();
            label1 = new Label();
            textBoxTempoPermanencia = new TextBox();
            lblTempoPermanencia = new Label();
            label2 = new Label();
            textBoxValorCobrado = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // labelDataHora
            // 
            labelDataHora.AutoSize = true;
            labelDataHora.Font = new Font("Showcard Gothic", 17F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataHora.ForeColor = Color.White;
            labelDataHora.Location = new Point(14, 199);
            labelDataHora.Name = "labelDataHora";
            labelDataHora.Size = new Size(201, 36);
            labelDataHora.TabIndex = 5;
            labelDataHora.Text = "Hora e data";
            // 
            // textBoxPlaca
            // 
            textBoxPlaca.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxPlaca.Location = new Point(321, 97);
            textBoxPlaca.Name = "textBoxPlaca";
            textBoxPlaca.Size = new Size(219, 30);
            textBoxPlaca.TabIndex = 2;
            // 
            // buttonEntrada
            // 
            buttonEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEntrada.Location = new Point(321, 199);
            buttonEntrada.Name = "buttonEntrada";
            buttonEntrada.Size = new Size(94, 39);
            buttonEntrada.TabIndex = 6;
            buttonEntrada.Text = "Cadastrar";
            buttonEntrada.UseVisualStyleBackColor = true;
            buttonEntrada.Click += buttonEntrada_Click;
            // 
            // buttonSaida
            // 
            buttonSaida.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSaida.Location = new Point(447, 199);
            buttonSaida.Name = "buttonSaida";
            buttonSaida.Size = new Size(94, 39);
            buttonSaida.TabIndex = 7;
            buttonSaida.Text = "Dar Saida";
            buttonSaida.UseVisualStyleBackColor = true;
            buttonSaida.Click += buttonSaida_Click;
            // 
            // textBoxListaVeiculosEntrada
            // 
            textBoxListaVeiculosEntrada.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxListaVeiculosEntrada.Location = new Point(559, 57);
            textBoxListaVeiculosEntrada.Multiline = true;
            textBoxListaVeiculosEntrada.Name = "textBoxListaVeiculosEntrada";
            textBoxListaVeiculosEntrada.ReadOnly = true;
            textBoxListaVeiculosEntrada.ScrollBars = ScrollBars.Both;
            textBoxListaVeiculosEntrada.Size = new Size(431, 492);
            textBoxListaVeiculosEntrada.TabIndex = 15;
            // 
            // textBoxListaVeiculosSaida
            // 
            textBoxListaVeiculosSaida.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxListaVeiculosSaida.ForeColor = Color.Red;
            textBoxListaVeiculosSaida.Location = new Point(14, 411);
            textBoxListaVeiculosSaida.Multiline = true;
            textBoxListaVeiculosSaida.Name = "textBoxListaVeiculosSaida";
            textBoxListaVeiculosSaida.ReadOnly = true;
            textBoxListaVeiculosSaida.ScrollBars = ScrollBars.Vertical;
            textBoxListaVeiculosSaida.Size = new Size(526, 139);
            textBoxListaVeiculosSaida.TabIndex = 13;
            // 
            // labelBemVindo
            // 
            labelBemVindo.AutoSize = true;
            labelBemVindo.Font = new Font("Showcard Gothic", 17F, FontStyle.Regular, GraphicsUnit.Point);
            labelBemVindo.ForeColor = Color.White;
            labelBemVindo.Location = new Point(134, 27);
            labelBemVindo.Name = "labelBemVindo";
            labelBemVindo.Size = new Size(328, 36);
            labelBemVindo.TabIndex = 0;
            labelBemVindo.Text = "Bem-Vindo Leandro!";
            // 
            // lblDigitarPlaca
            // 
            lblDigitarPlaca.AutoSize = true;
            lblDigitarPlaca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDigitarPlaca.ForeColor = Color.White;
            lblDigitarPlaca.Location = new Point(82, 97);
            lblDigitarPlaca.Name = "lblDigitarPlaca";
            lblDigitarPlaca.Size = new Size(231, 28);
            lblDigitarPlaca.TabIndex = 1;
            lblDigitarPlaca.Text = "Digite a Placa do Veículo:";
            // 
            // textBoxModelo
            // 
            textBoxModelo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxModelo.Location = new Point(321, 141);
            textBoxModelo.Name = "textBoxModelo";
            textBoxModelo.Size = new Size(219, 30);
            textBoxModelo.TabIndex = 4;
            // 
            // lblDigitarModelo
            // 
            lblDigitarModelo.AutoSize = true;
            lblDigitarModelo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDigitarModelo.ForeColor = Color.White;
            lblDigitarModelo.Location = new Point(62, 141);
            lblDigitarModelo.Name = "lblDigitarModelo";
            lblDigitarModelo.Size = new Size(257, 28);
            lblDigitarModelo.TabIndex = 3;
            lblDigitarModelo.Text = "Digite o Modelo do Veículo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(632, 27);
            label3.Name = "label3";
            label3.Size = new Size(315, 28);
            label3.TabIndex = 14;
            label3.Text = "Veículos Ativos no Estacionamento";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(120, 380);
            label1.Name = "label1";
            label1.Size = new Size(342, 28);
            label1.TabIndex = 12;
            label1.Text = "Veículos Baixados do Estacionamento:";
            // 
            // textBoxTempoPermanencia
            // 
            textBoxTempoPermanencia.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTempoPermanencia.Location = new Point(14, 301);
            textBoxTempoPermanencia.Margin = new Padding(3, 4, 3, 4);
            textBoxTempoPermanencia.Name = "textBoxTempoPermanencia";
            textBoxTempoPermanencia.ReadOnly = true;
            textBoxTempoPermanencia.Size = new Size(245, 39);
            textBoxTempoPermanencia.TabIndex = 9;
            textBoxTempoPermanencia.TextAlign = HorizontalAlignment.Center;
            // 
            // lblTempoPermanencia
            // 
            lblTempoPermanencia.AutoSize = true;
            lblTempoPermanencia.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTempoPermanencia.ForeColor = Color.White;
            lblTempoPermanencia.Location = new Point(31, 265);
            lblTempoPermanencia.Name = "lblTempoPermanencia";
            lblTempoPermanencia.Size = new Size(217, 28);
            lblTempoPermanencia.TabIndex = 8;
            lblTempoPermanencia.Text = "Tempo de Permanência:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(376, 260);
            label2.Name = "label2";
            label2.Size = new Size(173, 32);
            label2.TabIndex = 10;
            label2.Text = "Valor à Pagar:";
            // 
            // textBoxValorCobrado
            // 
            textBoxValorCobrado.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxValorCobrado.ForeColor = Color.Lime;
            textBoxValorCobrado.Location = new Point(376, 301);
            textBoxValorCobrado.Margin = new Padding(3, 4, 3, 4);
            textBoxValorCobrado.Name = "textBoxValorCobrado";
            textBoxValorCobrado.ReadOnly = true;
            textBoxValorCobrado.Size = new Size(164, 39);
            textBoxValorCobrado.TabIndex = 11;
            textBoxValorCobrado.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(128, 255, 128);
            label4.Location = new Point(264, 299);
            label4.Name = "label4";
            label4.Size = new Size(123, 41);
            label4.TabIndex = 16;
            label4.Text = ">>>>>";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 90, 128);
            ClientSize = new Size(1005, 565);
            Controls.Add(label4);
            Controls.Add(textBoxValorCobrado);
            Controls.Add(label2);
            Controls.Add(lblTempoPermanencia);
            Controls.Add(textBoxTempoPermanencia);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(lblDigitarModelo);
            Controls.Add(textBoxModelo);
            Controls.Add(lblDigitarPlaca);
            Controls.Add(labelBemVindo);
            Controls.Add(textBoxListaVeiculosSaida);
            Controls.Add(textBoxListaVeiculosEntrada);
            Controls.Add(buttonSaida);
            Controls.Add(buttonEntrada);
            Controls.Add(textBoxPlaca);
            Controls.Add(labelDataHora);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Estacionamento Atos";
            Load += TimerTick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDataHora;
        private TextBox textBoxPlaca;
        private Button buttonEntrada;
        private Button buttonSaida;
        private TextBox textBoxListaVeiculosEntrada;
        private TextBox textBoxListaVeiculosSaida;
        private Label labelBemVindo;
        private Label lblDigitarPlaca;
        private TextBox textBoxModelo;
        private Label lblDigitarModelo;
        private Label label3;
        private Label label1;
        private TextBox textBoxTempoPermanencia;
        private Label lblTempoPermanencia;
        private Label label2;
        private TextBox textBoxValorCobrado;
        private Label label4;
    }
}