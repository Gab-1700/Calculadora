namespace Calculadora.Operadores;

class OperadorMultiplicacion:IOperador{

    public float A {get; set;}
    public float B {get; set;}

    public float Ejecutar(){
        return A*B;
    }

}