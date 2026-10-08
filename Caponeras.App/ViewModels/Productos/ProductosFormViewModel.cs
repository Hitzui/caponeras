using Caponeras.App.Dto;
using Caponeras.App.Helpers;
using Caponeras.App.Services;
using DevExpress.Mvvm;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace Caponeras.App.ViewModels.Productos;

public class ProductosFormViewModel : BaseViewModel
{
    private Helpers.INavigationService _navigationService;
    private readonly ProductosService _productosService;
    private readonly HttpClient _client;
    private ProductoDto? _selectedProducto;

    public ProductosFormViewModel(Helpers.INavigationService navigationService, ProductosService productosService, HttpClient client)
    {
        _navigationService = navigationService;
        _productosService = productosService;
        _client = client;
    }

    public void LoadSelected()
    {
        SelectedProducto = _navigationService.Query as ProductoDto;
    }

    public List<CategoriaProductoDto> GetCategorias()
    {
        return _productosService.GetCategorias();
    }

    public List<UnidadMedidaDto> GetUnidadesMedida()
    {
        return _productosService.GetUnidadesMedida();
    }

    public ProductoDto? SelectedProducto
    {
        get => _selectedProducto;
        set => SetValue(ref _selectedProducto, value);
    }

    public async Task<bool> Save(ProductoDto producto)
    {
        var imagenNoSubida = false;
        try
        {
            if (string.IsNullOrWhiteSpace(producto.Codigo) || string.IsNullOrWhiteSpace(producto.Nombre))
            {
                GetMessageAlert(TypeAlert.Warning, "Producto", "Ingrese el código y el nombre del producto.",
                    _navigationService.MainView);
                return false;
            }

            var existeCodigo = await _productosService.VerificarCodigoAsync(producto);
            if (existeCodigo)
            {
                GetMessageAlert(TypeAlert.Warning,
                    "Producto", $"Ya existe un producto con ese código {producto.Codigo}",
                    _navigationService.MainView);
                return false;
            }

            if (producto.Imagen is not null)
            {
                var url = await SubirImagenAsync(producto.Imagen, producto.Codigo.Trim());
                if (!string.IsNullOrWhiteSpace(url))
                    producto.UrlImage = url;
                else
                    imagenNoSubida = true;
            }

            var save = await _productosService.Save(producto);

            if (save > 0)
            {
                var mensaje = imagenNoSubida
                    ? "El producto se guardó, pero no se pudo subir la nueva imagen. Se mantuvo la imagen anterior."
                    : "Se ha guardado el producto de forma correcta.";
                GetMessageAlert(imagenNoSubida ? TypeAlert.Warning : TypeAlert.Success, "Guardar", mensaje,
                    _navigationService.MainView);
                Messenger.Default.Send(new ProductoGuardadoMessage());
                return true;
            }

            GetMessageAlert(TypeAlert.Error, "Guardar",
                $"No fue posible guardar el producto. {_productosService.ErrorMessage}",
                _navigationService.MainView);
            return false;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            GetMessageAlert(TypeAlert.Error, "Guardar producto",
                $"No fue posible guardar el producto. {e.GetBaseException().Message}",
                _navigationService.MainView);
            return false;
        }
    }

    public async Task<string?> SubirImagenAsync(Image imagen, string codigo)
    {
        try
        {
            using var content = new MultipartFormDataContent();
            var imageBytes = ImageToByteArray(imagen);
            var imageContent = new ByteArrayContent(imageBytes);
            imageContent.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

            content.Add(imageContent, "imagen", "producto.jpg");
            content.Add(new StringContent(codigo), "codigo");

            using var response = await _client.PostAsync(
                "https://orobestni.com/caponeras/api-productos/upload",
                content
            );

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<UploadResponse>(json);
            return result?.Url;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            return null;
        }
    }

    public void MensajeAlerta(TypeAlert type, string title, string body)
    {
        GetMessageAlert(type, title, body, _navigationService.MainView);
    }

    private byte[] ImageToByteArray(Image image)
    {
        using var ms = new MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        return ms.ToArray();
    }

    public class ProductoGuardadoMessage
    {
    }
}
