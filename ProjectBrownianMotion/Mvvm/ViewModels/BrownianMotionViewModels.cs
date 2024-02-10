using MvvmHelpers;
using ProjectBrownianMotion.Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectBrownianMotion.Mvvm.ViewModels {

    internal class BrownianMotionViewModels {
        //Adicionando o model na ViewModel para separar a lógica da aplicação da view da mesma, respeitando o MVVM.
        public BrownianMotion BrownianMotion { get; set; }

    }
}
