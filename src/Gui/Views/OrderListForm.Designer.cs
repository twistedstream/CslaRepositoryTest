namespace CslaRepositoryTest.Gui.Views
{
    partial class OrderListForm
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
            this._ordersDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._orderInfoCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._newButton = new System.Windows.Forms.Button();
            this._deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._ordersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderInfoCollectionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _ordersDataGridView
            // 
            this._ordersDataGridView.AutoGenerateColumns = false;
            this._ordersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._ordersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn});
            this._ordersDataGridView.DataSource = this._orderInfoCollectionBindingSource;
            this._ordersDataGridView.Location = new System.Drawing.Point(12, 12);
            this._ordersDataGridView.Name = "_ordersDataGridView";
            this._ordersDataGridView.Size = new System.Drawing.Size(502, 214);
            this._ordersDataGridView.TabIndex = 0;
            this._ordersDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this._ordersDataGridView_CellMouseDoubleClick);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // _orderInfoCollectionBindingSource
            // 
            this._orderInfoCollectionBindingSource.DataSource = typeof(CslaRepositoryTest.BusinessLayer.OrderInfoCollection);
            // 
            // _newButton
            // 
            this._newButton.Location = new System.Drawing.Point(438, 238);
            this._newButton.Name = "_newButton";
            this._newButton.Size = new System.Drawing.Size(75, 23);
            this._newButton.TabIndex = 1;
            this._newButton.Text = "New Order";
            this._newButton.UseVisualStyleBackColor = true;
            this._newButton.Click += new System.EventHandler(this._newButton_Click);
            // 
            // _deleteButton
            // 
            this._deleteButton.Location = new System.Drawing.Point(357, 238);
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(75, 23);
            this._deleteButton.TabIndex = 1;
            this._deleteButton.Text = "Delete Order";
            this._deleteButton.UseVisualStyleBackColor = true;
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // OrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 273);
            this.Controls.Add(this._deleteButton);
            this.Controls.Add(this._newButton);
            this.Controls.Add(this._ordersDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "OrderListForm";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.OrderListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._ordersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderInfoCollectionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _ordersDataGridView;
        private System.Windows.Forms.Button _newButton;
        private System.Windows.Forms.Button _deleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource _orderInfoCollectionBindingSource;
    }
}