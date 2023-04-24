using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using MovilMedia.Models;
using MovilMedia.Movil;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace MovilMedia.Movil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        ObservableCollection<MediaModels> Photos = new ObservableCollection<MediaModels>();
        public Page1()
        {
            InitializeComponent();
        }

        public async void Photobutton_Pressed(object sender, EventArgs e)
        {
            var isInitialize = await CrossMedia.Current.Initialize();

            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.IsSupported ||!isInitialize)
            {
                await DisplayAlert("Error", "La camara no se encuentra disponible", "OK");
                return;
            }
            var newPhotoID = Guid.NewGuid();

            using (var photo = await CrossMedia.Current.TakePhotoAsync(new StoreVideoOptions()
            {
                Name = newPhotoID.ToString(), 
                SaveToAlbum = true, 
                DefaultCamera = CameraDevice.Rear,
                Directory = "Demo Camara", 
                CustomPhotoSize = 50
            }))
            {
                if (string.IsNullOrWhiteSpace(photo?.Path))
                {
                    return;
                }
                var newPhotoMedia = new MediaModels()
                {
                    MediaID = newPhotoID,
                    Path = photo.Path,
                    LocalDataTime = DateTime.Now

                };

                Photos.Add(newPhotoMedia);

                photo.Dispose();
            }
            listPhotos.ItemsSource = Photos;
        }

        private void Photobutton_Pressed_1(object sender, EventArgs e)
        {

        }

        private void Photobutton_Clicked(object sender, EventArgs e)
        {

        }
    }
}