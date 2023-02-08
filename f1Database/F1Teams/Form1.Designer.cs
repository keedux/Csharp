
namespace F1Teams
{
    partial class MainMenu
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
            this.TestConn_btn = new System.Windows.Forms.Button();
            this.ViewRec_btn = new System.Windows.Forms.Button();
            this.AddRec_btn = new System.Windows.Forms.Button();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.RecViewer = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TestConn_btn
            // 
            this.TestConn_btn.AutoSize = true;
            this.TestConn_btn.Location = new System.Drawing.Point(30, 54);
            this.TestConn_btn.Name = "TestConn_btn";
            this.TestConn_btn.Size = new System.Drawing.Size(119, 40);
            this.TestConn_btn.TabIndex = 0;
            this.TestConn_btn.Text = "Test Connection";
            this.TestConn_btn.UseVisualStyleBackColor = true;
            this.TestConn_btn.Click += new System.EventHandler(this.TestConn_btn_Click);
            // 
            // ViewRec_btn
            // 
            this.ViewRec_btn.AutoSize = true;
            this.ViewRec_btn.Location = new System.Drawing.Point(30, 114);
            this.ViewRec_btn.Name = "ViewRec_btn";
            this.ViewRec_btn.Size = new System.Drawing.Size(119, 40);
            this.ViewRec_btn.TabIndex = 1;
            this.ViewRec_btn.Text = "View Record";
            this.ViewRec_btn.UseVisualStyleBackColor = true;
            this.ViewRec_btn.Click += new System.EventHandler(this.ViewRec_btn_Click);
            // 
            // AddRec_btn
            // 
            this.AddRec_btn.AutoSize = true;
            this.AddRec_btn.Location = new System.Drawing.Point(30, 173);
            this.AddRec_btn.Name = "AddRec_btn";
            this.AddRec_btn.Size = new System.Drawing.Size(119, 40);
            this.AddRec_btn.TabIndex = 2;
            this.AddRec_btn.Text = "Add Record";
            this.AddRec_btn.UseVisualStyleBackColor = true;
            this.AddRec_btn.Click += new System.EventHandler(this.AddRec_btn_Click);
            // 
            // Exit_btn
            // 
            this.Exit_btn.AutoSize = true;
            this.Exit_btn.Location = new System.Drawing.Point(30, 230);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(119, 40);
            this.Exit_btn.TabIndex = 3;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            this.Exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // RecViewer
            // 
            this.RecViewer.FormattingEnabled = true;
            this.RecViewer.Location = new System.Drawing.Point(178, 2);
            this.RecViewer.Name = "RecViewer";
            this.RecViewer.Size = new System.Drawing.Size(204, 446);
            this.RecViewer.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(475, 326);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(475, 246);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 6;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.RecViewer);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.AddRec_btn);
            this.Controls.Add(this.ViewRec_btn);
            this.Controls.Add(this.TestConn_btn);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestConn_btn;
        private System.Windows.Forms.Button ViewRec_btn;
        private System.Windows.Forms.Button AddRec_btn;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.ListBox RecViewer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

