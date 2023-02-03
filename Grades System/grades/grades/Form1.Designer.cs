
namespace grades
{
    partial class Form1
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
            this.addbtn = new System.Windows.Forms.Button();
            this.viewbtn = new System.Windows.Forms.Button();
            this.connectbtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.recordviewer = new System.Windows.Forms.ListBox();
            this.candidatenum = new System.Windows.Forms.TextBox();
            this.paper1 = new System.Windows.Forms.TextBox();
            this.paper2 = new System.Windows.Forms.TextBox();
            this.insertrecord = new System.Windows.Forms.Button();
            this.candidatelbl = new System.Windows.Forms.Label();
            this.paper1lbl = new System.Windows.Forms.Label();
            this.paper2lbl = new System.Windows.Forms.Label();
            this.recordclearbtn = new System.Windows.Forms.Button();
            this.deletedbt = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addbtn
            // 
            this.addbtn.Location = new System.Drawing.Point(12, 30);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(118, 47);
            this.addbtn.TabIndex = 0;
            this.addbtn.Text = "Add Record";
            this.addbtn.UseVisualStyleBackColor = true;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // viewbtn
            // 
            this.viewbtn.Location = new System.Drawing.Point(12, 83);
            this.viewbtn.Name = "viewbtn";
            this.viewbtn.Size = new System.Drawing.Size(118, 47);
            this.viewbtn.TabIndex = 1;
            this.viewbtn.Text = "View Record";
            this.viewbtn.UseVisualStyleBackColor = true;
            this.viewbtn.Click += new System.EventHandler(this.viewbtn_Click);
            // 
            // connectbtn
            // 
            this.connectbtn.Location = new System.Drawing.Point(12, 139);
            this.connectbtn.Name = "connectbtn";
            this.connectbtn.Size = new System.Drawing.Size(118, 47);
            this.connectbtn.TabIndex = 2;
            this.connectbtn.Text = "Test Connection";
            this.connectbtn.UseVisualStyleBackColor = true;
            this.connectbtn.Click += new System.EventHandler(this.connectbtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(12, 298);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(118, 47);
            this.exitbtn.TabIndex = 3;
            this.exitbtn.Text = "Exit";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // recordviewer
            // 
            this.recordviewer.FormattingEnabled = true;
            this.recordviewer.Location = new System.Drawing.Point(136, 30);
            this.recordviewer.Name = "recordviewer";
            this.recordviewer.Size = new System.Drawing.Size(203, 355);
            this.recordviewer.TabIndex = 4;
            this.recordviewer.SelectedIndexChanged += new System.EventHandler(this.recordviewer_SelectedIndexChanged);
            // 
            // candidatenum
            // 
            this.candidatenum.Location = new System.Drawing.Point(477, 30);
            this.candidatenum.Name = "candidatenum";
            this.candidatenum.Size = new System.Drawing.Size(166, 20);
            this.candidatenum.TabIndex = 5;
            this.candidatenum.Visible = false;
            // 
            // paper1
            // 
            this.paper1.Location = new System.Drawing.Point(477, 67);
            this.paper1.Name = "paper1";
            this.paper1.Size = new System.Drawing.Size(166, 20);
            this.paper1.TabIndex = 6;
            this.paper1.Visible = false;
            // 
            // paper2
            // 
            this.paper2.Location = new System.Drawing.Point(477, 102);
            this.paper2.Name = "paper2";
            this.paper2.Size = new System.Drawing.Size(166, 20);
            this.paper2.TabIndex = 7;
            this.paper2.Visible = false;
            // 
            // insertrecord
            // 
            this.insertrecord.Location = new System.Drawing.Point(477, 146);
            this.insertrecord.Name = "insertrecord";
            this.insertrecord.Size = new System.Drawing.Size(166, 33);
            this.insertrecord.TabIndex = 8;
            this.insertrecord.Text = "Insert Record";
            this.insertrecord.UseVisualStyleBackColor = true;
            this.insertrecord.Visible = false;
            this.insertrecord.Click += new System.EventHandler(this.insertrecord_Click);
            // 
            // candidatelbl
            // 
            this.candidatelbl.AutoSize = true;
            this.candidatelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.candidatelbl.Location = new System.Drawing.Point(345, 30);
            this.candidatelbl.Name = "candidatelbl";
            this.candidatelbl.Size = new System.Drawing.Size(126, 17);
            this.candidatelbl.TabIndex = 9;
            this.candidatelbl.Text = "Candidate Number";
            this.candidatelbl.Visible = false;
            // 
            // paper1lbl
            // 
            this.paper1lbl.AutoSize = true;
            this.paper1lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.paper1lbl.Location = new System.Drawing.Point(362, 67);
            this.paper1lbl.Name = "paper1lbl";
            this.paper1lbl.Size = new System.Drawing.Size(109, 17);
            this.paper1lbl.TabIndex = 10;
            this.paper1lbl.Text = "Paper 1 Results";
            this.paper1lbl.Visible = false;
            // 
            // paper2lbl
            // 
            this.paper2lbl.AutoSize = true;
            this.paper2lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.paper2lbl.Location = new System.Drawing.Point(362, 102);
            this.paper2lbl.Name = "paper2lbl";
            this.paper2lbl.Size = new System.Drawing.Size(109, 17);
            this.paper2lbl.TabIndex = 11;
            this.paper2lbl.Text = "Paper 2 Results";
            this.paper2lbl.Visible = false;
            // 
            // recordclearbtn
            // 
            this.recordclearbtn.Location = new System.Drawing.Point(136, 405);
            this.recordclearbtn.Name = "recordclearbtn";
            this.recordclearbtn.Size = new System.Drawing.Size(203, 33);
            this.recordclearbtn.TabIndex = 12;
            this.recordclearbtn.Text = "Clear";
            this.recordclearbtn.UseVisualStyleBackColor = true;
            this.recordclearbtn.Visible = false;
            this.recordclearbtn.Click += new System.EventHandler(this.recordclearbtn_Click);
            // 
            // deletedbt
            // 
            this.deletedbt.Location = new System.Drawing.Point(12, 192);
            this.deletedbt.Name = "deletedbt";
            this.deletedbt.Size = new System.Drawing.Size(118, 47);
            this.deletedbt.TabIndex = 13;
            this.deletedbt.Text = "Delete Record";
            this.deletedbt.UseVisualStyleBackColor = true;
            this.deletedbt.Click += new System.EventHandler(this.deletedbt_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(12, 245);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(118, 47);
            this.updatebtn.TabIndex = 14;
            this.updatebtn.Text = "Update Record";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.deletedbt);
            this.Controls.Add(this.recordclearbtn);
            this.Controls.Add(this.paper2lbl);
            this.Controls.Add(this.paper1lbl);
            this.Controls.Add(this.candidatelbl);
            this.Controls.Add(this.insertrecord);
            this.Controls.Add(this.paper2);
            this.Controls.Add(this.paper1);
            this.Controls.Add(this.candidatenum);
            this.Controls.Add(this.recordviewer);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.connectbtn);
            this.Controls.Add(this.viewbtn);
            this.Controls.Add(this.addbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.Button viewbtn;
        private System.Windows.Forms.Button connectbtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.ListBox recordviewer;
        private System.Windows.Forms.TextBox candidatenum;
        private System.Windows.Forms.TextBox paper1;
        private System.Windows.Forms.TextBox paper2;
        private System.Windows.Forms.Button insertrecord;
        private System.Windows.Forms.Label candidatelbl;
        private System.Windows.Forms.Label paper1lbl;
        private System.Windows.Forms.Label paper2lbl;
        private System.Windows.Forms.Button recordclearbtn;
        private System.Windows.Forms.Button deletedbt;
        private System.Windows.Forms.Button updatebtn;
    }
}

