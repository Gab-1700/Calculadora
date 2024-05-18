using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using Calculadora.Operadores;


namespace Calculadora;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string concatenado;
    private float total;
    private IOperador operador;
    private IDictionary<string, IOperador> operadores;
    string memoria;
    float temporal;

    public MainWindow()
    {
        InitializeComponent();
        operadores = new Dictionary<string, IOperador>();
        operadores.Add("+", new OperadorSuma());
        operadores.Add("-", new OperadorResta());
        operadores.Add("*", new OperadorMultiplicacion());
        operadores.Add("/", new OperadorDivision());
        //boton.Click += PresionarBoton;

    }


    public void PresionarBoton(object sender, RoutedEventArgs e)
    {
        //MessageBox.Show("correcto");
        string contenido = GetContenido(sender);

        //MessageBox.Show((sender as Button).Content.ToString());
         
        if (operadores.ContainsKey(contenido))
        {
            if (operador == null)
            {
                operador = operadores[contenido];
                if(concatenado == null || concatenado == ""){
                    operador.A = 0;
                     Historial.Content =  operador.A;
                     //temporal=operador.A;       // opcional
                }else{
                operador.A = float.Parse(concatenado);
                }
            }
            else
            {
             if(concatenado ==""){ 
                    temporal = operador.A;
                    operador = operadores[contenido];                                 // sobree escribir al nuevo operador su izquiera
                    operador.A= temporal;
                    Historial.Content = temporal;
                    
             }else{
                    operador.B = float.Parse(concatenado); 
                    float ATemporal = operador.Ejecutar();
                    operador = operadores[contenido];
                    operador.A= ATemporal;
                 }
            }
            total = operador.A; //operador.A;
            ActualizarResultado(contenido);
        }   
        else if(contenido == "=" ) {          // 2 + 3 
               if(operador!=null){
                operador.B = float.Parse(concatenado);
                total = operador.Ejecutar();
                operador = null;
                Historial.Content =""; 
                Resultado.Content = total;
                concatenado= total.ToString();
               }
        }
        else if(contenido == "C"){
             operador=null;
            Resultado.Content =0;
            concatenado= "";
            Historial.Content="";
        }
        else if( contenido == "MS"){
            memoria = concatenado;
        }
        else if( contenido == "MR"){
            if(memoria == null){
                memoria="0";
            }   
            concatenado = memoria;
            Resultado.Content=memoria;
    
        }
        else if( contenido == "MC"){
            memoria ="0";
            Resultado.Content=memoria;
        }

        // que se muestre en el historial el numero y el porcentaje //   en resultado me muestre el total
        else if( contenido == "%"){
            if(operador is OperadorMultiplicacion){
                    //MessageBox.Show("hubo multiplicacion"+ concatenado);
                    var temp = float.Parse(concatenado);
                   Resultado.Content= (operador.A * float.Parse(concatenado, CultureInfo.InvariantCulture)) / 100;
            }
           
        }
        else if(contenido == "√"){
                float raiz =float.Parse(concatenado);
                double raiz1 =  Math.Sqrt(raiz);
                    Resultado.Content=raiz1;
        }
        else if(contenido == "log"){
                float logaritmo =float.Parse(concatenado);
                double logaritmo2 =  Math.Log10(logaritmo);
                    Resultado.Content=logaritmo2;
        }
         else if(contenido == "x²"){
                double cuadrado =  Math.Pow(float.Parse(concatenado),2);
                    Resultado.Content=cuadrado;
        }
         else if(contenido == "x³"){
                double cubo =  Math.Pow(float.Parse(concatenado),3);
                    Resultado.Content=cubo;
        }

        else
        {
            concatenado += contenido;
            Resultado.Content = concatenado;
        }
        // ↻         errores  al poner algun operando se  cierra la aplicacion
    }

        // pendiente
    public void ActualizarResultado(string contenido)
    {
        Historial.Content += concatenado + contenido;
        Resultado.Content = total;
        concatenado = "";
    }

    private string GetContenido(object sender)
    {
        return (sender as Button).Content.ToString();
    }


}