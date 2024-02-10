using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBrownianMotion.Mvvm.Models {

    internal class BrownianMotion {

        public double PrecoInicial { get; set; }

        public double Votatilidade { get; set; }

        public double MediaRetorno { get; set; }

        public int TempoDuracaoDias { get; set; }

        public double[] GenerateBrownnMotion() {
            Random rand = new Random();
            double[] prices = new double[TempoDuracaoDias];
            prices[0] = PrecoInicial;

            double dt = 1.0 / TempoDuracaoDias;
            double sqrtdt = Math.Sqrt(dt);

            for (int i = 1; i < TempoDuracaoDias; i++) {
                double u1 = rand.NextDouble();
                double u2 = rand.NextDouble();
                double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                double drift = MediaRetorno * dt;
                double diffusion = Votatilidade * sqrtdt * z;

                double retornoDiario = drift + diffusion;

                prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
            }

            return prices;
        }

    }
}
