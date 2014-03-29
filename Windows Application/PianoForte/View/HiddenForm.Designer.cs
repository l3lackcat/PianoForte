namespace PianoForte.View
{
    partial class HiddenForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBox_generate_printed_payments = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_payment_types = new System.Windows.Forms.CheckBox();
            this.Button_start_generate = new System.Windows.Forms.Button();
            this.CheckBox_generate_product_price_history = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_teached_courses = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_classroom_detail = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_classrooms = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_enrollments = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_payment_details = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_payments = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_course_categories = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_other_products = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_books = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_cds = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_courses = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_users = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_teachers = new System.Windows.Forms.CheckBox();
            this.CheckBox_generate_students = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CheckBox_update_students = new System.Windows.Forms.CheckBox();
            this.Button_start_update = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 538);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database Migration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckBox_generate_printed_payments);
            this.groupBox1.Controls.Add(this.CheckBox_generate_payment_types);
            this.groupBox1.Controls.Add(this.Button_start_generate);
            this.groupBox1.Controls.Add(this.CheckBox_generate_product_price_history);
            this.groupBox1.Controls.Add(this.CheckBox_generate_teached_courses);
            this.groupBox1.Controls.Add(this.CheckBox_generate_classroom_detail);
            this.groupBox1.Controls.Add(this.CheckBox_generate_classrooms);
            this.groupBox1.Controls.Add(this.CheckBox_generate_enrollments);
            this.groupBox1.Controls.Add(this.CheckBox_generate_payment_details);
            this.groupBox1.Controls.Add(this.CheckBox_generate_payments);
            this.groupBox1.Controls.Add(this.CheckBox_generate_course_categories);
            this.groupBox1.Controls.Add(this.CheckBox_generate_other_products);
            this.groupBox1.Controls.Add(this.CheckBox_generate_books);
            this.groupBox1.Controls.Add(this.CheckBox_generate_cds);
            this.groupBox1.Controls.Add(this.CheckBox_generate_courses);
            this.groupBox1.Controls.Add(this.CheckBox_generate_users);
            this.groupBox1.Controls.Add(this.CheckBox_generate_teachers);
            this.groupBox1.Controls.Add(this.CheckBox_generate_students);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 180);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate Query (.sql)";
            // 
            // CheckBox_generate_printed_payments
            // 
            this.CheckBox_generate_printed_payments.AutoSize = true;
            this.CheckBox_generate_printed_payments.Location = new System.Drawing.Point(240, 65);
            this.CheckBox_generate_printed_payments.Name = "CheckBox_generate_printed_payments";
            this.CheckBox_generate_printed_payments.Size = new System.Drawing.Size(109, 17);
            this.CheckBox_generate_printed_payments.TabIndex = 17;
            this.CheckBox_generate_printed_payments.Text = "printed_payments";
            this.CheckBox_generate_printed_payments.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_payment_types
            // 
            this.CheckBox_generate_payment_types.AutoSize = true;
            this.CheckBox_generate_payment_types.Location = new System.Drawing.Point(240, 42);
            this.CheckBox_generate_payment_types.Name = "CheckBox_generate_payment_types";
            this.CheckBox_generate_payment_types.Size = new System.Drawing.Size(97, 17);
            this.CheckBox_generate_payment_types.TabIndex = 16;
            this.CheckBox_generate_payment_types.Text = "payment_types";
            this.CheckBox_generate_payment_types.UseVisualStyleBackColor = true;
            // 
            // Button_start_generate
            // 
            this.Button_start_generate.Location = new System.Drawing.Point(659, 151);
            this.Button_start_generate.Name = "Button_start_generate";
            this.Button_start_generate.Size = new System.Drawing.Size(75, 23);
            this.Button_start_generate.TabIndex = 15;
            this.Button_start_generate.Text = "Start";
            this.Button_start_generate.UseVisualStyleBackColor = true;
            this.Button_start_generate.Click += new System.EventHandler(this.Button_start_Click);
            // 
            // CheckBox_generate_product_price_history
            // 
            this.CheckBox_generate_product_price_history.AutoSize = true;
            this.CheckBox_generate_product_price_history.Location = new System.Drawing.Point(360, 42);
            this.CheckBox_generate_product_price_history.Name = "CheckBox_generate_product_price_history";
            this.CheckBox_generate_product_price_history.Size = new System.Drawing.Size(127, 17);
            this.CheckBox_generate_product_price_history.TabIndex = 14;
            this.CheckBox_generate_product_price_history.Text = "product_price_history";
            this.CheckBox_generate_product_price_history.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_teached_courses
            // 
            this.CheckBox_generate_teached_courses.AutoSize = true;
            this.CheckBox_generate_teached_courses.Location = new System.Drawing.Point(360, 19);
            this.CheckBox_generate_teached_courses.Name = "CheckBox_generate_teached_courses";
            this.CheckBox_generate_teached_courses.Size = new System.Drawing.Size(108, 17);
            this.CheckBox_generate_teached_courses.TabIndex = 13;
            this.CheckBox_generate_teached_courses.Text = "teached_courses";
            this.CheckBox_generate_teached_courses.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_classroom_detail
            // 
            this.CheckBox_generate_classroom_detail.AutoSize = true;
            this.CheckBox_generate_classroom_detail.Location = new System.Drawing.Point(240, 157);
            this.CheckBox_generate_classroom_detail.Name = "CheckBox_generate_classroom_detail";
            this.CheckBox_generate_classroom_detail.Size = new System.Drawing.Size(109, 17);
            this.CheckBox_generate_classroom_detail.TabIndex = 12;
            this.CheckBox_generate_classroom_detail.Text = "classroom_details";
            this.CheckBox_generate_classroom_detail.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_classrooms
            // 
            this.CheckBox_generate_classrooms.AutoSize = true;
            this.CheckBox_generate_classrooms.Location = new System.Drawing.Point(240, 134);
            this.CheckBox_generate_classrooms.Name = "CheckBox_generate_classrooms";
            this.CheckBox_generate_classrooms.Size = new System.Drawing.Size(78, 17);
            this.CheckBox_generate_classrooms.TabIndex = 11;
            this.CheckBox_generate_classrooms.Text = "classrooms";
            this.CheckBox_generate_classrooms.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_enrollments
            // 
            this.CheckBox_generate_enrollments.AutoSize = true;
            this.CheckBox_generate_enrollments.Location = new System.Drawing.Point(240, 111);
            this.CheckBox_generate_enrollments.Name = "CheckBox_generate_enrollments";
            this.CheckBox_generate_enrollments.Size = new System.Drawing.Size(79, 17);
            this.CheckBox_generate_enrollments.TabIndex = 10;
            this.CheckBox_generate_enrollments.Text = "enrollments";
            this.CheckBox_generate_enrollments.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_payment_details
            // 
            this.CheckBox_generate_payment_details.AutoSize = true;
            this.CheckBox_generate_payment_details.Location = new System.Drawing.Point(240, 88);
            this.CheckBox_generate_payment_details.Name = "CheckBox_generate_payment_details";
            this.CheckBox_generate_payment_details.Size = new System.Drawing.Size(102, 17);
            this.CheckBox_generate_payment_details.TabIndex = 9;
            this.CheckBox_generate_payment_details.Text = "payment_details";
            this.CheckBox_generate_payment_details.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_payments
            // 
            this.CheckBox_generate_payments.AutoSize = true;
            this.CheckBox_generate_payments.Location = new System.Drawing.Point(240, 19);
            this.CheckBox_generate_payments.Name = "CheckBox_generate_payments";
            this.CheckBox_generate_payments.Size = new System.Drawing.Size(71, 17);
            this.CheckBox_generate_payments.TabIndex = 8;
            this.CheckBox_generate_payments.Text = "payments";
            this.CheckBox_generate_payments.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_course_categories
            // 
            this.CheckBox_generate_course_categories.AutoSize = true;
            this.CheckBox_generate_course_categories.Location = new System.Drawing.Point(120, 42);
            this.CheckBox_generate_course_categories.Name = "CheckBox_generate_course_categories";
            this.CheckBox_generate_course_categories.Size = new System.Drawing.Size(113, 17);
            this.CheckBox_generate_course_categories.TabIndex = 7;
            this.CheckBox_generate_course_categories.Text = "course_categories";
            this.CheckBox_generate_course_categories.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_other_products
            // 
            this.CheckBox_generate_other_products.AutoSize = true;
            this.CheckBox_generate_other_products.Location = new System.Drawing.Point(120, 111);
            this.CheckBox_generate_other_products.Name = "CheckBox_generate_other_products";
            this.CheckBox_generate_other_products.Size = new System.Drawing.Size(97, 17);
            this.CheckBox_generate_other_products.TabIndex = 6;
            this.CheckBox_generate_other_products.Text = "other_products";
            this.CheckBox_generate_other_products.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_books
            // 
            this.CheckBox_generate_books.AutoSize = true;
            this.CheckBox_generate_books.Location = new System.Drawing.Point(120, 65);
            this.CheckBox_generate_books.Name = "CheckBox_generate_books";
            this.CheckBox_generate_books.Size = new System.Drawing.Size(55, 17);
            this.CheckBox_generate_books.TabIndex = 5;
            this.CheckBox_generate_books.Text = "books";
            this.CheckBox_generate_books.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_cds
            // 
            this.CheckBox_generate_cds.AutoSize = true;
            this.CheckBox_generate_cds.Location = new System.Drawing.Point(120, 88);
            this.CheckBox_generate_cds.Name = "CheckBox_generate_cds";
            this.CheckBox_generate_cds.Size = new System.Drawing.Size(43, 17);
            this.CheckBox_generate_cds.TabIndex = 4;
            this.CheckBox_generate_cds.Text = "cds";
            this.CheckBox_generate_cds.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_courses
            // 
            this.CheckBox_generate_courses.AutoSize = true;
            this.CheckBox_generate_courses.Location = new System.Drawing.Point(120, 19);
            this.CheckBox_generate_courses.Name = "CheckBox_generate_courses";
            this.CheckBox_generate_courses.Size = new System.Drawing.Size(63, 17);
            this.CheckBox_generate_courses.TabIndex = 3;
            this.CheckBox_generate_courses.Text = "courses";
            this.CheckBox_generate_courses.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_users
            // 
            this.CheckBox_generate_users.AutoSize = true;
            this.CheckBox_generate_users.Location = new System.Drawing.Point(6, 65);
            this.CheckBox_generate_users.Name = "CheckBox_generate_users";
            this.CheckBox_generate_users.Size = new System.Drawing.Size(51, 17);
            this.CheckBox_generate_users.TabIndex = 2;
            this.CheckBox_generate_users.Text = "users";
            this.CheckBox_generate_users.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_teachers
            // 
            this.CheckBox_generate_teachers.AutoSize = true;
            this.CheckBox_generate_teachers.Location = new System.Drawing.Point(6, 42);
            this.CheckBox_generate_teachers.Name = "CheckBox_generate_teachers";
            this.CheckBox_generate_teachers.Size = new System.Drawing.Size(67, 17);
            this.CheckBox_generate_teachers.TabIndex = 1;
            this.CheckBox_generate_teachers.Text = "teachers";
            this.CheckBox_generate_teachers.UseVisualStyleBackColor = true;
            // 
            // CheckBox_generate_students
            // 
            this.CheckBox_generate_students.AutoSize = true;
            this.CheckBox_generate_students.Location = new System.Drawing.Point(6, 19);
            this.CheckBox_generate_students.Name = "CheckBox_generate_students";
            this.CheckBox_generate_students.Size = new System.Drawing.Size(66, 17);
            this.CheckBox_generate_students.TabIndex = 0;
            this.CheckBox_generate_students.Text = "students";
            this.CheckBox_generate_students.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Button_start_update);
            this.groupBox2.Controls.Add(this.CheckBox_update_students);
            this.groupBox2.Location = new System.Drawing.Point(6, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 180);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // CheckBox_update_students
            // 
            this.CheckBox_update_students.AutoSize = true;
            this.CheckBox_update_students.Location = new System.Drawing.Point(6, 19);
            this.CheckBox_update_students.Name = "CheckBox_update_students";
            this.CheckBox_update_students.Size = new System.Drawing.Size(66, 17);
            this.CheckBox_update_students.TabIndex = 0;
            this.CheckBox_update_students.Text = "students";
            this.CheckBox_update_students.UseVisualStyleBackColor = true;
            // 
            // Button_start_update
            // 
            this.Button_start_update.Location = new System.Drawing.Point(659, 151);
            this.Button_start_update.Name = "Button_start_update";
            this.Button_start_update.Size = new System.Drawing.Size(75, 23);
            this.Button_start_update.TabIndex = 1;
            this.Button_start_update.Text = "Start";
            this.Button_start_update.UseVisualStyleBackColor = true;
            this.Button_start_update.Click += new System.EventHandler(this.Button_start_update_Click);
            // 
            // HiddenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tabControl1);
            this.Name = "HiddenForm";
            this.Text = "HiddenForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckBox_generate_cds;
        private System.Windows.Forms.CheckBox CheckBox_generate_courses;
        private System.Windows.Forms.CheckBox CheckBox_generate_users;
        private System.Windows.Forms.CheckBox CheckBox_generate_teachers;
        private System.Windows.Forms.CheckBox CheckBox_generate_students;
        private System.Windows.Forms.CheckBox CheckBox_generate_books;
        private System.Windows.Forms.CheckBox CheckBox_generate_course_categories;
        private System.Windows.Forms.CheckBox CheckBox_generate_other_products;
        private System.Windows.Forms.CheckBox CheckBox_generate_classrooms;
        private System.Windows.Forms.CheckBox CheckBox_generate_enrollments;
        private System.Windows.Forms.CheckBox CheckBox_generate_payment_details;
        private System.Windows.Forms.CheckBox CheckBox_generate_payments;
        private System.Windows.Forms.CheckBox CheckBox_generate_teached_courses;
        private System.Windows.Forms.CheckBox CheckBox_generate_classroom_detail;
        private System.Windows.Forms.Button Button_start_generate;
        private System.Windows.Forms.CheckBox CheckBox_generate_product_price_history;
        private System.Windows.Forms.CheckBox CheckBox_generate_printed_payments;
        private System.Windows.Forms.CheckBox CheckBox_generate_payment_types;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox CheckBox_update_students;
        private System.Windows.Forms.Button Button_start_update;
    }
}