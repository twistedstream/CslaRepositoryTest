using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CslaRepositoryTest.BusinessLayer;
using CslaRepositoryTest.Gui.Presenters;


namespace CslaRepositoryTest.Gui.Views
{


    public sealed partial class OrderListForm
        : Form, IOrderListView, IStartupView
    {

        private IOrderListPresenter _presenter;

        public OrderListForm(IOrderListPresenter presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException("presenter");
            _presenter = presenter;
            InitializeComponent();
        }

        public OrderListForm()
        {
            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            _presenter.OnViewLoad();
        }

        private void _ordersDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _presenter.OnOrdersGridCellMouseDoubleClick();
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            _presenter.OnDeleteButtonClick();
        }

        private void _newButton_Click(object sender, EventArgs e)
        {
            _presenter.OnNewButtonClick();
        }

        #region IOrderListView members

        object IOrderListView.SelectedOrder
        {
            get { return _orderInfoCollectionBindingSource.Current; }
        }

        void IOrderListView.SetOrdersBindingSourceDataSource(object source)
        {
            _orderInfoCollectionBindingSource.DataSource = source;
        }

        #endregion

        #region IStartupView members

        void IStartupView.Run()
        {
            Application.Run(this);
        }

        #endregion

    }


}
