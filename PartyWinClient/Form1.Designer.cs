namespace PartyWinClient
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
            this.btnJoinParty = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPartySpots = new System.Windows.Forms.TextBox();
            this.txtPartyTitle = new System.Windows.Forms.TextBox();
            this.btnCreateParty = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.btnCreatePerson = new System.Windows.Forms.Button();
            this.btnJoinSafe = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnJoinParty
            // 
            this.btnJoinParty.Location = new System.Drawing.Point(24, 144);
            this.btnJoinParty.Name = "btnJoinParty";
            this.btnJoinParty.Size = new System.Drawing.Size(159, 23);
            this.btnJoinParty.TabIndex = 0;
            this.btnJoinParty.Text = "Join!";
            this.btnJoinParty.UseVisualStyleBackColor = true;
            this.btnJoinParty.Click += new System.EventHandler(this.btnJoinParty_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Parties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "People";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPartySpots);
            this.groupBox1.Controls.Add(this.txtPartyTitle);
            this.groupBox1.Controls.Add(this.btnCreateParty);
            this.groupBox1.Location = new System.Drawing.Point(500, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 159);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Party";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Spots";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Title";
            // 
            // txtPartySpots
            // 
            this.txtPartySpots.Location = new System.Drawing.Point(6, 82);
            this.txtPartySpots.Name = "txtPartySpots";
            this.txtPartySpots.Size = new System.Drawing.Size(100, 20);
            this.txtPartySpots.TabIndex = 8;
            this.txtPartySpots.TextChanged += new System.EventHandler(this.txtPartySpots_TextChanged);
            // 
            // txtPartyTitle
            // 
            this.txtPartyTitle.Location = new System.Drawing.Point(6, 43);
            this.txtPartyTitle.Name = "txtPartyTitle";
            this.txtPartyTitle.Size = new System.Drawing.Size(100, 20);
            this.txtPartyTitle.TabIndex = 7;
            // 
            // btnCreateParty
            // 
            this.btnCreateParty.Location = new System.Drawing.Point(6, 108);
            this.btnCreateParty.Name = "btnCreateParty";
            this.btnCreateParty.Size = new System.Drawing.Size(75, 23);
            this.btnCreateParty.TabIndex = 6;
            this.btnCreateParty.Text = "Create";
            this.btnCreateParty.UseVisualStyleBackColor = true;
            this.btnCreateParty.Click += new System.EventHandler(this.btnCreateParty_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtLastName);
            this.groupBox2.Controls.Add(this.txtFirstName);
            this.groupBox2.Controls.Add(this.btnCreatePerson);
            this.groupBox2.Location = new System.Drawing.Point(500, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 157);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "LastName";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "FirstName";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(6, 82);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 8;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(6, 43);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 7;
            // 
            // btnCreatePerson
            // 
            this.btnCreatePerson.Location = new System.Drawing.Point(6, 108);
            this.btnCreatePerson.Name = "btnCreatePerson";
            this.btnCreatePerson.Size = new System.Drawing.Size(75, 23);
            this.btnCreatePerson.TabIndex = 6;
            this.btnCreatePerson.Text = "Create";
            this.btnCreatePerson.UseVisualStyleBackColor = true;
            this.btnCreatePerson.Click += new System.EventHandler(this.btnCreatePerson_Click);
            // 
            // btnJoinSafe
            // 
            this.btnJoinSafe.Location = new System.Drawing.Point(24, 173);
            this.btnJoinSafe.Name = "btnJoinSafe";
            this.btnJoinSafe.Size = new System.Drawing.Size(159, 23);
            this.btnJoinSafe.TabIndex = 7;
            this.btnJoinSafe.Text = "Join! (Safe)";
            this.btnJoinSafe.UseVisualStyleBackColor = true;
            this.btnJoinSafe.Click += new System.EventHandler(this.btnJoinSafe_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(12, 352);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(252, 83);
            this.txtStatus.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Status";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 447);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnJoinSafe);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJoinParty);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJoinParty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartySpots;
        private System.Windows.Forms.TextBox txtPartyTitle;
        private System.Windows.Forms.Button btnCreateParty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Button btnCreatePerson;
        private System.Windows.Forms.Button btnJoinSafe;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label7;
    }
}

