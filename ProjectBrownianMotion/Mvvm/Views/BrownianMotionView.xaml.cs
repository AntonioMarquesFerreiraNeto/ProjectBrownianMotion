using Aurigma.GraphicsMill.AjaxControls;
using Microsoft.Maui.Controls;
using ProjectBrownianMotion.Mvvm.Models;

namespace ProjectBrownianMotion.Mvvm.Views;

public partial class BrownianMotionView : ContentPage {

    public BrownianMotionView() {
        InitializeComponent();
    }

    //Método que irá retornar o gráfico após o click do usuário no botão.
    private void GerarSimulacaoClicked(object sender, EventArgs e) {
        double precoInicial = Convert.ToDouble(precoInicialEntry.Text);
        double votatilidade = Convert.ToDouble(votatilidadeEntry.Text);
        double retorno = Convert.ToDouble(retornoEntry.Text);
        int dias = Convert.ToInt32(diasEntry.Text);

        var brownianMotion = new BrownianMotion {
            PrecoInicial = precoInicial,
            Votatilidade = votatilidade,
            MediaRetorno = retorno,
            TempoDuracaoDias = dias
        };

        //Realizando validações para não quebrar a aplicação por valores nulos na mesma. 
        if (brownianMotion.PrecoInicial != 0 && brownianMotion.Votatilidade != 0 && brownianMotion.TempoDuracaoDias != 0 && brownianMotion.MediaRetorno != 0) {
            var prices = brownianMotion.GenerateBrownnMotion();
            DrawableGraphic.Drawable = new DrawableGraphic(prices);
        }
    }
}

