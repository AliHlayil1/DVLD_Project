namespace DVLD
{
    partial class MainForm
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
            this.pSideMenu = new System.Windows.Forms.Panel();
            this.pApplicationFeature = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAplications = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnacountSetting = new System.Windows.Forms.Button();
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnPeople = new System.Windows.Forms.Button();
            this.btnDasboard = new System.Windows.Forms.Button();
            this.pHeadSideMenu = new System.Windows.Forms.Panel();
            this.pMainBody = new System.Windows.Forms.Panel();
            this.pSideMenu.SuspendLayout();
            this.pApplicationFeature.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSideMenu
            // 
            this.pSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pSideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSideMenu.Controls.Add(this.pApplicationFeature);
            this.pSideMenu.Controls.Add(this.btnLogout);
            this.pSideMenu.Controls.Add(this.btnacountSetting);
            this.pSideMenu.Controls.Add(this.btnDrivers);
            this.pSideMenu.Controls.Add(this.btnUsers);
            this.pSideMenu.Controls.Add(this.btnPeople);
            this.pSideMenu.Controls.Add(this.btnDasboard);
            this.pSideMenu.Controls.Add(this.pHeadSideMenu);
            this.pSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pSideMenu.Name = "pSideMenu";
            this.pSideMenu.Size = new System.Drawing.Size(250, 749);
            this.pSideMenu.TabIndex = 0;
            // 
            // pApplicationFeature
            // 
            this.pApplicationFeature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pApplicationFeature.Controls.Add(this.label1);
            this.pApplicationFeature.Controls.Add(this.btnAplications);
            this.pApplicationFeature.Dock = System.Windows.Forms.DockStyle.Top;
            this.pApplicationFeature.Location = new System.Drawing.Point(0, 340);
            this.pApplicationFeature.Name = "pApplicationFeature";
            this.pApplicationFeature.Size = new System.Drawing.Size(248, 43);
            this.pApplicationFeature.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // btnAplications
            // 
            this.btnAplications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAplications.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAplications.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnAplications.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAplications.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAplications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplications.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAplications.Image = global::DVLD.Properties.Resources.id;
            this.btnAplications.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAplications.Location = new System.Drawing.Point(0, 0);
            this.btnAplications.Name = "btnAplications";
            this.btnAplications.Size = new System.Drawing.Size(250, 40);
            this.btnAplications.TabIndex = 6;
            this.btnAplications.Text = "Aplications";
            this.btnAplications.UseVisualStyleBackColor = false;
            this.btnAplications.Click += new System.EventHandler(this.btnAplications_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogout.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnLogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogout.Image = global::DVLD.Properties.Resources.id;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(0, 300);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(248, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnacountSetting
            // 
            this.btnacountSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnacountSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnacountSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnacountSetting.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnacountSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnacountSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnacountSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnacountSetting.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnacountSetting.Image = global::DVLD.Properties.Resources.id;
            this.btnacountSetting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnacountSetting.Location = new System.Drawing.Point(0, 260);
            this.btnacountSetting.Name = "btnacountSetting";
            this.btnacountSetting.Size = new System.Drawing.Size(248, 40);
            this.btnacountSetting.TabIndex = 7;
            this.btnacountSetting.Text = "Account Setting";
            this.btnacountSetting.UseVisualStyleBackColor = false;
            // 
            // btnDrivers
            // 
            this.btnDrivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDrivers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDrivers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDrivers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDrivers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDrivers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDrivers.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDrivers.Image = global::DVLD.Properties.Resources.id;
            this.btnDrivers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDrivers.Location = new System.Drawing.Point(0, 220);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(248, 40);
            this.btnDrivers.TabIndex = 5;
            this.btnDrivers.Text = "Drivers";
            this.btnDrivers.UseVisualStyleBackColor = false;
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsers.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnUsers.Image = global::DVLD.Properties.Resources.id;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(0, 180);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(248, 40);
            this.btnUsers.TabIndex = 4;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnPeople
            // 
            this.btnPeople.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPeople.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPeople.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPeople.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnPeople.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPeople.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPeople.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnPeople.Image = global::DVLD.Properties.Resources.person_man;
            this.btnPeople.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPeople.Location = new System.Drawing.Point(0, 140);
            this.btnPeople.Name = "btnPeople";
            this.btnPeople.Size = new System.Drawing.Size(248, 40);
            this.btnPeople.TabIndex = 3;
            this.btnPeople.Text = "People";
            this.btnPeople.UseVisualStyleBackColor = false;
            this.btnPeople.Click += new System.EventHandler(this.btnPeople_Click);
            // 
            // btnDasboard
            // 
            this.btnDasboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDasboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDasboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDasboard.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDasboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDasboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDasboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDasboard.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDasboard.Image = global::DVLD.Properties.Resources.monitor;
            this.btnDasboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDasboard.Location = new System.Drawing.Point(0, 100);
            this.btnDasboard.Name = "btnDasboard";
            this.btnDasboard.Size = new System.Drawing.Size(248, 40);
            this.btnDasboard.TabIndex = 2;
            this.btnDasboard.Text = "Dashboard";
            this.btnDasboard.UseVisualStyleBackColor = false;
            this.btnDasboard.Click += new System.EventHandler(this.btnDasboard_Click);
            // 
            // pHeadSideMenu
            // 
            this.pHeadSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pHeadSideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pHeadSideMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeadSideMenu.Location = new System.Drawing.Point(0, 0);
            this.pHeadSideMenu.Name = "pHeadSideMenu";
            this.pHeadSideMenu.Size = new System.Drawing.Size(248, 100);
            this.pHeadSideMenu.TabIndex = 0;
            // 
            // pMainBody
            // 
            this.pMainBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pMainBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMainBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainBody.Location = new System.Drawing.Point(250, 0);
            this.pMainBody.Name = "pMainBody";
            this.pMainBody.Size = new System.Drawing.Size(1114, 749);
            this.pMainBody.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.pMainBody);
            this.Controls.Add(this.pSideMenu);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pSideMenu.ResumeLayout(false);
            this.pApplicationFeature.ResumeLayout(false);
            this.pApplicationFeature.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSideMenu;
        private System.Windows.Forms.Panel pHeadSideMenu;
        private System.Windows.Forms.Panel pMainBody;
        private System.Windows.Forms.Button btnDasboard;
        private System.Windows.Forms.Button btnAplications;
        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnPeople;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnacountSetting;
        private System.Windows.Forms.Panel pApplicationFeature;
        private System.Windows.Forms.Label label1;
    }
}