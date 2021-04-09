﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Entities {
    class OrderItem {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem() {
        }

        public OrderItem(int quantity, double price, Product product) {
            Quantity = quantity;
            Price = price;
            Product = product;
        }
        public double SubTotal() {
            return Price * Quantity;
        }

    }
}
