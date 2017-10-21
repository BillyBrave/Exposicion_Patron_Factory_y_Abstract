using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    
    // La interface 'Product' 
    
    public interface IFactory
    {
        void Manejar(int miles);
    }

    // La clase 'ConcreteProduct' 
    public class Patineta : IFactory
    {
        public void Manejar(int km)
        {
            Console.WriteLine("Manejar  : " + km.ToString() + "km");
        }
    }

    
    //Una clase 'ConcreteProduct' 
    
    public class Bicicleta : IFactory
    {
        public void Manejar(int km)
        {
            Console.WriteLine("Manejar la bicicleta : " + km.ToString() + "km");
        }
    }


    //La clase Abstract

    public abstract class VehiculoFactory
    {
        public abstract IFactory GetVehiculo(string Vehiculo);

    }


    // Una clase 'ConcreteCreator' 

    public class ConcreteVehiculoFactory : VehiculoFactory
    {
        public override IFactory GetVehiculo(string Vehiculo)
        {
            switch (Vehiculo)
            {
                case "Patineta":
                    return new Patineta();
                case "Bicicleta":
                    return new Bicicleta();
                default:
                    throw new ApplicationException(string.Format("Vehiculo '{0}' no se puede crear", Vehiculo));
            }
        }

    }


    // Demostracion de Patron Factory 

    class Program
    {
        static void Main(string[] args)
        {
            VehiculoFactory factory = new ConcreteVehiculoFactory();

            IFactory Patineta = factory.GetVehiculo("Patineta");
            Patineta.Manejar(10);

            IFactory Bicicleta = factory.GetVehiculo("Bicicleta");
            Bicicleta.Manejar(20);

            Console.ReadKey();

        }
    }
}
