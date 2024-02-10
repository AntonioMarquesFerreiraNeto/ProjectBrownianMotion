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
        double precoInicial;
        double votatilidade;
        double retorno;
        int dias;

        // Realiza a conversão dos valores das entradas, verificando se são válidos
        if (!double.TryParse(precoInicialEntry.Text, out precoInicial) ||
            !double.TryParse(votatilidadeEntry.Text, out votatilidade) ||
            !double.TryParse(retornoEntry.Text, out retorno) ||
            !int.TryParse(diasEntry.Text, out dias)) {
            // Se a conversão falhar, exibe uma mensagem para o usuário ou tome outra ação adequada.
            return;
        }

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

