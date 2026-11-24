using System.Text;
using EstructurasNoLineales.Modelos;

namespace EstructurasNoLineales.Pruebas;

/// <summary>Resultado de ejecutar la batería de pruebas.</summary>
public sealed class ReportePruebas
{
    public string Texto { get; init; } = string.Empty;
    public int Aprobadas { get; init; }
    public int Fallidas { get; init; }
}

/// <summary>
/// Batería de pruebas que demuestra la integridad del ABB y de sus recorridos.
/// Cada prueba compara un resultado esperado contra el obtenido y se anota en el reporte.
/// </summary>
public static class PruebasABB
{
    private static string L(IEnumerable<int> valores) => string.Join(", ", valores);

    /// <summary>Árbol base de las pruebas:  50 / (30: 20,40) / (70: 60,80).</summary>
    private static ArbolBinarioBusqueda CrearBase()
    {
        var arbol = new ArbolBinarioBusqueda();
        foreach (int v in new[] { 50, 30, 70, 20, 40, 60, 80 })
            arbol.Insertar(v);
        return arbol;
    }

    public static ReportePruebas Ejecutar()
    {
        var sb = new StringBuilder();
        int aprobadas = 0;
        int fallidas = 0;

        void Verificar(string nombre, string esperado, string obtenido)
        {
            bool pasa = esperado == obtenido;
            if (pasa) aprobadas++; else fallidas++;

            sb.AppendLine($"[{(pasa ? "OK   " : "FALLO")}] {nombre}");
            sb.AppendLine($"          esperado: {esperado}");
            sb.AppendLine($"          obtenido: {obtenido}");
        }

        sb.AppendLine("REPORTE DE PRUEBAS - ARBOL BINARIO DE BUSQUEDA (ABB)");
        sb.AppendLine($"Fecha de ejecucion: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine(new string('=', 60));
        sb.AppendLine("Arbol base: insercion de 50, 30, 70, 20, 40, 60, 80");
        sb.AppendLine();

        // ---------------------------------------------------------- Recorridos
        sb.AppendLine("--- 1. RECORRIDOS EN PROFUNDIDAD ---");
        var baseArbol = CrearBase();
        Verificar("Preorden (raiz, izq, der)", "50, 30, 20, 40, 70, 60, 80", L(baseArbol.Preorden()));
        Verificar("Inorden (izq, raiz, der) devuelve datos ordenados", "20, 30, 40, 50, 60, 70, 80", L(baseArbol.Inorden()));
        Verificar("Postorden (izq, der, raiz)", "20, 40, 30, 60, 80, 70, 50", L(baseArbol.Postorden()));
        Verificar("Preorden empieza en la raiz", "50", baseArbol.Preorden()[0].ToString());
        Verificar("Postorden termina en la raiz", "50", baseArbol.Postorden()[^1].ToString());
        Verificar("Cantidad de nodos y altura", "7 nodos, altura 3", $"{baseArbol.Cantidad} nodos, altura {baseArbol.Altura()}");
        sb.AppendLine();

        // ---------------------------------------------------------- Insercion
        sb.AppendLine("--- 2. INSERCION ---");
        var duplicados = CrearBase();
        Verificar("Insertar duplicado (40) es rechazado", "False", duplicados.Insertar(40).ToString());
        Verificar("Tras el duplicado la cantidad no cambia", "7", duplicados.Cantidad.ToString());
        Verificar("Insertar un valor nuevo (45) es aceptado", "True", duplicados.Insertar(45).ToString());
        Verificar("El arbol cumple la propiedad ABB", "True", duplicados.EsABBValido().ToString());
        sb.AppendLine();

        // ---------------------------------------------------------- Busqueda
        sb.AppendLine("--- 3. BUSQUEDA ---");
        var camino = new List<int>();
        var encontrado = baseArbol.Buscar(60, camino);
        Verificar("Buscar 60 (existe)", "True", (encontrado != null).ToString());
        Verificar("Camino recorrido hasta 60", "50, 70, 60", L(camino));
        Verificar("Buscar 99 (no existe)", "False", (baseArbol.Buscar(99) != null).ToString());
        sb.AppendLine();

        // ---------------------------------------------------------- Eliminacion
        sb.AppendLine("--- 4. ELIMINACION ---");

        var hoja = CrearBase();
        Verificar("Eliminar hoja (20)", "True", hoja.Eliminar(20).ToString());
        Verificar("Inorden tras eliminar la hoja", "30, 40, 50, 60, 70, 80", L(hoja.Inorden()));

        var unHijo = CrearBase();
        unHijo.Eliminar(20);            // ahora 30 solo tiene hijo derecho (40)
        Verificar("Eliminar nodo con un hijo (30)", "True", unHijo.Eliminar(30).ToString());
        Verificar("Inorden tras eliminar nodo con un hijo", "40, 50, 60, 70, 80", L(unHijo.Inorden()));
        Verificar("Preorden: 40 ocupa el lugar de 30", "50, 40, 70, 60, 80", L(unHijo.Preorden()));

        var dosHijos = CrearBase();
        Verificar("Eliminar raiz con dos hijos (50)", "True", dosHijos.Eliminar(50).ToString());
        Verificar("Inorden tras eliminar la raiz", "20, 30, 40, 60, 70, 80", L(dosHijos.Inorden()));
        Verificar("Nueva raiz = sucesor inorden", "60", dosHijos.Raiz!.Valor.ToString());
        Verificar("Propiedad ABB tras eliminar con dos hijos", "True", dosHijos.EsABBValido().ToString());

        var inexistente = CrearBase();
        Verificar("Eliminar valor inexistente (99)", "False", inexistente.Eliminar(99).ToString());
        Verificar("La cantidad no cambia", "7", inexistente.Cantidad.ToString());
        sb.AppendLine();

        // ---------------------------------------------------------- Casos limite
        sb.AppendLine("--- 5. CASOS LIMITE ---");
        var vacio = new ArbolBinarioBusqueda();
        Verificar("Arbol vacio: recorridos vacios", "0, 0, 0", $"{vacio.Preorden().Count}, {vacio.Inorden().Count}, {vacio.Postorden().Count}");
        Verificar("Arbol vacio: altura", "0", vacio.Altura().ToString());
        Verificar("Eliminar en arbol vacio", "False", vacio.Eliminar(1).ToString());

        var degenerado = new ArbolBinarioBusqueda();
        for (int i = 1; i <= 10; i++) degenerado.Insertar(i);
        Verificar("Insercion creciente 1..10 (arbol degenerado): altura", "10", degenerado.Altura().ToString());
        Verificar("Degenerado: inorden ordenado", "1, 2, 3, 4, 5, 6, 7, 8, 9, 10", L(degenerado.Inorden()));

        var unico = new ArbolBinarioBusqueda();
        unico.Insertar(5);
        unico.Eliminar(5);
        Verificar("Eliminar el unico nodo deja el arbol vacio", "0 nodos, raiz nula", $"{unico.Cantidad} nodos, raiz {(unico.Raiz == null ? "nula" : "no nula")}");
        sb.AppendLine();

        // ---------------------------------------------------------- Prueba masiva
        sb.AppendLine("--- 6. PRUEBA MASIVA (500 valores aleatorios, semilla fija 2026) ---");
        var azar = new Random(2026);
        var conjunto = new List<int>();
        var vistos = new HashSet<int>();
        while (conjunto.Count < 500)
        {
            int v = azar.Next(1, 10000);
            if (vistos.Add(v)) conjunto.Add(v);
        }

        var grande = new ArbolBinarioBusqueda();
        foreach (int v in conjunto) grande.Insertar(v);

        var ordenados = conjunto.OrderBy(x => x).ToList();
        Verificar("Cantidad de nodos", "500", grande.Cantidad.ToString());
        Verificar("Inorden == lista ordenada", "True", (L(grande.Inorden()) == L(ordenados)).ToString());
        Verificar("Preorden y postorden visitan los 500 nodos", "500, 500", $"{grande.Preorden().Count}, {grande.Postorden().Count}");
        Verificar("Propiedad ABB valida", "True", grande.EsABBValido().ToString());

        var aEliminar = conjunto.Where((_, indice) => indice % 2 == 0).ToList();
        foreach (int v in aEliminar) grande.Eliminar(v);

        var restantes = conjunto.Where((_, indice) => indice % 2 != 0).OrderBy(x => x).ToList();
        Verificar("Tras eliminar 250 valores: cantidad", "250", grande.Cantidad.ToString());
        Verificar("Tras eliminar: inorden == restantes ordenados", "True", (L(grande.Inorden()) == L(restantes)).ToString());
        Verificar("Tras eliminar: propiedad ABB valida", "True", grande.EsABBValido().ToString());
        sb.AppendLine();

        // ---------------------------------------------------------- Resumen
        sb.AppendLine(new string('=', 60));
        sb.AppendLine($"RESUMEN: {aprobadas} pruebas aprobadas, {fallidas} fallidas, {aprobadas + fallidas} en total.");
        sb.AppendLine(fallidas == 0
            ? "CONCLUSION: la estructura mantiene su integridad en todas las operaciones y recorridos."
            : "CONCLUSION: hay pruebas fallidas; revisar la implementacion.");

        return new ReportePruebas
        {
            Texto = sb.ToString(),
            Aprobadas = aprobadas,
            Fallidas = fallidas
        };
    }
}
