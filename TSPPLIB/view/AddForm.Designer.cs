
namespace TSPPLIB.view
{
    partial class AddForm
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
            this.textBoxIdAdd = new System.Windows.Forms.TextBox();
            this.label1Add = new System.Windows.Forms.Label();
            this.label2Add = new System.Windows.Forms.Label();
            this.label3Add = new System.Windows.Forms.Label();
            this.label4Add = new System.Windows.Forms.Label();
            this.label5Add = new System.Windows.Forms.Label();
            this.textBoxNameAdd = new System.Windows.Forms.TextBox();
            this.textBoxAuthorAdd = new System.Windows.Forms.TextBox();
            this.textBoxYearAdd = new System.Windows.Forms.TextBox();
            this.textBoxLocationAdd = new System.Windows.Forms.TextBox();
            this.saveAddBtn = new System.Windows.Forms.Button();
            this.cancelAddBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIdAdd
            // 
            this.textBoxIdAdd.Location = new System.Drawing.Point(104, 31);
            this.textBoxIdAdd.Name = "textBoxIdAdd";
            this.textBoxIdAdd.Size = new System.Drawing.Size(55, 20);
            this.textBoxIdAdd.TabIndex = 0;
            // 
            // label1Add
            // 
            this.label1Add.AutoSize = true;
            this.label1Add.Location = new System.Drawing.Point(59, 34);
            this.label1Add.Name = "label1Add";
            this.label1Add.Size = new System.Drawing.Size(39, 13);
            this.label1Add.TabIndex = 1;
            this.label1Add.Text = "Шифр:";
            // 
            // label2Add
            // 
            this.label2Add.AutoSize = true;
            this.label2Add.Location = new System.Drawing.Point(56, 91);
            this.label2Add.Name = "label2Add";
            this.label2Add.Size = new System.Drawing.Size(42, 13);
            this.label2Add.TabIndex = 2;
            this.label2Add.Text = "Назва:";
            // 
            // label3Add
            // 
            this.label3Add.AutoSize = true;
            this.label3Add.Location = new System.Drawing.Point(58, 146);
            this.label3Add.Name = "label3Add";
            this.label3Add.Size = new System.Drawing.Size(40, 13);
            this.label3Add.TabIndex = 3;
            this.label3Add.Text = "Автор:";
            // 
            // label4Add
            // 
            this.label4Add.AutoSize = true;
            this.label4Add.Location = new System.Drawing.Point(28, 200);
            this.label4Add.Name = "label4Add";
            this.label4Add.Size = new System.Drawing.Size(70, 13);
            this.label4Add.TabIndex = 4;
            this.label4Add.Text = "Рік видання:";
            // 
            // label5Add
            // 
            this.label5Add.AutoSize = true;
            this.label5Add.Location = new System.Drawing.Point(15, 253);
            this.label5Add.Name = "label5Add";
            this.label5Add.Size = new System.Drawing.Size(83, 13);
            this.label5Add.TabIndex = 5;
            this.label5Add.Text = "Розташування:";
            // 
            // textBoxNameAdd
            // 
            this.textBoxNameAdd.Location = new System.Drawing.Point(104, 88);
            this.textBoxNameAdd.Name = "textBoxNameAdd";
            this.textBoxNameAdd.Size = new System.Drawing.Size(253, 20);
            this.textBoxNameAdd.TabIndex = 6;
            // 
            // textBoxAuthorAdd
            // 
            this.textBoxAuthorAdd.Location = new System.Drawing.Point(104, 143);
            this.textBoxAuthorAdd.Name = "textBoxAuthorAdd";
            this.textBoxAuthorAdd.Size = new System.Drawing.Size(253, 20);
            this.textBoxAuthorAdd.TabIndex = 7;
            // 
            // textBoxYearAdd
            // 
            this.textBoxYearAdd.Location = new System.Drawing.Point(104, 197);
            this.textBoxYearAdd.Name = "textBoxYearAdd";
            this.textBoxYearAdd.Size = new System.Drawing.Size(55, 20);
            this.textBoxYearAdd.TabIndex = 8;
            // 
            // textBoxLocationAdd
            // 
            this.textBoxLocationAdd.Location = new System.Drawing.Point(104, 250);
            this.textBoxLocationAdd.Name = "textBoxLocationAdd";
            this.textBoxLocationAdd.Size = new System.Drawing.Size(55, 20);
            this.textBoxLocationAdd.TabIndex = 9;
            // 
            // saveAddBtn
            // 
            this.saveAddBtn.Location = new System.Drawing.Point(27, 302);
            this.saveAddBtn.Name = "saveAddBtn";
            this.saveAddBtn.Size = new System.Drawing.Size(151, 23);
            this.saveAddBtn.TabIndex = 10;
            this.saveAddBtn.Text = "Зберегти";
            this.saveAddBtn.UseVisualStyleBackColor = true;
            this.saveAddBtn.Click += new System.EventHandler(this.saveAddBtn_Click);
            // 
            // cancelAddBtn
            // 
            this.cancelAddBtn.Location = new System.Drawing.Point(194, 302);
            this.cancelAddBtn.Name = "cancelAddBtn";
            this.cancelAddBtn.Size = new System.Drawing.Size(150, 23);
            this.cancelAddBtn.TabIndex = 11;
            this.cancelAddBtn.Text = "Скасувати";
            this.cancelAddBtn.UseVisualStyleBackColor = true;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 353);
            this.Controls.Add(this.cancelAddBtn);
            this.Controls.Add(this.saveAddBtn);
            this.Controls.Add(this.textBoxLocationAdd);
            this.Controls.Add(this.textBoxYearAdd);
            this.Controls.Add(this.textBoxAuthorAdd);
            this.Controls.Add(this.textBoxNameAdd);
            this.Controls.Add(this.label5Add);
            this.Controls.Add(this.label4Add);
            this.Controls.Add(this.label3Add);
            this.Controls.Add(this.label2Add);
            this.Controls.Add(this.label1Add);
            this.Controls.Add(this.textBoxIdAdd);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1Add;
        private System.Windows.Forms.Label label2Add;
        private System.Windows.Forms.Label label3Add;
        private System.Windows.Forms.Label label4Add;
        private System.Windows.Forms.Label label5Add;
        internal System.Windows.Forms.TextBox textBoxIdAdd;
        internal System.Windows.Forms.TextBox textBoxNameAdd;
        internal System.Windows.Forms.TextBox textBoxAuthorAdd;
        internal System.Windows.Forms.TextBox textBoxYearAdd;
        internal System.Windows.Forms.TextBox textBoxLocationAdd;
        internal System.Windows.Forms.Button saveAddBtn;
        internal System.Windows.Forms.Button cancelAddBtn;
    }
}