namespace GUI_32_Bit
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
            label_label = new Label();
            SDI_lable = new Label();
            value_label = new Label();
            ssm_label = new Label();
            parity_label = new Label();
            start_bit_label = new Label();
            scale_factor_label = new Label();
            label_textbox = new TextBox();
            value_textbox = new TextBox();
            startbit_textbox = new TextBox();
            scale_factor_textbox = new TextBox();
            sdi_combobox = new ComboBox();
            ssm_combobox = new ComboBox();
            parity_combobox = new ComboBox();
            generate_message_button = new Button();
            label_error_label = new Label();
            value_error_label = new Label();
            start_bit_error_label = new Label();
            scale_factor_error_label = new Label();
            sdi_error_label = new Label();
            ssm_error_label = new Label();
            parity_error_label = new Label();
            SuspendLayout();
            // 
            // label_label
            // 
            label_label.AutoSize = true;
            label_label.Location = new Point(123, 64);
            label_label.Name = "label_label";
            label_label.Size = new Size(84, 15);
            label_label.TabIndex = 0;
            label_label.Text = "LABEL(OCTAL)";
            // 
            // SDI_lable
            // 
            SDI_lable.AutoSize = true;
            SDI_lable.Location = new Point(123, 99);
            SDI_lable.Name = "SDI_lable";
            SDI_lable.Size = new Size(24, 15);
            SDI_lable.TabIndex = 1;
            SDI_lable.Text = "SDI";
            // 
            // value_label
            // 
            value_label.AutoSize = true;
            value_label.Location = new Point(123, 137);
            value_label.Name = "value_label";
            value_label.Size = new Size(35, 15);
            value_label.TabIndex = 2;
            value_label.Text = "Value";
            // 
            // ssm_label
            // 
            ssm_label.AutoSize = true;
            ssm_label.Location = new Point(123, 176);
            ssm_label.Name = "ssm_label";
            ssm_label.Size = new Size(65, 15);
            ssm_label.TabIndex = 3;
            ssm_label.Text = "SSM(30,31)";
            // 
            // parity_label
            // 
            parity_label.AutoSize = true;
            parity_label.Location = new Point(123, 214);
            parity_label.Name = "parity_label";
            parity_label.Size = new Size(37, 15);
            parity_label.TabIndex = 4;
            parity_label.Text = "Parity";
            // 
            // start_bit_label
            // 
            start_bit_label.AutoSize = true;
            start_bit_label.Location = new Point(532, 140);
            start_bit_label.Name = "start_bit_label";
            start_bit_label.Size = new Size(48, 15);
            start_bit_label.TabIndex = 5;
            start_bit_label.Text = "Start Bit";
            // 
            // scale_factor_label
            // 
            scale_factor_label.AutoSize = true;
            scale_factor_label.Location = new Point(532, 179);
            scale_factor_label.Name = "scale_factor_label";
            scale_factor_label.Size = new Size(70, 15);
            scale_factor_label.TabIndex = 6;
            scale_factor_label.Text = "Scale Factor";
            // 
            // label_textbox
            // 
            label_textbox.Location = new Point(218, 65);
            label_textbox.Name = "label_textbox";
            label_textbox.Size = new Size(100, 23);
            label_textbox.TabIndex = 7;
            label_textbox.TextChanged += label_textbox_TextChanged;
            // 
            // value_textbox
            // 
            value_textbox.Location = new Point(218, 137);
            value_textbox.Name = "value_textbox";
            value_textbox.Size = new Size(100, 23);
            value_textbox.TabIndex = 9;
            value_textbox.TextChanged += value_textbox_TextChanged;
            // 
            // startbit_textbox
            // 
            startbit_textbox.Location = new Point(640, 137);
            startbit_textbox.Name = "startbit_textbox";
            startbit_textbox.Size = new Size(100, 23);
            startbit_textbox.TabIndex = 12;
            startbit_textbox.TextChanged += startbit_textbox_TextChanged;
            // 
            // scale_factor_textbox
            // 
            scale_factor_textbox.Location = new Point(640, 179);
            scale_factor_textbox.Name = "scale_factor_textbox";
            scale_factor_textbox.Size = new Size(100, 23);
            scale_factor_textbox.TabIndex = 13;
            scale_factor_textbox.TextChanged += scale_factor_textbox_TextChanged;
            // 
            // sdi_combobox
            // 
            sdi_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            sdi_combobox.FormattingEnabled = true;
            sdi_combobox.Items.AddRange(new object[] { "00", "01", "10", "11" });
            sdi_combobox.Location = new Point(218, 99);
            sdi_combobox.Name = "sdi_combobox";
            sdi_combobox.Size = new Size(100, 23);
            sdi_combobox.TabIndex = 14;
            sdi_combobox.SelectedIndexChanged += sdi_combobox_SelectedIndexChanged;
            // 
            // ssm_combobox
            // 
            ssm_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            ssm_combobox.FormattingEnabled = true;
            ssm_combobox.Items.AddRange(new object[] { "00", "01", "10", "11" });
            ssm_combobox.Location = new Point(218, 176);
            ssm_combobox.Name = "ssm_combobox";
            ssm_combobox.Size = new Size(100, 23);
            ssm_combobox.TabIndex = 15;
            // 
            // parity_combobox
            // 
            parity_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            parity_combobox.FormattingEnabled = true;
            parity_combobox.Items.AddRange(new object[] { "0", "1" });
            parity_combobox.Location = new Point(218, 214);
            parity_combobox.Name = "parity_combobox";
            parity_combobox.Size = new Size(100, 23);
            parity_combobox.TabIndex = 16;
            // 
            // generate_message_button
            // 
            generate_message_button.Location = new Point(460, 419);
            generate_message_button.Name = "generate_message_button";
            generate_message_button.Size = new Size(142, 51);
            generate_message_button.TabIndex = 17;
            generate_message_button.Text = "Generate Message";
            generate_message_button.UseVisualStyleBackColor = true;
            generate_message_button.Click += generate_message_button_Click;
            // 
            // label_error_label
            // 
            label_error_label.AutoSize = true;
            label_error_label.ForeColor = Color.Red;
            label_error_label.Location = new Point(324, 68);
            label_error_label.Name = "label_error_label";
            label_error_label.Size = new Size(32, 15);
            label_error_label.TabIndex = 18;
            label_error_label.Text = "Error";
            label_error_label.Visible = false;
            // 
            // value_error_label
            // 
            value_error_label.AutoSize = true;
            value_error_label.ForeColor = Color.Red;
            value_error_label.Location = new Point(324, 140);
            value_error_label.Name = "value_error_label";
            value_error_label.Size = new Size(32, 15);
            value_error_label.TabIndex = 19;
            value_error_label.Text = "Error";
            value_error_label.Visible = false;
            // 
            // start_bit_error_label
            // 
            start_bit_error_label.AutoSize = true;
            start_bit_error_label.ForeColor = Color.Red;
            start_bit_error_label.Location = new Point(755, 140);
            start_bit_error_label.Name = "start_bit_error_label";
            start_bit_error_label.Size = new Size(32, 15);
            start_bit_error_label.TabIndex = 20;
            start_bit_error_label.Text = "Error";
            start_bit_error_label.Visible = false;
            // 
            // scale_factor_error_label
            // 
            scale_factor_error_label.AutoSize = true;
            scale_factor_error_label.ForeColor = Color.Red;
            scale_factor_error_label.Location = new Point(755, 182);
            scale_factor_error_label.Name = "scale_factor_error_label";
            scale_factor_error_label.Size = new Size(32, 15);
            scale_factor_error_label.TabIndex = 21;
            scale_factor_error_label.Text = "Error";
            scale_factor_error_label.Visible = false;
            // 
            // sdi_error_label
            // 
            sdi_error_label.AutoSize = true;
            sdi_error_label.ForeColor = Color.Red;
            sdi_error_label.Location = new Point(324, 102);
            sdi_error_label.Name = "sdi_error_label";
            sdi_error_label.Size = new Size(32, 15);
            sdi_error_label.TabIndex = 22;
            sdi_error_label.Text = "Error";
            sdi_error_label.Visible = false;
            // 
            // ssm_error_label
            // 
            ssm_error_label.AutoSize = true;
            ssm_error_label.ForeColor = Color.Red;
            ssm_error_label.Location = new Point(324, 179);
            ssm_error_label.Name = "ssm_error_label";
            ssm_error_label.Size = new Size(32, 15);
            ssm_error_label.TabIndex = 23;
            ssm_error_label.Text = "Error";
            ssm_error_label.Visible = false;
            // 
            // parity_error_label
            // 
            parity_error_label.AutoSize = true;
            parity_error_label.ForeColor = Color.Red;
            parity_error_label.Location = new Point(324, 217);
            parity_error_label.Name = "parity_error_label";
            parity_error_label.Size = new Size(32, 15);
            parity_error_label.TabIndex = 24;
            parity_error_label.Text = "Error";
            parity_error_label.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1069, 555);
            Controls.Add(parity_error_label);
            Controls.Add(ssm_error_label);
            Controls.Add(sdi_error_label);
            Controls.Add(scale_factor_error_label);
            Controls.Add(start_bit_error_label);
            Controls.Add(value_error_label);
            Controls.Add(label_error_label);
            Controls.Add(generate_message_button);
            Controls.Add(parity_combobox);
            Controls.Add(ssm_combobox);
            Controls.Add(sdi_combobox);
            Controls.Add(scale_factor_textbox);
            Controls.Add(startbit_textbox);
            Controls.Add(value_textbox);
            Controls.Add(label_textbox);
            Controls.Add(scale_factor_label);
            Controls.Add(start_bit_label);
            Controls.Add(parity_label);
            Controls.Add(ssm_label);
            Controls.Add(value_label);
            Controls.Add(SDI_lable);
            Controls.Add(label_label);
            Name = "Form1";
            Text = "GUI_32_Bit";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_label;
        private Label SDI_lable;
        private Label value_label;
        private Label ssm_label;
        private Label parity_label;
        private Label start_bit_label;
        private Label scale_factor_label;
        private TextBox label_textbox;
        private TextBox value_textbox;
        private TextBox startbit_textbox;
        private TextBox scale_factor_textbox;
        private ComboBox sdi_combobox;
        private ComboBox ssm_combobox;
        private ComboBox parity_combobox;
        private Button generate_message_button;
        private Label label_error_label;
        private Label value_error_label;
        private Label start_bit_error_label;
        private Label scale_factor_error_label;
        private Label sdi_error_label;
        private Label ssm_error_label;
        private Label parity_error_label;
    }
}
