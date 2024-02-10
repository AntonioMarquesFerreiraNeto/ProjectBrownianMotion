using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBrownianMotion.Mvvm.Views {

    public class DrawableGraphic : IDrawable {

        private readonly double[] _prices;

        //Instânciando e realizando a injenção de depedências para motar o gráfico com base na lista.
        public DrawableGraphic(double[] prices) {
            _prices = prices;
        }

        //Código gerador do gráfico brownianMotion que será chamado pela camada view da aplicação passando o paramêtro.
        public void Draw(ICanvas canvas, RectF dirtyRect) {

            canvas.StrokeColor = Colors.DarkBlue;
            canvas.FontSize = 3;
            if (_prices.Length == 0) {
                return;
            }
            var path = new Microsoft.Maui.Graphics.PathF();

            float xIncrement = dirtyRect.Width / (_prices.Length - 1);

            float startX = 0;
            float startY = (float)(dirtyRect.Height - (_prices[0] * dirtyRect.Height)); // Usar o primeiro preço como ponto de partida

            path.MoveTo(startX, startY);

            for (int i = 1; i < _prices.Length; i++) {
                var x = i * xIncrement;

                // Usar uma média ponderada entre o preço atual e o preço anterior para suavizar a transição
                var y = dirtyRect.Height - ((_prices[i] + _prices[i - 1]) / 2 * dirtyRect.Height);

                var endX = x;
                var endY = y;

                path.LineTo(endX, (float)endY);
            }

            canvas.DrawPath(path);
        }


    }
}