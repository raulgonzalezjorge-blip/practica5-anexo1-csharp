using System.Globalization;

internal static class Program
{
    private static void Main()
    {
        var salir = false;

        while (!salir)
        {
            Console.WriteLine();
            Console.WriteLine("=== MENÚ DE DECIMALES ===");
            Console.WriteLine("1. Redondear un número al alza");
            Console.WriteLine("2. Eliminar los decimales de un número");
            Console.WriteLine("3. Resolver una ecuación de segundo grado");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    RedondearAlAlza();
                    break;
                case "2":
                    EliminarDecimales();
                    break;
                case "3":
                    ResolverEcuacion();
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

    private static double LeerNumero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            var entrada = Console.ReadLine();

            if (double.TryParse(entrada, NumberStyles.Float, CultureInfo.CurrentCulture, out var numero)
                || double.TryParse(entrada, NumberStyles.Float, CultureInfo.InvariantCulture, out numero)
                || double.TryParse(entrada?.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out numero))
            {
                if (!double.IsNaN(numero) && !double.IsInfinity(numero))
                {
                    return numero;
                }
            }

            Console.WriteLine("Entrada no válida. Introduce un número decimal finito.");
        }
    }

    private static void RedondearAlAlza()
    {
        var numero = LeerNumero("Introduce un número: ");
        Console.WriteLine($"Redondeado al alza: {Math.Ceiling(numero)}");
    }

    private static void EliminarDecimales()
    {
        var numero = LeerNumero("Introduce un número: ");
        Console.WriteLine($"Sin decimales: {Math.Truncate(numero)}");
    }

    private static void ResolverEcuacion()
    {
        Console.WriteLine("Ecuación: ax² + bx + c = 0");
        var a = LeerNumero("Introduce el coeficiente a: ");
        var b = LeerNumero("Introduce el coeficiente b: ");
        var c = LeerNumero("Introduce el coeficiente c: ");

        if (a == 0)
        {
            ResolverEcuacionLineal(b, c);
            return;
        }

        var discriminante = b * b - 4 * a * c;
        if (double.IsNaN(discriminante) || double.IsInfinity(discriminante))
        {
            Console.WriteLine("No se puede calcular la ecuación: los coeficientes son demasiado grandes.");
            return;
        }

        if (discriminante < 0)
        {
            Console.WriteLine("La ecuación no tiene soluciones reales.");
            return;
        }

        var raizDiscriminante = Math.Sqrt(discriminante);
        var denominador = 2 * a;
        var x1 = (-b + raizDiscriminante) / denominador;
        var x2 = (-b - raizDiscriminante) / denominador;

        if (double.IsInfinity(x1) || double.IsInfinity(x2) || double.IsNaN(x1) || double.IsNaN(x2))
        {
            Console.WriteLine("No se pueden representar las soluciones con estos coeficientes.");
        }
        else if (discriminante == 0)
        {
            Console.WriteLine($"La ecuación tiene una solución real: x = {x1}");
        }
        else
        {
            Console.WriteLine($"Soluciones reales: x1 = {x1}, x2 = {x2}");
        }
    }

    private static void ResolverEcuacionLineal(double b, double c)
    {
        if (b == 0)
        {
            Console.WriteLine(c == 0
                ? "La igualdad se cumple para cualquier valor de x."
                : "La ecuación no tiene solución.");
            return;
        }

        Console.WriteLine($"Como a = 0, la ecuación es lineal. Solución: x = {-c / b}");
    }
}