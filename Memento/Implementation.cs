namespace Memento
{
    // Originator
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public OrderMemento SaveStateToMemento()
        {
            return new OrderMemento(Id, Name);
        }

        public void RestoreStateFromMemento(OrderMemento memento)
        {
            Id = memento.Id;
            Name = memento.Name;
        }
    }

    // Memeneto
    public class OrderMemento
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public OrderMemento(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }


    public class CareTaker
    {
        private readonly List<OrderMemento> _mementos = new List<OrderMemento>();

        public int AddMemento(OrderMemento memento)
        {
            _mementos.Add(memento);
            return _mementos.Count - 1;
        }

        public OrderMemento GetOrderMemento(int index)
        {
            return _mementos[index];
        }
    }
}
