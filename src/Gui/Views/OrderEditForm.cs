using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CslaRepositoryTest.BusinessLayer;
using Csla;
using CslaRepositoryTest.Gui.Presenters;


namespace CslaRepositoryTest.Gui.Views
{


    public sealed partial class OrderEditForm 
        : Form, IOrderEditView
    {

        private IOrderEditPresenter _presenter;

        #region constructors

        public OrderEditForm(IOrderEditPresenter presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException("presenter");
            _presenter = presenter;
            InitializeComponent();
        }

        public OrderEditForm()
        {
            InitializeComponent();
        }

        #endregion

        #region private methods

        private void UnbindBindingSource(BindingSource source, bool apply, bool isRoot)
        {
            var current = source.Current as System.ComponentModel.IEditableObject;
            if (isRoot)
                source.DataSource = null;
            if (current != null)
                if (apply)
                    current.EndEdit();
                else
                    current.CancelEdit();
        }

        #endregion

        #region event-handling methods

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            _presenter.OnViewLoad();
        }

        private void OrderEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var userClosing = e.CloseReason == CloseReason.None || e.CloseReason == CloseReason.UserClosing;
            e.Cancel = !_presenter.OnViewClosing(userClosing);
        }

        private void _okButton_Click(object sender, EventArgs e)
        {
            _presenter.OnOkButtonClick();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            _presenter.OnCancelButtonClick();
        }

        private void _applyButton_Click(object sender, EventArgs e)
        {
            _presenter.OnApplyButtonClick();
        }

        private void _orderBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            _presenter.OnOrderChanged();
        }

        private void _lineItemCollectionBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            _presenter.OnOrderChanged();
        }

        #endregion

        #region IOrderEditView members

        void IOrderEditView.Show()
        {
            this.ShowDialog();
        }

        void IOrderEditView.SetOrderBindingSourceDataSource(object source)
        {
            _orderBindingSource.DataSource = source;
        }

        void IOrderEditView.SetLineItemsBindingSourceDataSource()
        {
            _lineItemCollectionBindingSource.DataSource = _orderBindingSource;
        }

        bool IOrderEditView.RaiseOrderBindSourceChangeEvents
        {
            get { return _orderBindingSource.RaiseListChangedEvents; }
            set { _orderBindingSource.RaiseListChangedEvents = value; }
        }

        bool IOrderEditView.RaiseLineItemsBindingSourceChangeEvents
        {
            get { return _lineItemCollectionBindingSource.RaiseListChangedEvents; }
            set { _lineItemCollectionBindingSource.RaiseListChangedEvents = value; }
        }

        void IOrderEditView.UnbindOrderBindingSource(bool apply)
        {
            UnbindBindingSource(_orderBindingSource, apply, true);
        }

        void IOrderEditView.UnbindLineItemsBindingSource(bool apply)
        {
            UnbindBindingSource(_lineItemCollectionBindingSource, apply, false);
        }

        void IOrderEditView.ResetOrderBindingSourceBindings()
        {
            _orderBindingSource.ResetBindings(false);
        }

        void IOrderEditView.ResetLineItemsBindingSourceBindings()
        {
            _lineItemCollectionBindingSource.ResetBindings(false);
        }

        string IOrderEditView.Caption
        {
            get { return Text; }
            set { Text = value; }
        }

        bool IOrderEditView.OkButtonEnabled
        {
            get { return _okButton.Enabled; }
            set { _okButton.Enabled = value; }
        }

        bool IOrderEditView.ApplyButtonEnabled
        {
            get { return _applyButton.Enabled; }
            set { _applyButton.Enabled = value; }
        }

        bool IOrderEditView.CancelButtonEnabled
        {
            get { return _cancelButton.Enabled; }
            set { _cancelButton.Enabled = value; }
        }

        #endregion

    }


}
