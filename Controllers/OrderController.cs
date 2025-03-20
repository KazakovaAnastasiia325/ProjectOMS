using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Controllers
{
    public class OrderController : Controller
    {
        private static List<Order> _orders = new();

        public IActionResult Index()
        {
            return View(_orders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            order.Id = _orders.Count + 1;
            _orders.Add(order);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder == null) return NotFound();
            existingOrder.CustomerName = order.CustomerName;
            existingOrder.Product = order.Product;
            existingOrder.Status = order.Status;
            return RedirectToAction("Index");
        }
    }
}