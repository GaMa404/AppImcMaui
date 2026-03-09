namespace AppImcMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            double altura = Convert.ToDouble(txt_altura.Text) / 100;
            double peso = Convert.ToDouble(txt_peso.Text);

            double imc = peso / (altura * altura);

            switch (imc)
            {
                case < 18.5:
                    lbl_resultado.Text = $"IMC: {imc:F2}";
                    lbl_categoria.Text = "Abaixo do Peso";
                    lbl_resultado.TextColor = Colors.Red;
                    lbl_categoria.TextColor = Colors.Red;
                    break;
                case >= 18.5 and < 25:
                    lbl_resultado.Text = $"IMC: {imc:F2}";
                    lbl_categoria.Text= "Peso Normal";
                    lbl_resultado.TextColor = Colors.Green;
                    lbl_categoria.TextColor = Colors.Green;
                    break;
                case >= 25 and < 30:
                    lbl_resultado.Text = $"IMC: {imc:F2}";
                    lbl_categoria.Text = "Sobrepeso";
                    lbl_resultado.TextColor = Colors.GreenYellow;
                    lbl_categoria.TextColor = Colors.GreenYellow;
                    break;
                case >= 30 and < 35:
                    lbl_resultado.Text = $"IMC: {imc:F2}";
                    lbl_categoria.Text = "Obesidade Grau I";
                    lbl_resultado.TextColor = Colors.Yellow;
                    lbl_categoria.TextColor = Colors.Yellow;
                    break;
                case >= 35 and < 40:
                    lbl_resultado.Text = $"IMC: {imc:F2}";
                    lbl_categoria.Text = "Obesidade Grau II";
                    lbl_resultado.TextColor = Colors.Orange;
                    lbl_categoria.TextColor = Colors.Orange;
                    break;
                default:
                    lbl_resultado.Text = $"IMC: {imc:F2}";
                    lbl_categoria.Text = "Obesidade Grau III";
                    lbl_resultado.TextColor = Colors.Red;
                    lbl_categoria.TextColor = Colors.Red;
                    break;
            }
        }
    }
}
