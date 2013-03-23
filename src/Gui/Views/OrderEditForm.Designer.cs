namespace CslaRepositoryTest.Gui.Views
{
    partial class OrderEditForm
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
            System.Windows.Forms.Label _shippingCostLabel;
            System.Windows.Forms.Label _lineItemsLabel;
            System.Windows.Forms.Label _dateLabel;
            System.Windows.Forms.Label _customerLabel;
            this._orderErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._cancelButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._lineItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.productNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._lineItemCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._shippingCostTextBox = new System.Windows.Forms.TextBox();
            this._dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._customerTextBox = new System.Windows.Forms.TextBox();
            this._bindingSourceRefresh = new Csla.Windows.BindingSourceRefresh(this.components);
            this._applyButton = new System.Windows.Forms.Button();
            this._close = new System.Windows.Forms.Button();
            _shippingCostLabel = new System.Windows.Forms.Label();
            _lineItemsLabel = new System.Windows.Forms.Label();
            _dateLabel = new System.Windows.Forms.Label();
            _customerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._orderErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._lineItemsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._lineItemCollectionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSourceRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // _shippingCostLabel
            // 
            _shippingCostLabel.AutoSize = true;
            _shippingCostLabel.Location = new System.Drawing.Point(293, 43);
            _shippingCostLabel.Name = "_shippingCostLabel";
            _shippingCostLabel.Size = new System.Drawing.Size(75, 13);
            _shippingCostLabel.TabIndex = 19;
            _shippingCostLabel.Text = "Shipping Cost:";
            // 
            // _lineItemsLabel
            // 
            _lineItemsLabel.AutoSize = true;
            _lineItemsLabel.Location = new System.Drawing.Point(8, 74);
            _lineItemsLabel.Name = "_lineItemsLabel";
            _lineItemsLabel.Size = new System.Drawing.Size(58, 13);
            _lineItemsLabel.TabIndex = 17;
            _lineItemsLabel.Text = "Line Items:";
            // 
            // _dateLabel
            // 
            _dateLabel.AutoSize = true;
            _dateLabel.Location = new System.Drawing.Point(33, 43);
            _dateLabel.Name = "_dateLabel";
            _dateLabel.Size = new System.Drawing.Size(33, 13);
            _dateLabel.TabIndex = 16;
            _dateLabel.Text = "Date:";
            // 
            // _customerLabel
            // 
            _customerLabel.AutoSize = true;
            _customerLabel.Location = new System.Drawing.Point(12, 9);
            _customerLabel.Name = "_customerLabel";
            _customerLabel.Size = new System.Drawing.Size(54, 13);
            _customerLabel.TabIndex = 12;
            _customerLabel.Text = "Customer:";
            // 
            // _orderErrorProvider
            // 
            this._orderErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._orderErrorProvider.ContainerControl = this;
            this._orderErrorProvider.DataSource = this._orderBindingSource;
            // 
            // _orderBindingSource
            // 
            this._orderBindingSource.DataSource = typeof(CslaRepositoryTest.BusinessLayer.Order);
            this._bindingSourceRefresh.SetReadValuesOnChange(this._orderBindingSource, false);
            this._orderBindingSource.CurrentItemChanged += new System.EventHandler(this._orderBindingSource_CurrentItemChanged);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(237, 260);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 22;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _okButton
            // 
            this._okButton.Location = new System.Drawing.Point(156, 260);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 23;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            this._okButton.Click += new System.EventHandler(this._okButton_Click);
            // 
            // _lineItemsDataGridView
            // 
            this._lineItemsDataGridView.AutoGenerateColumns = false;
            this._lineItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._lineItemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this._lineItemsDataGridView.DataSource = this._lineItemCollectionBindingSource;
            this._lineItemsDataGridView.Location = new System.Drawing.Point(72, 74);
            this._lineItemsDataGridView.Name = "_lineItemsDataGridView";
            this._lineItemsDataGridView.Size = new System.Drawing.Size(404, 173);
            this._lineItemsDataGridView.TabIndex = 21;
            // 
            // productNameDataGridViewTextBoxColumn
            // 
            this.productNameDataGridViewTextBoxColumn.DataPropertyName = "ProductName";
            this.productNameDataGridViewTextBoxColumn.HeaderText = "ProductName";
            this.productNameDataGridViewTextBoxColumn.Name = "productNameDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // _lineItemCollectionBindingSource
            // 
            this._lineItemCollectionBindingSource.AllowNew = true;
            this._lineItemCollectionBindingSource.DataMember = "LineItems";
            this._lineItemCollectionBindingSource.DataSource = this._orderBindingSource;
            this._bindingSourceRefresh.SetReadValuesOnChange(this._lineItemCollectionBindingSource, false);
            this._lineItemCollectionBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this._lineItemCollectionBindingSource_ListChanged);
            // 
            // _shippingCostTextBox
            // 
            this._shippingCostTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._orderBindingSource, "ShippingCost", true));
            this._shippingCostTextBox.Location = new System.Drawing.Point(374, 40);
            this._shippingCostTextBox.Name = "_shippingCostTextBox";
            this._shippingCostTextBox.Size = new System.Drawing.Size(83, 20);
            this._shippingCostTextBox.TabIndex = 20;
            // 
            // _dateDateTimePicker
            // 
            this._dateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this._orderBindingSource, "Date", true));
            this._dateDateTimePicker.Location = new System.Drawing.Point(72, 39);
            this._dateDateTimePicker.Name = "_dateDateTimePicker";
            this._dateDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this._dateDateTimePicker.TabIndex = 18;
            // 
            // _customerTextBox
            // 
            this._customerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this._orderBindingSource, "Customer", true));
            this._customerTextBox.Location = new System.Drawing.Point(72, 6);
            this._customerTextBox.Name = "_customerTextBox";
            this._customerTextBox.Size = new System.Drawing.Size(385, 20);
            this._customerTextBox.TabIndex = 13;
            // 
            // _bindingSourceRefresh
            // 
            this._bindingSourceRefresh.Host = this;
            // 
            // _applyButton
            // 
            this._applyButton.Location = new System.Drawing.Point(318, 260);
            this._applyButton.Name = "_applyButton";
            this._applyButton.Size = new System.Drawing.Size(75, 23);
            this._applyButton.TabIndex = 23;
            this._applyButton.Text = "Apply";
            this._applyButton.UseVisualStyleBackColor = true;
            this._applyButton.Click += new System.EventHandler(this._applyButton_Click);
            // 
            // _close
            // 
            this._close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._close.Location = new System.Drawing.Point(399, 260);
            this._close.Name = "_close";
            this._close.Size = new System.Drawing.Size(75, 23);
            this._close.TabIndex = 22;
            this._close.Text = "Close";
            this._close.UseVisualStyleBackColor = true;
            // 
            // OrderEditForm
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._close;
            this.ClientSize = new System.Drawing.Size(486, 295);
            this.Controls.Add(this._close);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._applyButton);
            this.Controls.Add(this._okButton);
            this.Controls.Add(this._lineItemsDataGridView);
            this.Controls.Add(_shippingCostLabel);
            this.Controls.Add(this._shippingCostTextBox);
            this.Controls.Add(_lineItemsLabel);
            this.Controls.Add(_dateLabel);
            this.Controls.Add(this._dateDateTimePicker);
            this.Controls.Add(_customerLabel);
            this.Controls.Add(this._customerTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderEditForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.OrderEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderEditForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._orderErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._lineItemsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._lineItemCollectionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._bindingSourceRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource _orderBindingSource;
        private System.Windows.Forms.ErrorProvider _orderErrorProvider;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.DataGridView _lineItemsDataGridView;
        private System.Windows.Forms.TextBox _shippingCostTextBox;
        private System.Windows.Forms.DateTimePicker _dateDateTimePicker;
        private System.Windows.Forms.TextBox _customerTextBox;
        private System.Windows.Forms.BindingSource _lineItemCollectionBindingSource;
        private Csla.Windows.BindingSourceRefresh _bindingSourceRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button _applyButton;
        private System.Windows.Forms.Button _close;
    }
}