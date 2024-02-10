using ProjectBrownianMotion.Mvvm.Views;

namespace ProjectBrownianMotion;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        //Setando a BrownianMotionView como página principal e inicializadora da aplicação.
        MainPage = new BrownianMotionView();
	}
}
