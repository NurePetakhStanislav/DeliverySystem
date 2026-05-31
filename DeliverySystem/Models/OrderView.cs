using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.Models
{
    internal class OrderView
    {
        [DisplayName("Номер замовлення")]
        public int OrderNumber { get; set; }

        [DisplayName("Товари")]
        public string Products { get; set; }

        [DisplayName("Спосіб оплати")]
        public string PaymentMethod { get; set; }

        [DisplayName("Адреса замовлення")]
        public string OrderAddress { get; set; }

        [DisplayName("Адреса замовника")]
        public string ClientAddress { get; set; }

        [DisplayName("Ім'я кур'єра")]
        public int? CourierId { get; set; }

        [DisplayName("Статус замовлення")]
        public string Status { get; set; }

        [DisplayName("Загальна вартість")]
        public decimal TotalPrice { get; set; }

        [DisplayName("Час виконання")]
        public string DeliveryTime { get; set; }
    }
}
