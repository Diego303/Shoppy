using Shoppy.Modelo;
using Shoppy.Persistencia;
using Shoppy.Presentacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using System.Threading.Tasks;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Shoppy
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static GestorProductos gestor;
        private Usuario usuarioLogeado;
        public static MainPage Current;

        internal Usuario UsuarioLogeado { get => usuarioLogeado; set { usuarioLogeado = value; if (usuarioLogeado == null) { mostrarRegistroAsync(); } } }

        public MainPage()
        {

            this.InitializeComponent();
            gestor = new GestorProductos();
            Current = this; //Para usar el FRAME desde otras paginas
            
            //Parte TILES
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {//INICIO TileMedium
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Bienvenido a Shoppy",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Pincha para ver los Productos de esta temporada!",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    }, //FIN TileMedium


                    TileWide = new TileBinding()
                    {//INICIO TileWide
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "Bienvenido a Shoppy",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Pincha para ver los Productos de esta temporada!",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },//FIN TileWide

                    TileLarge = new TileBinding()
                    {//INICIO TileLarge
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                 new AdaptiveText()
                                {
                                    Text = "Bienvenido a Shoppy",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },

                                new AdaptiveText()
                                {
                                    Text = "Pincha para ver los Productos de esta temporada!",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    }//FIN TileLarge
                }
            };

            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += irAtras;

            //Menu responsivo
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320)); //Para decirle el tamaño de ventana y hacer pruebas
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;


            mostrarLoginAsync();
            

            
            fmPrincipal.Navigate(typeof(InicioPage), gestor);

        }

        private async void mostrarLoginAsync()
        {
            LoginCD dialogoLogin = new LoginCD();
            var resultDialogo = await dialogoLogin.ShowAsync();
            if (resultDialogo == ContentDialogResult.Primary || resultDialogo == ContentDialogResult.Secondary)
            {
                UsuarioLogeado = dialogoLogin.Usuario;
            } else // si no se ha logeado o se ha registrado entonces es que ha pulsado cancelar asi que terminamos la aplicación
            {
                Application.Current.Exit();
            }
        }

        private async void mostrarRegistroAsync()
        {
            RegistroCD dialogoRegistro = new RegistroCD();
            var resultado = await dialogoRegistro.ShowAsync();
            if (resultado == ContentDialogResult.Primary)
            {
                UsuarioLogeado = dialogoRegistro.Usuario;
            }
        }

        private void irAtras(object sender, BackRequestedEventArgs e)
        {
            //Si pila de acumulacion de ventanas tiene algo, pues que vaya hacia detras.
            if (fmPrincipal.BackStack.Any())
            {
                fmPrincipal.GoBack();
            }
        }

        //Menu Responsivo
        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {

            var Width = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;

            if (Width >= 720) // Resolucion Grande
            {
                svMenu.IsPaneOpen = true;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactInline;
            }
            else if (Width >= 360) // Resolucion media
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.CompactOverlay;
            }
            else // Resolucion muy pequeña
            {
                svMenu.IsPaneOpen = false;
                svMenu.DisplayMode = SplitViewDisplayMode.Overlay;
            }
        }

        //Boton para desplegar o plegar el panel de Menu
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            svMenu.IsPaneOpen = !svMenu.IsPaneOpen; // Si esta a true lo pone a falso y viceversa
        }

        //PARTE DE NAVEGACION ENTRE VENTANAS A PARTIR DE AQUI

        private void Inicio_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(MainPage));
            fmPrincipal.Navigate(typeof(InicioPage), gestor);
        }

        private void Categorias_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            fmPrincipal.Navigate(typeof(CategoriasPage), gestor);
        }

        private void Outlet_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            fmPrincipal.Navigate(typeof(OutletPage), gestor);
        }

        private void Buscar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            fmPrincipal.Navigate(typeof(BuscarPage), gestor);
        }

        private void Carrito_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            fmPrincipal.Navigate(typeof(CarritoPage), gestor);
        }

        private void MiCuenta_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            fmPrincipal.Navigate(typeof(MiCuentaPage), UsuarioLogeado);
        }

    }
}
