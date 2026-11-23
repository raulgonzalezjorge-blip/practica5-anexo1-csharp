using System.Globalization;
using System.Text;

internal static class Program
{
    private const int MaximoCaracteresResultado = 1_000_000;

    private static void Main()
    {
        var salir = false;

        while (!salir)
        {
            Console.WriteLine();
            Console.WriteLine("=== MENÚ DE STRINGS ===");
            Console.WriteLine("1. Comprobar si un string es palíndromo");
            Console.WriteLine("2. Mostrar un nombre en mayúsculas y minúsculas");
            Console.WriteLine("3. Contar las apariciones de una letra");
            Console.WriteLine("4. Repetir dos strings un número de veces");
            Console.WriteLine("5. Repetir cada carácter de un string");
            Console.WriteLine("6. Eliminar las apariciones de un string dentro de otro");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ComprobarPalindromo(LeerTexto("Introduce un string: "));
                    break;
                case "2":
                    MostrarMayusculasYMinusculas(LeerTextoNoVacio("Introduce un nombre: "));
                    break;
                case "3":
                    ContarLetra();
                    break;
                case "4":
                    RepetirDosStrings();
                    break;
                case "5":
                    RepetirCadaCaracter(LeerTexto("Introduce un string: "));
                    break;
                case "6":
                    EliminarApariciones();
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

    private static string LeerTexto(string mensaje)
    {
        Console.Write(mensaje);
        return Console.ReadLine() ?? string.Empty;
    }

    private static string LeerTextoNoVacio(string mensaje)
    {
        while (true)
        {
            var texto = LeerTexto(mensaje);
            if (!string.IsNullOrWhiteSpace(texto))
            {
                return texto;
            }

            Console.WriteLine("El texto no puede estar vacío.");
        }
    }

    private static void ComprobarPalindromo(string texto)
    {
        var caracteres = texto
            .Where(char.IsLetterOrDigit)
            .Select(char.ToUpperInvariant)
            .ToArray();

        var esPalindromo = true;
        for (var izquierda = 0; izquierda < caracteres.Length / 2; izquierda++)
        {
            if (caracteres[izquierda] != caracteres[caracteres.Length - 1 - izquierda])
            {
                esPalindromo = false;
                break;
            }
        }

        Console.WriteLine(esPalindromo
            ? "El string es un palíndromo."
            : "El string no es un palíndromo.");
    }

    private static void MostrarMayusculasYMinusculas(string nombre)
    {
        Console.WriteLine($"En mayúsculas: {nombre.ToUpper(CultureInfo.CurrentCulture)}");
        Console.WriteLine($"En minúsculas: {nombre.ToLower(CultureInfo.CurrentCulture)}");
    }

    private static void ContarLetra()
    {
        var texto = LeerTexto("Introduce un string: ");
        char letra;

        while (true)
        {
            var entrada = LeerTexto("Introduce una sola letra: ");
            if (entrada.Length == 1 && char.IsLetter(entrada[0]))
            {
                letra = entrada[0];
                break;
            }

            Console.WriteLine("Debes introducir una sola letra.");
        }

        var letraBuscada = char.ToUpper(letra, CultureInfo.CurrentCulture);
        var ocurrencias = texto.Count(caracter =>
            char.ToUpper(caracter, CultureInfo.CurrentCulture) == letraBuscada);

        Console.WriteLine($"La letra '{letra}' aparece {ocurrencias} veces.");
    }

    private static void RepetirDosStrings()
    {
        var primero = LeerTextoNoVacio("Introduce el primer string: ");
        string segundo;

        do
        {
            segundo = LeerTextoNoVacio("Introduce un segundo string distinto: ");
            if (string.Equals(primero, segundo, StringComparison.Ordinal))
            {
                Console.WriteLine("Los dos strings deben ser distintos.");
            }
        } while (string.Equals(primero, segundo, StringComparison.Ordinal));

        int repeticiones;
        do
        {
            repeticiones = LeerEntero("¿Cuántas veces quieres repetirlos? ");
            if (repeticiones < 0)
            {
                Console.WriteLine("El número de repeticiones no puede ser negativo.");
            }
        } while (repeticiones < 0);

        var unidad = $"{primero} {segundo}";
        var longitudResultado = (long)unidad.Length * repeticiones + Math.Max(0, repeticiones - 1);
        if (longitudResultado > MaximoCaracteresResultado)
        {
            Console.WriteLine($"El resultado supera el límite de {MaximoCaracteresResultado} caracteres.");
            return;
        }

        var resultado = new StringBuilder((int)longitudResultado);
        for (var i = 0; i < repeticiones; i++)
        {
            if (i > 0)
            {
                resultado.Append(' ');
            }

            resultado.Append(unidad);
        }

        Console.WriteLine(repeticiones == 0
            ? "Resultado: (vacío)"
            : $"Resultado: {resultado}");
    }

    private static int LeerEntero(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out var numero))
            {
                return numero;
            }

            Console.WriteLine("Entrada no válida. Introduce un número entero.");
        }
    }

    private static void RepetirCadaCaracter(string texto)
    {
        var resultado = new StringBuilder();
        var elementos = StringInfo.GetTextElementEnumerator(texto);

        while (elementos.MoveNext())
        {
            var elemento = elementos.GetTextElement();
            resultado.Append(elemento);
            resultado.Append(elemento);
        }

        Console.WriteLine($"Resultado: {resultado}");
    }

    private static void EliminarApariciones()
    {
        var texto = LeerTexto("Introduce el string original: ");
        var aparicion = LeerTextoNoVacio("Introduce el string que quieres eliminar: ");
        var resultado = texto.Replace(aparicion, string.Empty, StringComparison.OrdinalIgnoreCase).Trim();

        Console.WriteLine($"Resultado: {resultado}");
    }
}