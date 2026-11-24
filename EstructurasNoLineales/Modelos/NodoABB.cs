namespace EstructurasNoLineales.Modelos;

// Nodo del Árbol Binario de Búsqueda. Cada nodo se reserva en memoria dinámica con "new" al momento de insertar y se enlaza mediante referencias.

public class NodoABB
{
    public int Valor { get; set; }
    public NodoABB? Izquierdo { get; set; }
    public NodoABB? Derecho { get; set; }

    public NodoABB(int valor)
    {
        Valor = valor;
    }

    public bool EsHoja => Izquierdo == null && Derecho == null;
}
