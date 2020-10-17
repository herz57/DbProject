using DbProject.Data;
using DbProject.Data.Domain;
using DbProject.Data.Repository;
using System;

namespace DbProject.Data.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;

        private EfRepository<Category> _categoryRepository;
        private EfRepository<Customer> _customerRepository;
        private EfRepository<DeliveryDetail> _deliveryDetailRepository;
        private EfRepository<Invoice> _invoiceRepository;
        private EfRepository<Order> _orderRepository;
        private EfRepository<OrderItem> _orderItemRepository;
        private EfRepository<OrderStatus> _orderStatusRepository;
        private EfRepository<Product> _productRepository;
        private EfRepository<User> _userRepository;

        private bool disposed;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public EfRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new EfRepository<Category>(_context);
                return _categoryRepository;
            }
        }

        public EfRepository<Customer> CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new EfRepository<Customer>(_context);
                return _customerRepository;
            }
        }

        public EfRepository<DeliveryDetail> DeliveryDetailRepository
        {
            get
            {
                if (_deliveryDetailRepository == null)
                    _deliveryDetailRepository = new EfRepository<DeliveryDetail>(_context);
                return _deliveryDetailRepository;
            }
        }

        public EfRepository<Invoice> InvoiceRepository
        {
            get
            {
                if (_invoiceRepository == null)
                    _invoiceRepository = new EfRepository<Invoice>(_context);
                return _invoiceRepository;
            }
        }

        public EfRepository<Order> OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new EfRepository<Order>(_context);
                return _orderRepository;
            }
        }

        public EfRepository<OrderItem> OrderItemRepository
        {
            get
            {
                if (_orderItemRepository == null)
                    _orderItemRepository = new EfRepository<OrderItem>(_context);
                return _orderItemRepository;
            }
        }

        public EfRepository<OrderStatus> OrderStatusRepository
        {
            get
            {
                if (_orderStatusRepository == null)
                    _orderStatusRepository = new EfRepository<OrderStatus>(_context);
                return _orderStatusRepository;
            }
        }

        public EfRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new EfRepository<Product>(_context);
                return _productRepository;
            }
        }

        public EfRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new EfRepository<User>(_context);
                return _userRepository;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
    }
}