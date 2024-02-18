using Products.Domain.Enums;

namespace Products.Domain.Test.DataBuilder
{
    public class ProductBuilder
    {
        private string _name = "Default Product Name";
        private string _description = "Default Product Description";
        private Status _status = Status.Active;
        private int _stock = 10;
        private decimal _price = 100.00m;

        public ProductBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public ProductBuilder WithStatus(Status status)
        {
            _status = status;
            return this;
        }

        public ProductBuilder WithStock(int stock)
        {
            _stock = stock;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            _price = price;
            return this;
        }

        public Entities.Product Build()
        {
            return new Entities.Product(_name, _description, _status, _stock, _price);
        }

    }
}

