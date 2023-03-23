namespace Configuracao
{
    partial class FormCadastroGrupoUsuario
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label nomeGrupoLabel;
            this.nomeGrupoTextBox = new System.Windows.Forms.TextBox();
            this.grupoUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancelarGrupoUsuario = new System.Windows.Forms.Button();
            this.buttonSalvarGrupoUsuario = new System.Windows.Forms.Button();
            nomeGrupoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grupoUsuarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // nomeGrupoLabel
            // 
            nomeGrupoLabel.AutoSize = true;
            nomeGrupoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeGrupoLabel.Location = new System.Drawing.Point(8, 101);
            nomeGrupoLabel.Name = "nomeGrupoLabel";
            nomeGrupoLabel.Size = new System.Drawing.Size(109, 20);
            nomeGrupoLabel.TabIndex = 1;
            nomeGrupoLabel.Text = "Nome Grupo:";
            nomeGrupoLabel.Click += new System.EventHandler(this.nomeGrupoLabel_Click);
            // 
            // nomeGrupoTextBox
            // 
            this.nomeGrupoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.grupoUsuarioBindingSource, "NomeGrupo", true));
            this.nomeGrupoTextBox.Location = new System.Drawing.Point(12, 144);
            this.nomeGrupoTextBox.Name = "nomeGrupoTextBox";
            this.nomeGrupoTextBox.Size = new System.Drawing.Size(295, 22);
            this.nomeGrupoTextBox.TabIndex = 2;
            // 
            // grupoUsuarioBindingSource
            // 
            this.grupoUsuarioBindingSource.DataSource = typeof(Models.GrupoUsuario);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cadastro de Grupo Usuario";
            // 
            // buttonCancelarGrupoUsuario
            // 
            this.buttonCancelarGrupoUsuario.Location = new System.Drawing.Point(356, 299);
            this.buttonCancelarGrupoUsuario.Name = "buttonCancelarGrupoUsuario";
            this.buttonCancelarGrupoUsuario.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarGrupoUsuario.TabIndex = 4;
            this.buttonCancelarGrupoUsuario.Text = "cancelar";
            this.buttonCancelarGrupoUsuario.UseVisualStyleBackColor = true;
            // 
            // buttonSalvarGrupoUsuario
            // 
            this.buttonSalvarGrupoUsuario.Location = new System.Drawing.Point(208, 299);
            this.buttonSalvarGrupoUsuario.Name = "buttonSalvarGrupoUsuario";
            this.buttonSalvarGrupoUsuario.Size = new System.Drawing.Size(75, 23);
            this.buttonSalvarGrupoUsuario.TabIndex = 4;
            this.buttonSalvarGrupoUsuario.Text = "Salvar";
            this.buttonSalvarGrupoUsuario.UseVisualStyleBackColor = true;
            this.buttonSalvarGrupoUsuario.Click += new System.EventHandler(this.buttonSalvarGrupoUsuario_Click);
            // 
            // FormCadastroGrupoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSalvarGrupoUsuario);
            this.Controls.Add(this.buttonCancelarGrupoUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(nomeGrupoLabel);
            this.Controls.Add(this.nomeGrupoTextBox);
            this.Name = "FormCadastroGrupoUsuario";
            this.Text = "FormCadastroGrupoUsuario";
            this.Load += new System.EventHandler(this.FormCadastroGrupoUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grupoUsuarioBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource grupoUsuarioBindingSource;
        private System.Windows.Forms.TextBox nomeGrupoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancelarGrupoUsuario;
        private System.Windows.Forms.Button buttonSalvarGrupoUsuario;
    }
}