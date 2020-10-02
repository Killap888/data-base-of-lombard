namespace Lombardo
{
    partial class FormNewCategory
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
            this.components = new System.ComponentModel.Container();
            this.textBoxIdCategory = new System.Windows.Forms.TextBox();
            this.buttonAddNewCategory = new System.Windows.Forms.Button();
            this.buttonUpdateCategory = new System.Windows.Forms.Button();
            this.textBoxAddNewCategory = new System.Windows.Forms.TextBox();
            this.dataGridViewCategory = new System.Windows.Forms.DataGridView();
            this.lombardDataSet = new Lombardo.LombardDataSet();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryTableAdapter = new Lombardo.LombardDataSetTableAdapters.CategoryTableAdapter();
            this.idкатегорииDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lombardDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxIdCategory
            // 
            this.textBoxIdCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "id_категории", true));
            this.textBoxIdCategory.Enabled = false;
            this.textBoxIdCategory.Location = new System.Drawing.Point(12, 300);
            this.textBoxIdCategory.Name = "textBoxIdCategory";
            this.textBoxIdCategory.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdCategory.TabIndex = 9;
            // 
            // buttonAddNewCategory
            // 
            this.buttonAddNewCategory.Location = new System.Drawing.Point(118, 326);
            this.buttonAddNewCategory.Name = "buttonAddNewCategory";
            this.buttonAddNewCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonAddNewCategory.TabIndex = 8;
            this.buttonAddNewCategory.Text = "Добавить";
            this.buttonAddNewCategory.UseVisualStyleBackColor = true;
            this.buttonAddNewCategory.Click += new System.EventHandler(this.buttonAddNewCategory_Click);
            // 
            // buttonUpdateCategory
            // 
            this.buttonUpdateCategory.Location = new System.Drawing.Point(11, 326);
            this.buttonUpdateCategory.Name = "buttonUpdateCategory";
            this.buttonUpdateCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateCategory.TabIndex = 7;
            this.buttonUpdateCategory.Text = "Изменить";
            this.buttonUpdateCategory.UseVisualStyleBackColor = true;
            this.buttonUpdateCategory.Click += new System.EventHandler(this.buttonUpdateCategory_Click);
            // 
            // textBoxAddNewCategory
            // 
            this.textBoxAddNewCategory.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.categoryBindingSource, "наименование", true));
            this.textBoxAddNewCategory.Location = new System.Drawing.Point(12, 269);
            this.textBoxAddNewCategory.MaxLength = 15;
            this.textBoxAddNewCategory.Name = "textBoxAddNewCategory";
            this.textBoxAddNewCategory.Size = new System.Drawing.Size(181, 20);
            this.textBoxAddNewCategory.TabIndex = 6;
            // 
            // dataGridViewCategory
            // 
            this.dataGridViewCategory.AutoGenerateColumns = false;
            this.dataGridViewCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idкатегорииDataGridViewTextBoxColumn,
            this.наименованиеDataGridViewTextBoxColumn});
            this.dataGridViewCategory.DataSource = this.categoryBindingSource;
            this.dataGridViewCategory.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewCategory.Name = "dataGridViewCategory";
            this.dataGridViewCategory.Size = new System.Drawing.Size(181, 238);
            this.dataGridViewCategory.TabIndex = 5;
            // 
            // lombardDataSet
            // 
            this.lombardDataSet.DataSetName = "LombardDataSet";
            this.lombardDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.lombardDataSet;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // idкатегорииDataGridViewTextBoxColumn
            // 
            this.idкатегорииDataGridViewTextBoxColumn.DataPropertyName = "id_категории";
            this.idкатегорииDataGridViewTextBoxColumn.HeaderText = "id_категории";
            this.idкатегорииDataGridViewTextBoxColumn.Name = "idкатегорииDataGridViewTextBoxColumn";
            this.idкатегорииDataGridViewTextBoxColumn.ReadOnly = true;
            this.idкатегорииDataGridViewTextBoxColumn.Visible = false;
            // 
            // наименованиеDataGridViewTextBoxColumn
            // 
            this.наименованиеDataGridViewTextBoxColumn.DataPropertyName = "наименование";
            this.наименованиеDataGridViewTextBoxColumn.HeaderText = "наименование";
            this.наименованиеDataGridViewTextBoxColumn.Name = "наименованиеDataGridViewTextBoxColumn";
            // 
            // FormNewCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 357);
            this.Controls.Add(this.textBoxIdCategory);
            this.Controls.Add(this.buttonAddNewCategory);
            this.Controls.Add(this.buttonUpdateCategory);
            this.Controls.Add(this.textBoxAddNewCategory);
            this.Controls.Add(this.dataGridViewCategory);
            this.Name = "FormNewCategory";
            this.Text = "FormNewCategory";
            this.Load += new System.EventHandler(this.FormNewCategory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lombardDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIdCategory;
        private System.Windows.Forms.Button buttonAddNewCategory;
        private System.Windows.Forms.Button buttonUpdateCategory;
        private System.Windows.Forms.TextBox textBoxAddNewCategory;
        private System.Windows.Forms.DataGridView dataGridViewCategory;
        private LombardDataSet lombardDataSet;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private LombardDataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idкатегорииDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
    }
}