namespace PianoForte.View
{
    partial class LeftClassroomForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeftClassroomForm));
            this.GroupBox = new System.Windows.Forms.GroupBox();
            this.PictureBox_Warning = new System.Windows.Forms.PictureBox();
            this.Button_CheckIn = new System.Windows.Forms.Button();
            this.TextBox_Status = new System.Windows.Forms.TextBox();
            this.PictureBox_TeacherImage = new System.Windows.Forms.PictureBox();
            this.PictureBox_RoomNumber = new System.Windows.Forms.PictureBox();
            this.Button_Setup = new System.Windows.Forms.Button();
            this.GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Warning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_TeacherImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_RoomNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox
            // 
            this.GroupBox.Controls.Add(this.PictureBox_Warning);
            this.GroupBox.Controls.Add(this.Button_CheckIn);
            this.GroupBox.Controls.Add(this.TextBox_Status);
            this.GroupBox.Controls.Add(this.PictureBox_TeacherImage);
            this.GroupBox.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.GroupBox.Location = new System.Drawing.Point(35, -9);
            this.GroupBox.Name = "GroupBox";
            this.GroupBox.Size = new System.Drawing.Size(165, 79);
            this.GroupBox.TabIndex = 2;
            this.GroupBox.TabStop = false;
            // 
            // PictureBox_Warning
            // 
            this.PictureBox_Warning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox_Warning.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Warning.Image")));
            this.PictureBox_Warning.InitialImage = null;
            this.PictureBox_Warning.Location = new System.Drawing.Point(143, 21);
            this.PictureBox_Warning.Name = "PictureBox_Warning";
            this.PictureBox_Warning.Size = new System.Drawing.Size(16, 16);
            this.PictureBox_Warning.TabIndex = 6;
            this.PictureBox_Warning.TabStop = false;
            this.PictureBox_Warning.Visible = false;
            // 
            // Button_CheckIn
            // 
            this.Button_CheckIn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_CheckIn.ForeColor = System.Drawing.Color.LimeGreen;
            this.Button_CheckIn.Location = new System.Drawing.Point(66, 50);
            this.Button_CheckIn.Name = "Button_CheckIn";
            this.Button_CheckIn.Size = new System.Drawing.Size(75, 23);
            this.Button_CheckIn.TabIndex = 4;
            this.Button_CheckIn.Text = "CHECK-IN";
            this.Button_CheckIn.UseVisualStyleBackColor = true;
            this.Button_CheckIn.Click += new System.EventHandler(this.Button_CheckIn_Click);
            // 
            // TextBox_Status
            // 
            this.TextBox_Status.Enabled = false;
            this.TextBox_Status.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_Status.Location = new System.Drawing.Point(66, 19);
            this.TextBox_Status.Name = "TextBox_Status";
            this.TextBox_Status.Size = new System.Drawing.Size(75, 23);
            this.TextBox_Status.TabIndex = 1;
            this.TextBox_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PictureBox_TeacherImage
            // 
            this.PictureBox_TeacherImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox_TeacherImage.Location = new System.Drawing.Point(6, 19);
            this.PictureBox_TeacherImage.Name = "PictureBox_TeacherImage";
            this.PictureBox_TeacherImage.Size = new System.Drawing.Size(54, 54);
            this.PictureBox_TeacherImage.TabIndex = 1;
            this.PictureBox_TeacherImage.TabStop = false;
            // 
            // PictureBox_RoomNumber
            // 
            this.PictureBox_RoomNumber.Location = new System.Drawing.Point(0, 0);
            this.PictureBox_RoomNumber.Name = "PictureBox_RoomNumber";
            this.PictureBox_RoomNumber.Size = new System.Drawing.Size(30, 30);
            this.PictureBox_RoomNumber.TabIndex = 3;
            this.PictureBox_RoomNumber.TabStop = false;
            // 
            // Button_Setup
            // 
            this.Button_Setup.Image = ((System.Drawing.Image)(resources.GetObject("Button_Setup.Image")));
            this.Button_Setup.Location = new System.Drawing.Point(0, 36);
            this.Button_Setup.Name = "Button_Setup";
            this.Button_Setup.Size = new System.Drawing.Size(30, 30);
            this.Button_Setup.TabIndex = 4;
            this.Button_Setup.UseVisualStyleBackColor = true;
            this.Button_Setup.Click += new System.EventHandler(this.Button_Setup_Click);
            // 
            // LeftClassroomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 70);
            this.Controls.Add(this.Button_Setup);
            this.Controls.Add(this.PictureBox_RoomNumber);
            this.Controls.Add(this.GroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LeftClassroomForm";
            this.GroupBox.ResumeLayout(false);
            this.GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Warning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_TeacherImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_RoomNumber)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox;
        private System.Windows.Forms.TextBox TextBox_Status;
        private System.Windows.Forms.PictureBox PictureBox_TeacherImage;
        private System.Windows.Forms.PictureBox PictureBox_RoomNumber;
        private System.Windows.Forms.Button Button_CheckIn;
        private System.Windows.Forms.Button Button_Setup;
        private System.Windows.Forms.PictureBox PictureBox_Warning;
    }
}