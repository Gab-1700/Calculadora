using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    string concatenado;
    int Suma =0;
   
    public MainWindow()
    {
        InitializeComponent();

       //boton.Click += PresionarBoton;
      
    }


    public void PresionarBoton(object sender, RoutedEventArgs e){
        //MessageBox.Show("correcto");
       
       
        //MessageBox.Show((sender as Button).Content.ToString());
        concatenado =(sender as Button).Content.ToString();
        string a=concatenado;
        if(concatenado == "+"){
            Suma = Suma+ int.Parse(a);
            
            
        }

       // Historial.Content += (sender as Button).Content.ToString();
        Historial.Content = concatenado;

        MessageBox.Show(Suma.ToString());
        // ↻
        
    }

    
}