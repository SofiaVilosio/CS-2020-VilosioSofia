using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace TP0_CS_Vilosio_Sofia
{
    class Program
    {
        public static List<PersonaYNumero> personasYNumeros = new List<PersonaYNumero>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("¿Que desea hacer?: \n 1- Registrar persona y numero \n 2- salir \n");
                var decision = Console.ReadLine();
                while (decision != "1" && decision != "2")
                {
                    Console.WriteLine("¿Que desea hacer ?: \n 1 - Registrar persona y numero \n 2 - salir \n");
                    decision = System.Console.ReadLine();
                }
                if (decision == "1")
                {
                    int numero = 0;
                    bool esValido = false;
                    Console.WriteLine("Ingrese su nombre y apellido");
                    string nombre = Console.ReadLine();
                    while (!esValido)
                    {
                        Console.WriteLine("Ingrese el número que desea (entre 0 y 999)");
                        var numeroElegido = Console.ReadLine();
                        esValido = int.TryParse(numeroElegido, out numero);
                        if (esValido)
                        {
                            if (numero >= 0 && numero <= 999)
                            {
                                esValido = true;
                                if (personasYNumeros.Any(x => x.Numero == numero))
                                {
                                    var persona = personasYNumeros.First(x => x.Numero == numero);
                                    Console.WriteLine($"El numero {persona.Numero} ha sido asignado a {persona.NombreYApellido}");
                                    esValido = false;
                                }
                            }
                            else
                            {
                                esValido = false;
                            }
                        }
                    }
                    PersonaYNumero Persona = new PersonaYNumero(nombre, numero);
                    personasYNumeros.Add(Persona);

                }

                if (decision == "2")
                {
                    break;
                }

            }
        }

    }

    public class PersonaYNumero
    {
        public string NombreYApellido { get; set; }
        public int Numero { get; set; }

        public PersonaYNumero(string nombreYApellido, int numero)
        {
            NombreYApellido = nombreYApellido;
            Numero = numero;
        }

    }
}
