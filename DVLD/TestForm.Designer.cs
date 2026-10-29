namespace DVLD
{
    partial class TestForm
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
            this.btnAddTest = new System.Windows.Forms.Button();
            this.btnUpdateTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddTest
            // 
            this.btnAddTest.Location = new System.Drawing.Point(182, 78);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(106, 23);
            this.btnAddTest.TabIndex = 0;
            this.btnAddTest.Text = "Add Tester";
            this.btnAddTest.UseVisualStyleBackColor = true;
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            // 
            // btnUpdateTest
            // 
            this.btnUpdateTest.Location = new System.Drawing.Point(182, 136);
            this.btnUpdateTest.Name = "btnUpdateTest";
            this.btnUpdateTest.Size = new System.Drawing.Size(106, 23);
            this.btnUpdateTest.TabIndex = 1;
            this.btnUpdateTest.Text = "Update Teseter";
            this.btnUpdateTest.UseVisualStyleBackColor = true;
            this.btnUpdateTest.Click += new System.EventHandler(this.btnUpdateTest_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 377);
            this.Controls.Add(this.btnUpdateTest);
            this.Controls.Add(this.btnAddTest);
            this.Name = "TestForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnUpdateTest;
    }
}

