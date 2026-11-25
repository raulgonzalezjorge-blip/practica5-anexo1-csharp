using System.Globalization;
using System.Numerics;

internal static class Program
{
    private static void Main()
    {
        var salir = false;

        while (!salir)
        {
            Console.WriteLine();
            Console.WriteLine("=== MENÚ DE NÚMEROS ===");
            Console.WriteLine("1. Comprobar si un número es primo");
            Console.WriteLine("2. Calcular el factorial");
            Console.WriteLine("3. Convertir segundos a horas, minutos y segundos");
            Console.WriteLine("4. Mostrar los primeros 15 números de Pell");
            Console.WriteLine("5. Comprobar si un número es de Armstrong");
            Console.WriteLine("6. Comprobar si todos los dígitos son diferentes");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ComprobarPrimo(LeerLong("Introduce un número entero: "));
                    break;
                case "2":
                    CalcularFactorial();
                    break;
                case "3":
                    ConvertirSegundos();
                    break;
                case "4":
                    MostrarSerieDePell();
                    break;
                case "5":
                    ComprobarArmstrong(LeerLong("Introduce un número entero no negativo: "));
                    break;
                case "6":
                    ComprobarDigitosDiferentes(LeerLong("Introduce un número entero: "));
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Programa finalizado.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    break;
            }
        }
    }

    private static long LeerLong(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (long.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var numero))
            {
                return numero;
            }

            Console.WriteLine("Entrada no válida. Introduce un número entero.");
        }
    }

    private static void ComprobarPrimo(long numero)
    {
        if (numero < 2)
        {
            Console.WriteLine($"{numero} no es un número primo.");
            return;
        }

        for (long divisor = 2; divisor <= numero / divisor; divisor++)
        {
            if (numero % divisor == 0)
            {
                Console.WriteLine($"{numero} no es un número primo.");
                return;
            }
        }

        Console.WriteLine($"{numero} es un número primo.");
    }

    private static void CalcularFactorial()
    {
        long numero;
        do
        {
            numero = LeerLong("Introduce un entero entre 0 y 1000: ");
            if (numero < 0 || numero > 1000)
            {
                Console.WriteLine("El factorial está disponible para valores entre 0 y 1000.");
            }
        } while (numero < 0 || numero > 1000);

        var factorial = BigInteger.One;
        for (var factor = 2; factor <= numero; factor++)
        {
            factorial *= factor;
        }

        Console.WriteLine($"{numero}! = {factorial}");
    }

    private static void ConvertirSegundos()
    {
        long segundosTotales;
        do
        {
            segundosTotales = LeerLong("Introduce una cantidad de segundos no negativa: ");
            if (segundosTotales < 0)
            {
                Console.WriteLine("La cantidad de segundos no puede ser negativa.");
            }
        } while (segundosTotales < 0);

        var horas = segundosTotales / 3600;
        var minutos = segundosTotales % 3600 / 60;
        var segundos = segundosTotales % 60;
        var textoHoras = horas == 1 ? "hora" : "horas";
        var textoMinutos = minutos == 1 ? "minuto" : "minutos";
        var textoSegundos = segundos == 1 ? "segundo" : "segundos";

        Console.WriteLine($"{segundosTotales} segundos son {horas} {textoHoras}, {minutos} {textoMinutos} y {segundos} {textoSegundos}.");
    }

    private static void MostrarSerieDePell()
    {
        BigInteger anterior = 0;
        BigInteger actual = 1;
        var terminos = new List<BigInteger> { anterior, actual };

        for (var i = 2; i < 15; i++)
        {
            var siguiente = 2 * actual + anterior;
            terminos.Add(siguiente);
            anterior = actual;
            actual = siguiente;
        }

        Console.WriteLine($"Primeros 15 números de Pell (P0-P14): {string.Join(", ", terminos)}");
    }

    private static void ComprobarArmstrong(long numero)
    {
        if (numero < 0)
        {
            Console.WriteLine("Los números negativos no se consideran números de Armstrong.");
            return;
        }

        var digitos = numero.ToString(CultureInfo.InvariantCulture);
        var cantidadDigitos = digitos.Length;
        BigInteger suma = 0;

        foreach (var digito in digitos)
        {
            suma += BigInteger.Pow(digito - '0', cantidadDigitos);
        }

        if (suma == numero)
        {
            Console.WriteLine($"{numero} es un número de Armstrong.");
        }
        else
        {
            Console.WriteLine($"{numero} no es un número de Armstrong.");
        }
    }

    private static void ComprobarDigitosDiferentes(long numero)
    {
        var digitos = BigInteger.Abs(new BigInteger(numero))
            .ToString(CultureInfo.InvariantCulture);
        var vistos = new HashSet<char>();

        foreach (var digito in digitos)
        {
            if (!vistos.Add(digito))
            {
                Console.WriteLine($"{numero} no tiene todos sus dígitos diferentes.");
                return;
            }
        }

        Console.WriteLine($"{numero} tiene todos sus dígitos diferentes.");
    }
}