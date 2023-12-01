using BindableProps;
using System.Runtime.CompilerServices;

namespace AppListaDeCompras.Libraries.Components;

public partial class HorizontalLine : ContentView
{
    
    [BindableProp]
    private Color _stroke;
	public HorizontalLine()
	{
		InitializeComponent();
	}

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if( Window?.Width != null && Line != null)
        {
            Line.X2 = Window.Width;
        }

        if(propertyName == "Stroke")
        {
            Line.Stroke = Stroke;
        }
    }
}