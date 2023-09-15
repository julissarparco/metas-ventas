using BCP.META.Presentation.Entities;
using BCP.META.Presentation.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BCP.META.Presentation.Pages
{
    public class VentaFormModel : PageModel
    {
        public int AgenciaId { get; set; }
        public string Periodo { get; set; }
        public AsesorComercial AsesorComercial { get; set; }
        public List<AsesorComercial> AsesoresComerciales { get; set; }
         
        public List<string> Periodos { get; set; }

        public IActionResult OnGet()
        {
            Periodos = ObtenerPeriodos();
            return Page();
        }

        private List<string> ObtenerPeriodos()
        {
            var months = new List<string>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(DateTime.Now.Year + "-" + i.ToString("00"));
            }
            return months;
        }

        public async Task<List<AsesorComercial>> GetAsesoresComerciales(int agenciaId)
        {
            var response = await new AsesorComercialService().ObtenerAsesoresComercialesAsync(agenciaId);
            return response;
        }
    }
}
