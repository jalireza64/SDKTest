using SdkTest.Helper;
using SdkTest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SdkTest
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        List<SepidModel> sepidItems = new List<SepidModel>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnKavehOpen_Click(object sender, EventArgs e)
        {
            try
            {
                KavehHelper.openBox(txtKavehPort.Text, Convert.ToInt32(txtKavehRouterAddress.Value), Convert.ToInt32(txtKavehEndUserAddress.Value), Convert.ToInt32(txtkavehRelayNumber.Value), Convert.ToInt32(txtKavehTimeOn.Value));

            }
            catch (Exception ex)
            {
                lblKavehMessage.Text = ex.Message;
            }
        }

        private void btnKavehClose_Click(object sender, EventArgs e)
        {
            try
            {
                KavehHelper.closeBox(txtKavehPort.Text, Convert.ToInt32(txtKavehRouterAddress.Value), Convert.ToInt32(txtKavehEndUserAddress.Value), Convert.ToInt32(txtkavehRelayNumber.Value));

            }
            catch (Exception ex)
            {
                lblKavehMessage.Text = ex.Message;
            }
        }

        private async void btnSepidOpen_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SepidModel item in sepidItems)
                {

                    SepidHelper.OpenBox(item.Ip, item.Port, item.PinNumber);
                    await Task.Delay(2000);
                }
            }
            catch (Exception ex)
            {
                lblSepidMessage.Text = ex.Message;
            }
        }

        private void btnSepidAddToList_Click(object sender, EventArgs e)
        {
            var item = new SepidModel
            {
                Ip = txtSepidIP.Text,
                Port = Convert.ToInt32(txtSepidPort.Value),
                PinNumber = txtSepidPin.Value.ToString()
            };
            sepidItems.Add(item);

            var bindingList = new BindingList<SepidModel>(sepidItems);
            var source = new BindingSource(bindingList, null);
            grdSepid.DataSource = source;
        }

        private void btnKavehFakeOpen_Click(object sender, EventArgs e)
        {
            try
            {
                KavehFakeHelper.openBox(txtKavehFakePort.Text, Convert.ToInt32(txtKavehFakeRouterAddress.Value), Convert.ToInt32(txtKavehFakeEndUserAddress.Value), Convert.ToInt32(txtkavehFakeRelayNumber.Value), Convert.ToInt32(txtKavehFakeTimeOn.Value));

            }
            catch (Exception ex)
            {
                lblKavehFakeMessage.Text = ex.Message;
            }
        }
    }
}
