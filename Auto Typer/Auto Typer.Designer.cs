namespace Auto_Typer
{
    partial class AutoTyper
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
            hotkeytext2 = new Label();
            label1 = new Label();
            hotkeytext1 = new Label();
            hotkeytext3 = new Label();
            hotkeytext4 = new Label();
            label = new Label();
            DelayMax = new TextBox();
            DelayMin = new TextBox();
            MainText = new TextBox();
            Hotkey2 = new NoFocusButton();
            Hotkey1 = new NoFocusButton();
            SuspendLayout();
            // 
            // hotkeytext2
            // 
            hotkeytext2.AutoSize = true;
            hotkeytext2.Font = new Font("Microsoft Sans Serif", 12F);
            hotkeytext2.Location = new Point(118, 78);
            hotkeytext2.Name = "hotkeytext2";
            hotkeytext2.Size = new Size(69, 29);
            hotkeytext2.TabIndex = 4;
            hotkeytext2.Text = "Stop:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F);
            label1.Location = new Point(121, 144);
            label1.Name = "label1";
            label1.Size = new Size(0, 29);
            label1.TabIndex = 9;
            // 
            // hotkeytext1
            // 
            hotkeytext1.AutoSize = true;
            hotkeytext1.BackColor = Color.Transparent;
            hotkeytext1.Font = new Font("Microsoft Sans Serif", 13F);
            hotkeytext1.Location = new Point(34, 30);
            hotkeytext1.Name = "hotkeytext1";
            hotkeytext1.Size = new Size(153, 30);
            hotkeytext1.TabIndex = 3;
            hotkeytext1.Text = "Start/Pause:";
            // 
            // hotkeytext3
            // 
            hotkeytext3.AutoSize = true;
            hotkeytext3.Font = new Font("Microsoft Sans Serif", 12F);
            hotkeytext3.Location = new Point(118, 143);
            hotkeytext3.Name = "hotkeytext3";
            hotkeytext3.Size = new Size(66, 29);
            hotkeytext3.TabIndex = 12;
            hotkeytext3.Text = "Text:";
            // 
            // hotkeytext4
            // 
            hotkeytext4.AutoSize = true;
            hotkeytext4.Font = new Font("Microsoft Sans Serif", 12F);
            hotkeytext4.Location = new Point(53, 362);
            hotkeytext4.Name = "hotkeytext4";
            hotkeytext4.Size = new Size(134, 29);
            hotkeytext4.TabIndex = 15;
            hotkeytext4.Text = "Delay (ms):";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Microsoft Sans Serif", 12F);
            label.Location = new Point(359, 362);
            label.Name = "label";
            label.Size = new Size(21, 29);
            label.TabIndex = 18;
            label.Text = "-";
            // 
            // DelayMax
            // 
            DelayMax.BorderStyle = BorderStyle.None;
            DelayMax.Location = new Point(395, 362);
            DelayMax.MaxLength = 13;
            DelayMax.Multiline = true;
            DelayMax.Name = "DelayMax";
            DelayMax.Size = new Size(147, 33);
            DelayMax.TabIndex = 19;
            DelayMax.Text = "250";
            DelayMax.TextAlign = HorizontalAlignment.Center;
            DelayMax.KeyPress += Delay_KeyPress;
            DelayMax.PreviewKeyDown += Form_PreviewKeyDown;
            // 
            // DelayMin
            // 
            DelayMin.BorderStyle = BorderStyle.None;
            DelayMin.Location = new Point(197, 362);
            DelayMin.MaxLength = 13;
            DelayMin.Multiline = true;
            DelayMin.Name = "DelayMin";
            DelayMin.Size = new Size(147, 33);
            DelayMin.TabIndex = 20;
            DelayMin.Text = "150";
            DelayMin.TextAlign = HorizontalAlignment.Center;
            DelayMin.KeyPress += Delay_KeyPress;
            DelayMin.PreviewKeyDown += Form_PreviewKeyDown;
            // 
            // MainText
            // 
            MainText.BorderStyle = BorderStyle.None;
            MainText.Location = new Point(197, 146);
            MainText.Multiline = true;
            MainText.Name = "MainText";
            MainText.ScrollBars = ScrollBars.Both;
            MainText.Size = new Size(507, 181);
            MainText.TabIndex = 13;
            MainText.Text = "Insert Text Here";
            MainText.PreviewKeyDown += Form_PreviewKeyDown;
            // 
            // Hotkey2
            // 
            Hotkey2.BackColor = Color.White;
            Hotkey2.FlatAppearance.BorderSize = 0;
            Hotkey2.FlatAppearance.MouseDownBackColor = Color.White;
            Hotkey2.FlatAppearance.MouseOverBackColor = Color.White;
            Hotkey2.FlatStyle = FlatStyle.Flat;
            Hotkey2.Location = new Point(197, 78);
            Hotkey2.Name = "Hotkey2";
            Hotkey2.Size = new Size(146, 33);
            Hotkey2.TabIndex = 21;
            Hotkey2.Text = "F3";
            Hotkey2.UseVisualStyleBackColor = false;
            Hotkey2.MouseDown += Hotkey_MouseDown;
            Hotkey2.PreviewKeyDown += Form_PreviewKeyDown;
            // 
            // Hotkey1
            // 
            Hotkey1.BackColor = Color.White;
            Hotkey1.FlatAppearance.BorderSize = 0;
            Hotkey1.FlatAppearance.MouseDownBackColor = Color.White;
            Hotkey1.FlatAppearance.MouseOverBackColor = Color.White;
            Hotkey1.FlatStyle = FlatStyle.Flat;
            Hotkey1.Location = new Point(197, 30);
            Hotkey1.Name = "Hotkey1";
            Hotkey1.Size = new Size(146, 33);
            Hotkey1.TabIndex = 22;
            Hotkey1.Text = "F2";
            Hotkey1.UseVisualStyleBackColor = false;
            Hotkey1.MouseDown += Hotkey_MouseDown;
            Hotkey1.PreviewKeyDown += Form_PreviewKeyDown;
            // 
            // AutoTyper
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Hotkey1);
            Controls.Add(Hotkey2);
            Controls.Add(MainText);
            Controls.Add(DelayMin);
            Controls.Add(DelayMax);
            Controls.Add(label);
            Controls.Add(hotkeytext4);
            Controls.Add(hotkeytext3);
            Controls.Add(label1);
            Controls.Add(hotkeytext2);
            Controls.Add(hotkeytext1);
            Name = "AutoTyper";
            Text = "Auto Typer";
            PreviewKeyDown += Form_PreviewKeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label hotkeytext2;
        private Label label1;
        private Label hotkeytext1;
        private Label hotkeytext3;
        private TextBox MainText;
        private Label hotkeytext4;
        private Label label;
        private TextBox DelayMax;
        private TextBox DelayMin;
        private NoFocusButton Hotkey2;
        private NoFocusButton Hotkey1;
    }
}
