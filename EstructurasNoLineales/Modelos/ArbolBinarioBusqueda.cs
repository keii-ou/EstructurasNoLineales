namespace EstructurasNoLineales.Modelos;


//Árbol Binario de Búsqueda (ABB) implementado con nodos enlazados en memoria dinámica.
//Regla: para todo nodo, los valores del subárbol izquierdo son menores y los del subárbol derecho son mayores 
//No se permiten valores duplicados.

public class ArbolBinarioBusqueda
{
    public NodoABB? Raiz { get; private set; }
    public int Cantidad { get; private set; }

    // --- INSERCIÓN ---
    //Inserta un valor. Devuelve false si es duplicado
    public bool Insertar(int valor)
    {
        if (Raiz == null)
        {
            Raiz = new NodoABB(valor);
            Cantidad++;
            return true;
        }

        NodoABB actual = Raiz;
        while (true)
        {
            if (valor == actual.Valor)
                return false;

            if (valor < actual.Valor)
            {
                if (actual.Izquierdo == null)
                {
                    actual.Izquierdo = new NodoABB(valor);
                    Cantidad++;
                    return true;
                }
                actual = actual.Izquierdo;
            }
            else
            {
                if (actual.Derecho == null)
                {
                    actual.Derecho = new NodoABB(valor);
                    Cantidad++;
                    return true;
                }
                actual = actual.Derecho;
            }
        }
    }

    // --- BÚSQUEDA ---
   
    //Busca un valor. Si se pasa una lista, se llena con el camino recorrido desde la raíz.
    public NodoABB? Buscar(int valor, List<int>? camino = null)
    {
        NodoABB? actual = Raiz;
        while (actual != null)
        {
            camino?.Add(actual.Valor);

            if (valor == actual.Valor)
                return actual;

            actual = valor < actual.Valor ? actual.Izquierdo : actual.Derecho;
        }
        return null;
    }

    // --- ELIMINACIÓN ---
    //Elimina un valor. Casos: hoja, un hijo, dos hijos (se reemplaza por el sucesor inorden). Devuelve false si el valor no existe.

    public bool Eliminar(int valor)
    {
        bool eliminado = false;
        Raiz = EliminarRec(Raiz, valor, ref eliminado);
        if (eliminado)
            Cantidad--;
        return eliminado;
    }

    private static NodoABB? EliminarRec(NodoABB? nodo, int valor, ref bool eliminado)
    {
        if (nodo == null)
            return null;

        if (valor < nodo.Valor)
        {
            nodo.Izquierdo = EliminarRec(nodo.Izquierdo, valor, ref eliminado);
        }
        else if (valor > nodo.Valor)
        {
            nodo.Derecho = EliminarRec(nodo.Derecho, valor, ref eliminado);
        }
        else
        {
            eliminado = true;

            // Caso 1 y 2: hoja o un solo hijo
            if (nodo.Izquierdo == null) return nodo.Derecho;
            if (nodo.Derecho == null) return nodo.Izquierdo;

            // Caso 3: dos hijos -> sucesor inorden (mínimo del subárbol derecho)
            NodoABB sucesor = nodo.Derecho;
            while (sucesor.Izquierdo != null)
                sucesor = sucesor.Izquierdo;

            nodo.Valor = sucesor.Valor;
            bool auxiliar = false;
            nodo.Derecho = EliminarRec(nodo.Derecho, sucesor.Valor, ref auxiliar);
        }
        return nodo;
    }

    // --- RECORRIDOS EN PROFUNDIDAD ---
    //Preorden (raíz, izquierdo, derecho)
    public List<int> Preorden()
    {
        var resultado = new List<int>();
        PreordenRec(Raiz, resultado);
        return resultado;
    }

    private static void PreordenRec(NodoABB? nodo, List<int> salida)
    {
        if (nodo == null) return;
        salida.Add(nodo.Valor);
        PreordenRec(nodo.Izquierdo, salida);
        PreordenRec(nodo.Derecho, salida);
    }

    //Inorden (izquierdo, raíz, derecho)
    public List<int> Inorden()
    {
        var resultado = new List<int>();
        InordenRec(Raiz, resultado);
        return resultado;
    }

    private static void InordenRec(NodoABB? nodo, List<int> salida)
    {
        if (nodo == null) return;
        InordenRec(nodo.Izquierdo, salida);
        salida.Add(nodo.Valor);
        InordenRec(nodo.Derecho, salida);
    }

    //Postorden (izquierdo, derecho, raíz).
    public List<int> Postorden()
    {
        var resultado = new List<int>();
        PostordenRec(Raiz, resultado);
        return resultado;
    }

    private static void PostordenRec(NodoABB? nodo, List<int> salida)
    {
        if (nodo == null) return;
        PostordenRec(nodo.Izquierdo, salida);
        PostordenRec(nodo.Derecho, salida);
        salida.Add(nodo.Valor);
    }

    // --- UTILIDADES ---
    //Altura medida en niveles: árbol vacío = 0, solo raíz = 1.
    public int Altura() => AlturaRec(Raiz);

    private static int AlturaRec(NodoABB? nodo)
    {
        if (nodo == null) return 0;
        return 1 + Math.Max(AlturaRec(nodo.Izquierdo), AlturaRec(nodo.Derecho));
    }

    public int? Minimo()
    {
        if (Raiz == null) return null;
        NodoABB actual = Raiz;
        while (actual.Izquierdo != null) actual = actual.Izquierdo;
        return actual.Valor;
    }

    public int? Maximo()
    {
        if (Raiz == null) return null;
        NodoABB actual = Raiz;
        while (actual.Derecho != null) actual = actual.Derecho;
        return actual.Valor;
    }

    //Verifica que se cumpla la propiedad del ABB en todos los nodos.
    public bool EsABBValido() => ValidarRec(Raiz, long.MinValue, long.MaxValue);

    private static bool ValidarRec(NodoABB? nodo, long minimo, long maximo)
    {
        if (nodo == null) return true;
        if (nodo.Valor <= minimo || nodo.Valor >= maximo) return false;
        return ValidarRec(nodo.Izquierdo, minimo, nodo.Valor)
            && ValidarRec(nodo.Derecho, nodo.Valor, maximo);
    }

    public void Limpiar()
    {
        Raiz = null;
        Cantidad = 0;
    }
}
