using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{

    // La interface 'AbstractFactory' 

    interface VehiculoFactory
    {
        Bicicleta GetBicicleta(string Bicicleta);
        Patineta GetPatineta(string Patineta);
    }


    // La clase 'ConcreteFactory1' 

    class HondaFactory : VehiculoFactory
    {
        public Bicicleta GetBicicleta(string Bicicleta)
        {
            switch (Bicicleta)
            {
                case "Deportivo":
                    return new BicicletaDeportiva();
                case "Regular":
                    return new BicicletaComun();
                default:
                    throw new ApplicationException(string.Format("Vehiculo '{0}' no puede ser creado", Bicicleta));
            }

        }

        public Patineta GetPatineta(string Patineta)
        {
            switch (Patineta)
            {
                case "Deportivo":
                    return new Scooty();
                case "Regular":
                    return new RegularPatineta();
                default:
                    throw new ApplicationException(string.Format("Vehiculo '{0}' no puede ser creado", Patineta));
            }

        }
    }


    /// The 'ConcreteFactory2' class.

    class HeroFactory : VehiculoFactory
    {
        public Bicicleta GetBicicleta(string Bicicleta)
        {
            switch (Bicicleta)
            {
                case "Deportivo":
                    return new BicicletaDeportiva();
                case "Regular":
                    return new BicicletaComun();
                default:
                    throw new ApplicationException(string.Format("Vehiculo '{0}' no puede ser creado", Bicicleta));
            }

        }

        public Patineta GetPatineta(string Patineta)
        {
            switch (Patineta)
            {
                case "Deportivo":
                    return new Scooty();
                case "Regular":
                    return new RegularPatineta();
                default:
                    throw new ApplicationException(string.Format("Vehiculo '{0}' no puede ser creado", Patineta));
            }

        }
    }


    /// The 'AbstractProductA' interface

    interface Bicicleta
    {
        string Nombre();
    }


    /// The 'AbstractProductB' interface

    interface Patineta
    {
        string Nombre();
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class BicicletaComun : Bicicleta
    {
        public string Nombre()
        {
            return "Bicicleta Comun- Nombre";
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class BicicletaDeportiva : Bicicleta
    {
        public string Nombre()
        {
            return "Bicicleta Deportiva- Nombre";
        }
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class RegularPatineta : Patineta
    {
        public string Nombre()
        {
            return "Regular Patineta- Nombre";
        }
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Scooty : Patineta
    {
        public string Nombre()
        {
            return "Scooty- Nombre";
        }
    }

    /// <summary>
    /// The 'Client' class 
    /// </summary>
    class VehiculoClient
    {
        Bicicleta bici;
        Patineta scooter;

        public VehiculoClient(VehiculoFactory factory, string tipo)
        {
            bici = factory.GetBicicleta(tipo);
            scooter = factory.GetPatineta(tipo);
        }

        public string GetBicicletaNombre()
        {
            return bici.Nombre();
        }

        public string GetPatinetaNombre()
        {
            return scooter.Nombre();
        }

    }


    /// Demostracion Patron Abstract Factory 

    class Program
    {
        static void Main(string[] args)
        {
            VehiculoFactory honda = new HondaFactory();
            VehiculoClient hondaclient = new VehiculoClient(honda, "Regular");

            Console.WriteLine("******* Honda **********");
            Console.WriteLine(hondaclient.GetBicicletaNombre());
            Console.WriteLine(hondaclient.GetPatinetaNombre());

            hondaclient = new VehiculoClient(honda, "Deportivo");
            Console.WriteLine(hondaclient.GetBicicletaNombre());
            Console.WriteLine(hondaclient.GetPatinetaNombre());

            VehiculoFactory hero = new HeroFactory();
            VehiculoClient heroclient = new VehiculoClient(hero, "Regular");

            Console.WriteLine("******* Hero **********");
            Console.WriteLine(heroclient.GetBicicletaNombre());
            Console.WriteLine(heroclient.GetPatinetaNombre());

            heroclient = new VehiculoClient(hero, "Deportivo");
            Console.WriteLine(heroclient.GetBicicletaNombre());
            Console.WriteLine(heroclient.GetPatinetaNombre());

            Console.ReadKey();
        }
    }
}
