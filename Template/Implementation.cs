namespace Template
{
    public abstract class VehicleTemplate
    {
        public void BuildVehicle()
        {
            CollectComponents();
            AssembleComponents();
            InstallGeerBox();
            StartVehicle();
            Console.WriteLine("Vehicle is on");
        }

        private void StartVehicle()
        {
            Console.WriteLine("Engine is powring on");
        }

        protected abstract void InstallGeerBox();
        protected abstract void AssembleComponents();

        protected void CollectComponents()
        {
            Console.WriteLine("Bring reer and front lights, tires, chairs");
        }
    }

    class Car : VehicleTemplate
    {
        protected override void AssembleComponents()
        {
            Console.WriteLine("Adding merror, windows and joins the parts in the Car body");
        }

        protected override void InstallGeerBox()
        {
            Console.WriteLine("Installing 4 shifts geer box");
        }
    }

    class Truck : VehicleTemplate
    {
        protected override void AssembleComponents()
        {
            Console.WriteLine("Adding merror, windows, extra truck container and joins the parts in the Truck body");
        }

        protected override void InstallGeerBox()
        {
            Console.WriteLine("Installing 6 shifts geer box");
        }

    }
}
