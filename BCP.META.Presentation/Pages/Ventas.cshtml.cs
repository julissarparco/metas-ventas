using BCP.META.Presentation.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCP.META.Presentation.Pages
{
    public class VentasModel : PageModel
    {
        private readonly VentasService _ventasService;

        public VentasModel(VentasService ventasService)
        {
            _ventasService = ventasService;
        }


        public async Task OnGet()
        {
            var ventas = await _ventasService.ObtenerVentas();
            ViewData["Ventas"] = ventas;
        }

    }
}
