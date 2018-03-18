using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStore.View
{
    /// <summary>
    /// Interaction logic for InventoryReport.xaml
    /// </summary>
    public partial class InventoryReport : UserControl
    {
        public InventoryReport()
        {
            InitializeComponent();
        }
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //kiểm tra dữ liệu
            if (!dtNgayThang.SelectedDate.HasValue)
            {
                return;
            }
            //Tạo report
            Model.QuanLySachDataSet ds = new Model.QuanLySachDataSet();
            _reportViewer.LocalReport.ReportEmbeddedResource = "BookStore.View.InventoryReport.rdlc";
            Microsoft.Reporting.WinForms.ReportDataSource rdSource =
                        new Microsoft.Reporting.WinForms.ReportDataSource();
            rdSource.Name = "DataSet1";
            rdSource.Value = ds.InventoryReport;
            _reportViewer.LocalReport.DataSources.Add(rdSource);
            Model.QuanLySachDataSetTableAdapters.InventoryReportTableAdapter datasetAdapter =
                       new Model.QuanLySachDataSetTableAdapters.InventoryReportTableAdapter();
            datasetAdapter.ClearBeforeFill = true;
            datasetAdapter.Fill(ds.InventoryReport);
            _reportViewer.RefreshReport();
            //set Parameter
            ReportParameter[] lstPara = new ReportParameter[2];
            lstPara[0] = new ReportParameter("Month");
            lstPara[0].Values.Add(dtNgayThang.DisplayDate.Month.ToString());
            lstPara[1] = new ReportParameter("Year");
            lstPara[1].Values.Add(dtNgayThang.DisplayDate.Year.ToString());
            _reportViewer.LocalReport.SetParameters(lstPara);
            _reportViewer.RefreshReport();
            //hiển thị
            _reportViewer.LocalReport.DisplayName = "tonkho";
        }
    }
}
