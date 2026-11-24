using System.Globalization;

namespace EstructurasNoLineales.Modelos;

//Resultado del algoritmo de Dijkstra, incluyendo la traza paso a paso
public sealed class ResultadoDijkstra
{
    public bool Alcanzable { get; init; }
    public double Distancia { get; init; }
    public List<string> Camino { get; init; } = new();
    public List<string> Traza { get; init; } = new();
}

//Grafo ponderado representado con listas de adyacencia (estructura principal).
// También puede producir su matriz de adyacencia para visualizarla.
// Internamente todo es dirigido (arcos); una arista bidireccional son dos arcos.
public class Grafo
{
    private readonly List<string> _vertices = new();
    private readonly Dictionary<string, List<(string Destino, double Peso)>> _adyacencia = new();

    public IReadOnlyList<string> Vertices => _vertices;
    public int CantidadArcos => _adyacencia.Values.Sum(lista => lista.Count);

    public static string Formato(double valor) =>
        double.IsPositiveInfinity(valor) ? "∞" : valor.ToString("0.##", CultureInfo.InvariantCulture);

    // --- CONSTRUCCIÓN ---
    public bool AgregarVertice(string nombre)
    {
        nombre = nombre.Trim();
        if (nombre.Length == 0 || _adyacencia.ContainsKey(nombre))
            return false;

        _vertices.Add(nombre);
        _adyacencia[nombre] = new List<(string Destino, double Peso)>();
        return true;
    }

    // Agrega o actualiza una arista. Si es bidireccional crea el arco de ida y el de vuelta.
    // El peso debe ser positivo (requisito de Dijkstra).
    public bool AgregarArista(string origen, string destino, double peso, bool bidireccional)
    {
        if (!_adyacencia.ContainsKey(origen) || !_adyacencia.ContainsKey(destino))
            return false;
        if (origen == destino || peso <= 0)
            return false;

        EstablecerArco(origen, destino, peso);
        if (bidireccional)
            EstablecerArco(destino, origen, peso);
        return true;
    }

    private void EstablecerArco(string a, string b, double peso)
    {
        var lista = _adyacencia[a];
        int indice = lista.FindIndex(x => x.Destino == b);
        if (indice >= 0)
            lista[indice] = (b, peso);
        else
            lista.Add((b, peso));
    }

    public void Limpiar()
    {
        _vertices.Clear();
        _adyacencia.Clear();
    }

    // --- CONSULTAS ---
    public IReadOnlyList<(string Destino, double Peso)> Vecinos(string vertice) => _adyacencia[vertice];

    public bool TryObtenerPeso(string origen, string destino, out double peso)
    {
        peso = 0;
        if (!_adyacencia.TryGetValue(origen, out var lista))
            return false;

        foreach (var (d, p) in lista)
        {
            if (d == destino)
            {
                peso = p;
                return true;
            }
        }
        return false;
    }

    //Todos los arcos del grafo (origen, destino, peso)
    public IEnumerable<(string Origen, string Destino, double Peso)> Arcos()
    {
        foreach (string origen in _vertices)
            foreach (var (destino, peso) in _adyacencia[origen])
                yield return (origen, destino, peso);
    }

    //Matriz de adyacencia: 0 en la diagonal, ∞ si no hay arco, el peso si existe.
    public double[,] MatrizAdyacencia()
    {
        int n = _vertices.Count;
        var matriz = new double[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                matriz[i, j] = i == j ? 0 : double.PositiveInfinity;

        foreach (var (origen, destino, peso) in Arcos())
            matriz[_vertices.IndexOf(origen), _vertices.IndexOf(destino)] = peso;

        return matriz;
    }

    // --- RECORRIDOS ---
    //Recorrido en anchura (BFS) usando una cola
    public List<string> RecorridoAnchura(string inicio)
    {
        var resultado = new List<string>();
        if (!_adyacencia.ContainsKey(inicio))
            return resultado;

        var visitados = new HashSet<string> { inicio };
        var cola = new Queue<string>();
        cola.Enqueue(inicio);

        while (cola.Count > 0)
        {
            string actual = cola.Dequeue();
            resultado.Add(actual);

            foreach (var (destino, _) in _adyacencia[actual])
                if (visitados.Add(destino))
                    cola.Enqueue(destino);
        }
        return resultado;
    }

    //Recorrido en profundidad (DFS) recursivo
    public List<string> RecorridoProfundidad(string inicio)
    {
        var resultado = new List<string>();
        if (!_adyacencia.ContainsKey(inicio))
            return resultado;

        DfsRec(inicio, new HashSet<string>(), resultado);
        return resultado;
    }

    private void DfsRec(string actual, HashSet<string> visitados, List<string> salida)
    {
        visitados.Add(actual);
        salida.Add(actual);

        foreach (var (destino, _) in _adyacencia[actual])
            if (!visitados.Contains(destino))
                DfsRec(destino, visitados, salida);
    }

    // --- DIJKSTRA
    // Camino más corto de origen a destino (pesos positivos). Implementación O(V²) con arreglos para que la traza de ejecución sea clara y fácil de explicar.
    public ResultadoDijkstra Dijkstra(string origen, string destino)
    {
        var traza = new List<string>();
        int n = _vertices.Count;
        int s = _vertices.IndexOf(origen);
        int t = _vertices.IndexOf(destino);

        if (s < 0 || t < 0)
        {
            traza.Add("Origen o destino inválido.");
            return new ResultadoDijkstra { Alcanzable = false, Distancia = double.PositiveInfinity, Traza = traza };
        }

        var dist = new double[n];
        var previo = new int[n];
        var fijo = new bool[n];
        Array.Fill(dist, double.PositiveInfinity);
        Array.Fill(previo, -1);
        dist[s] = 0;

        traza.Add($"INICIO: dist[{origen}] = 0 y la distancia de los demás vértices = ∞");

        int paso = 1;
        for (int k = 0; k < n; k++)
        {
            // 1) Elegir el vértice no fijado con menor distancia
            int u = -1;
            double mejor = double.PositiveInfinity;
            for (int i = 0; i < n; i++)
            {
                if (!fijo[i] && dist[i] < mejor)
                {
                    mejor = dist[i];
                    u = i;
                }
            }
            if (u == -1)
                break;

            fijo[u] = true;
            traza.Add($"PASO {paso++}: se fija {_vertices[u]} con distancia mínima {Formato(dist[u])}");

            if (u == t)
            {
                traza.Add($"   Se alcanzó el destino {destino}; el algoritmo termina.");
                break;
            }

            // 2) Relajar los arcos que salen de u
            foreach (var (nombreVecino, peso) in _adyacencia[_vertices[u]])
            {
                int v = _vertices.IndexOf(nombreVecino);
                if (fijo[v])
                    continue;

                double nueva = dist[u] + peso;
                string operacion = $"{Formato(dist[u])} + {Formato(peso)} = {Formato(nueva)}";

                if (nueva < dist[v])
                {
                    traza.Add($"   Arco {_vertices[u]}→{nombreVecino}: {operacion} < {Formato(dist[v])}  → se actualiza (anterior = {_vertices[u]})");
                    dist[v] = nueva;
                    previo[v] = u;
                }
                else
                {
                    traza.Add($"   Arco {_vertices[u]}→{nombreVecino}: {operacion} ≥ {Formato(dist[v])}  → sin cambio");
                }
            }
        }

        // 3) Reconstruir el camino siguiendo los "previos" desde el destino
        var camino = new List<string>();
        bool alcanzable = !double.IsPositiveInfinity(dist[t]);

        if (alcanzable)
        {
            for (int v = t; v != -1; v = previo[v])
                camino.Insert(0, _vertices[v]);

            traza.Add(string.Empty);
            traza.Add("CAMINO MÁS CORTO: " + string.Join(" → ", camino));
            traza.Add("DISTANCIA TOTAL: " + Formato(dist[t]));
        }
        else
        {
            traza.Add(string.Empty);
            traza.Add($"No existe un camino de {origen} a {destino}.");
        }

        return new ResultadoDijkstra
        {
            Alcanzable = alcanzable,
            Distancia = dist[t],
            Camino = camino,
            Traza = traza
        };
    }
}
