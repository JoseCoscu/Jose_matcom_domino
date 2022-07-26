namespace matcom_domino.Interfaces;

public interface IFichas<T>
{   
    // Devuelve la cara especificada
    T GetFace(int a);
    // Devuelve el valor de la ficha
    int FichaValue();
}