namespace matriz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            dataGridView1 = new DataGridView();
            identificador = new DataGridViewTextBoxColumn();
            notoken = new DataGridViewTextBoxColumn();
            Simbolo = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            fila = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            descripcionn = new DataGridViewTextBoxColumn();
            Renglon = new DataGridViewTextBoxColumn();
            Columna = new DataGridViewTextBoxColumn();
            AnalisisText = new RichTextBox();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            noerror = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridView3 = new DataGridView();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(492, 506);
            button1.Name = "button1";
            button1.Size = new Size(117, 27);
            button1.TabIndex = 1;
            button1.Text = "Buscar archivo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            button2.Location = new Point(349, 506);
            button2.Name = "button2";
            button2.Size = new Size(119, 27);
            button2.TabIndex = 3;
            button2.Text = "Leer texto";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "Tokens";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 306);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 7;
            label2.Text = "Errores lexicos";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ActiveBorder;
            richTextBox1.Location = new Point(490, 30);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(458, 274);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            richTextBox1.WordWrap = false;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { identificador, notoken, Simbolo, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn1 });
            dataGridView1.Location = new Point(10, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(456, 274);
            dataGridView1.TabIndex = 9;
            // 
            // identificador
            // 
            identificador.HeaderText = "ID";
            identificador.MinimumWidth = 6;
            identificador.Name = "identificador";
            identificador.Width = 30;
            // 
            // notoken
            // 
            notoken.HeaderText = "No Token";
            notoken.MinimumWidth = 6;
            notoken.Name = "notoken";
            notoken.ReadOnly = true;
            notoken.Width = 50;
            // 
            // Simbolo
            // 
            Simbolo.HeaderText = "Simbolo";
            Simbolo.MinimumWidth = 6;
            Simbolo.Name = "Simbolo";
            Simbolo.ReadOnly = true;
            Simbolo.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Renglon";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Columna";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, fila, dataGridViewTextBoxColumn6, descripcionn });
            dataGridView2.Location = new Point(10, 324);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(456, 176);
            dataGridView2.TabIndex = 10;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "No Error";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 50;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Simbolo";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            dataGridViewTextBoxColumn8.Width = 125;
            // 
            // fila
            // 
            fila.HeaderText = "Fila";
            fila.MinimumWidth = 6;
            fila.Name = "fila";
            fila.ReadOnly = true;
            fila.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Columna";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 80;
            // 
            // descripcionn
            // 
            descripcionn.HeaderText = "Descripcion";
            descripcionn.MinimumWidth = 6;
            descripcionn.Name = "descripcionn";
            descripcionn.ReadOnly = true;
            descripcionn.Width = 300;
            // 
            // Renglon
            // 
            Renglon.HeaderText = "Renglon";
            Renglon.MinimumWidth = 6;
            Renglon.Name = "Renglon";
            Renglon.ReadOnly = true;
            Renglon.Width = 125;
            // 
            // Columna
            // 
            Columna.HeaderText = "Columna";
            Columna.MinimumWidth = 6;
            Columna.Name = "Columna";
            Columna.ReadOnly = true;
            Columna.Width = 125;
            // 
            // AnalisisText
            // 
            AnalisisText.BackColor = SystemColors.Highlight;
            AnalisisText.BorderStyle = BorderStyle.None;
            AnalisisText.Font = new Font("Segoe UI", 13.75F, FontStyle.Regular, GraphicsUnit.Point);
            AnalisisText.ForeColor = SystemColors.Info;
            AnalisisText.Location = new Point(14, 539);
            AnalisisText.Name = "AnalisisText";
            AnalisisText.ReadOnly = true;
            AnalisisText.Size = new Size(935, 120);
            AnalisisText.TabIndex = 11;
            AnalisisText.Text = "Esperando analisis...";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Renglon";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Columna";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 60;
            // 
            // noerror
            // 
            noerror.HeaderText = "No Error";
            noerror.MinimumWidth = 6;
            noerror.Name = "noerror";
            noerror.ReadOnly = true;
            noerror.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Simbolo";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn9, dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn13 });
            dataGridView3.Location = new Point(490, 324);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(458, 176);
            dataGridView3.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "No. Simbolo";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewTextBoxColumn10.HeaderText = "Simbolo";
            dataGridViewTextBoxColumn10.MinimumWidth = 6;
            dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            dataGridViewTextBoxColumn10.ReadOnly = true;
            dataGridViewTextBoxColumn10.Width = 155;
            // 
            // dataGridViewTextBoxColumn13
            // 
            dataGridViewTextBoxColumn13.HeaderText = "Tipo";
            dataGridViewTextBoxColumn13.MinimumWidth = 6;
            dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            dataGridViewTextBoxColumn13.ReadOnly = true;
            dataGridViewTextBoxColumn13.Width = 270;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(492, 306);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 13;
            label3.Text = "Tabla de simbolos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(970, 664);
            Controls.Add(label3);
            Controls.Add(dataGridView3);
            Controls.Add(AnalisisText);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Analisis lexico, sintactico y semantico";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private Button button2;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBox1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Renglon;
        private DataGridViewTextBoxColumn Columna;
        private DataGridViewTextBoxColumn Descripcion;
        private RichTextBox AnalisisText;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn noerror;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn identificador;
        private DataGridViewTextBoxColumn notoken;
        private DataGridViewTextBoxColumn Simbolo;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn fila;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn descripcionn;
        private DataGridView dataGridView3;
        private Label label3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
    }
}