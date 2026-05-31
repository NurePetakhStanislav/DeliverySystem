using DeliverySystem.Forms;
using DeliverySystem.Repositories;

namespace DeliverySystem
{
    public partial class Form1 : Form
    {
        private AdminRepository admin = new AdminRepository();
        public Form1()
        {
            InitializeComponent();

            if (admin.AdminExists())
            {
                buttonAgree.Text = "Sign In";
            }
        }

        private void OpenOrders()
        {
            var order = new OrdersForm();
            order.Show();
            this.Hide();
        }

        private void buttonAgree_Click(object sender, EventArgs e)
        {
            string nickname = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            if (!admin.AdminExists())
            {
                admin.Register(nickname, password);
                OpenOrders();
                return;
            }

            if (admin.Login(nickname, password))
            {
                OpenOrders();
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
