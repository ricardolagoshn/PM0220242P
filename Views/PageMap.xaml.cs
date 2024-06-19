using Android.Gms.Maps;
using Microsoft.Maui.Controls.Maps;

namespace PM0220242P.Views;

public partial class PageMap : ContentPage
{
	public PageMap()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var localizacion = await Geolocation.Default.GetLastKnownLocationAsync();

        if (localizacion != null)
        {
            var MapPin = new Pin
            {
                Label = "Estoy Aca",
                Address = "Tegucigalpa",
                Type = PinType.Place,
                Location = localizacion
            };

            mapa.Pins.Add(MapPin);
        }
    }
}