using DeliverySystem.Constants;
using DeliverySystem.Controls;
using DeliverySystem.Models;
using DeliverySystem.Repositories;
using DeliverySystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliverySystem.Forms
{
    public partial class OrdersForm : Form
    {
        private List<Courier> couriers;
        private List<Street> streets;
        private List<Order> orders;
        private List<Product> products;
        private List<Item> items;
        private List<Road> roads;

        private List<OrderView> ordersView;
        public OrdersForm()
        {
            InitializeComponent();

            var baseRep = new BaseRepository();
            if (!baseRep.TestConnection())
            {
                MessageBox.Show("Немає з'єднання з БД");
                this.Close();
            }

            LoadData();

            FillAllCouriers();
            FillAllOrders();

            label1.Text = string.Empty;
        }

        private void OrdersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void LoadData()
        {
            LoadStreets();
            LoadRoads();
            LoadCouriers();
            LoadProducts();
            LoadItems();
            LoadOrder();
            GetAllOrderView();
        }

        private void LoadCouriers()
        {
            var courierRepo = new CourierRepository();
            couriers = courierRepo.GetAllCouriers();
        }

        private void FillAllCouriers()
        {
            foreach (var courier in couriers)
            {
                if (courier.Id < 0) continue;

                var card = new CourierControl();
                card.Tag = courier.Id;
                card.SetData(courier);
                flowLayoutPanel.Controls.Add(card);
            }
        }

        private void LoadStreets()
        {
            var streetRepo = new StreetRepository();
            streets = streetRepo.GetAllStreets();
        }

        private void LoadRoads()
        {
            var roadRepo = new RoadRepository();
            roads = roadRepo.GetAllRoads();
        }

        private void LoadProducts()
        {
            var productRepo = new ProductRepository();
            products = productRepo.GetAllProducts();
        }

        private void LoadItems()
        {
            var itemRepo = new ItemRepository();
            items = itemRepo.GetAllItems();
        }

        private void LoadOrder()
        {
            OrderRepository repository = new OrderRepository();
            orders = repository.GetAllOrders();
        }

        private void GetAllOrderView()
        {
            var courierDict = couriers.ToDictionary(c => c.Id);
            var productDict = products.ToDictionary(p => p.Id, p => p.Name);

            var roadServ = new RoadService(roads);

            ordersView = orders.Select(o =>
            {
                var orderItems = items.Where(i => i.OrderId == o.Id).ToList();
                var orderProducts = string.Join(", ", orderItems
                    .Select(i => $"{productDict[i.ProductId]} x{i.Quantity}"));

                string deliveryTime = "";

                if (o.CourierId != null)
                {
                    int courierId = o.CourierId.Value;

                    var travelOrder = roadServ.GetDistanceByStreets(o.FromStreetId, o.ToStreetId);
                    var travelCourier = roadServ.GetDistanceByStreets(courierId, o.FromStreetId);

                    if (travelOrder == null || travelCourier == null)
                    {
                        throw new Exception(
                            $"[ROUTING ERROR] No path found between streets: {courierId} -> {o.FromStreetId} -> {o.ToStreetId}"
                        );
                    }

                    int totalSeconds = travelOrder.Seconds + travelCourier.Seconds;

                    int minutes = totalSeconds / 60;
                    int seconds = totalSeconds % 60;

                    deliveryTime = $"{minutes} хв {seconds} сек";
                }

                decimal productPrice = 0;

                if (o.ProductPrice == 0)
                {
                    productPrice = orderItems.Sum(i =>
                    {
                        var product = products.First(p => p.Id == i.ProductId);
                        return product.Price * i.Quantity;
                    });
                }

                return new OrderView
                {
                    OrderNumber = o.Id,
                    Products = orderProducts,
                    PaymentMethod = o.PaymentMethod,
                    OrderAddress = streets.FirstOrDefault(s => s.Id == o.FromStreetId)?.Name,
                    ClientAddress = streets.FirstOrDefault(s => s.Id == o.ToStreetId)?.Name,
                    CourierId = o.CourierId,
                    Status = o.OrderStatus,
                    TotalPrice = productPrice + o.DeliveryFee + o.RewardFee,
                    DeliveryTime = o.DeliveredAt == null
                        ? "-"
                        : deliveryTime
                };
            }).ToList();
        }

        private void FillAllOrders()
        {
            dgvNewOrders.DataSource = ordersView.Where(o => o.Status != OrderStatus.Completed).ToList();

            var courierColumn = new DataGridViewComboBoxColumn
            {
                HeaderText = "Кур'єр",
                DataPropertyName = "CourierId",
                DataSource = couriers,
                ValueMember = "Id",
                DisplayMember = "FullName"
            };

            int index = dgvNewOrders.Columns["CourierId"].Index;
            dgvNewOrders.Columns.Remove("CourierId");
            dgvNewOrders.Columns.Insert(index, courierColumn);

            dgvOrderHistory.DataSource = ordersView.Where(o => o.Status == OrderStatus.Completed).ToList();
        }
    }
}
