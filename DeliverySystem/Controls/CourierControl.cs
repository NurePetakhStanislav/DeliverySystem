using DeliverySystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliverySystem.Controls
{
    public partial class CourierControl : UserControl
    {
        public CourierControl()
        {
            InitializeComponent();
        }

        public void SetData(Courier courier)
        {
            Courier.Text = courier.FullName;
            Status.Text = courier.Status;

            SetStatus(Status.Text);
        }

        public void SetStatus(string status)
        {
            Status.Text = status;

            if (status == "Busy")
                BackColor = Color.LightCoral;
            else
                BackColor = Color.LawnGreen;
        }
    }
}
