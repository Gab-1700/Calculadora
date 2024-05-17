namespace Calculadora.Operadores;
public interface IOperador
{
    float A{get; set;}
    float B{get; set;}

    float Ejecutar();

}