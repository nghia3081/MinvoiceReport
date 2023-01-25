using MinvoiceReport.IServices;
using MinvoiceReport.Models;
using MinvoiceReport.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
using System.Drawing;
using Report.Utils;

namespace MinvoiceReport.Forms
{
    public partial class DataFilter : Form
    {
        private readonly IReportService _reportService;
        public DataFilter(IReportService reportService)
        {
            InitializeComponent();
            _reportService = reportService;
            ReportInfo selectedReport = Constant.SelectedReport;
            int i = 0;
            var marginVertical = this.Height / selectedReport.ReportInfoDetail.Count / 2;
            foreach (var rpD in selectedReport.ReportInfoDetail)
            {
                Padding padding = new Padding();
                Label lbl = new Label() { Text = rpD.Caption };
                lbl.Location = new Point(100, marginVertical * i);
                this.Controls.Add(lbl);
                switch (rpD.DataType)
                {
                    case "text":
                        {
                            TextBox txtBox = new TextBox() { Name = rpD.Name, Width = this.Width / 3 };
                            txtBox.Location = GetLocation(txtBox.Width, marginVertical, i);
                            txtBox.Text = rpD.Name.ToLower().Equals("ma_dvcs") ? "VP" : string.Empty; 
                            this.Controls.Add(txtBox);
                            break;
                        }
                    case "datepicker":
                        {
                            DateTimePicker dateTimePicker = new DateTimePicker() { Name = rpD.Name, Width = this.Width / 3 };
                            dateTimePicker.Location = GetLocation(dateTimePicker.Width, marginVertical, i);
                            dateTimePicker.Format = DateTimePickerFormat.Short;
                            this.Controls.Add(dateTimePicker);
                            break;
                        }
                    case "combo":
                        {
                            ComboBox comboBox = new ComboBox() { Name = rpD.Name, Width = this.Width / 3 };
                            comboBox.Location = GetLocation(comboBox.Width, marginVertical, i);
                            comboBox.DisplayMember = "value";
                            comboBox.ValueMember = "id";
                            if (rpD.ReferenceDataId != null)
                            {
                                comboBox.DataSource = _reportService.GetReferencesData(rpD.ReferenceDataId.Value);

                            }
                            this.Controls.Add(comboBox);
                            break;
                        }
                    case "multiselect":
                        {
                            ListBox listBox = new ListBox() { Name = rpD.Name, Width = this.Width / 3 };
                            listBox.Location = GetLocation(listBox.Width, marginVertical, i);
                            listBox.DisplayMember = "value";
                            listBox.ValueMember = "id";
                            listBox.SelectionMode = SelectionMode.MultiSimple;
                            if (rpD.ReferenceDataId != null)
                            {
                                listBox.DataSource = _reportService.GetReferencesData(rpD.ReferenceDataId.Value);
                            }
                            marginVertical += 20;
                            this.Controls.Add(listBox);
                            break;
                        }
                }
                i++;
            }
            Button btnSubmit = new Button()
            {
                Name = "submitBtn",
                Text = "Nhận",
                Size = new Size(70, 50)
            };
            btnSubmit.Click += SubmitBtnOnclick;
            btnSubmit.Location = GetLocation(btnSubmit.Width, marginVertical, i);
            this.Controls.Add(btnSubmit);
        }
        private Point GetLocation(int thisWidth, int marginVertical, int rows)
        {
            return new Point((this.Width / 2) - thisWidth / 2, marginVertical * rows);
        }
        private void SubmitBtnOnclick(object sender, EventArgs e)
        {
            JObject dataSubmit = new JObject();
            ReportInfo selectedReport = Constant.SelectedReport;
            foreach (var rpD in selectedReport.ReportInfoDetail)
            {
                switch (rpD.DataType)
                {
                    case "text":
                        {
                            TextBox txtBox = this.Controls[rpD.Name] as TextBox;
                            if (txtBox != null) dataSubmit.Add(rpD.Name, txtBox.Text ?? null);
                            break;
                        }
                    case "datepicker":
                        {
                            DateTimePicker datePicker = this.Controls[rpD.Name] as DateTimePicker;
                            if (datePicker != null) dataSubmit.Add(rpD.Name, datePicker.Value.ToString("yyyy/MM/dd"));
                            break;
                        }
                    case "combo":
                        {
                            ComboBox comboBox = this.Controls[rpD.Name] as ComboBox;
                            if (comboBox != null) dataSubmit.Add(rpD.Name, comboBox.SelectedValue.ToString());
                            break;
                        }
                    case "multiselect":
                        {
                            var listBox = this.Controls[rpD.Name] as ListBox;
                            var selectedMulti = listBox.SelectedItems;
                            if (listBox == null) break;
                            string multiSelected = string.Empty;
                            foreach (ReferencesDataModel item in selectedMulti)
                            {
                                multiSelected = $"{multiSelected},{item.id}";
                            }
                            dataSubmit.Add(rpD.Name, multiSelected.Remove(0, 1));
                            break;
                        }
                }
            }
            var dataReport = _reportService.GetReportData(selectedReport.WindowId, dataSubmit);
            if (dataReport != null) Constant.REPORT_DATA = dataReport;
            this.Close();
            LoadingUtils.ShowProgress();
        }
    }
}
