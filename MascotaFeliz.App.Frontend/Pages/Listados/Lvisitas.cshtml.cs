using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Pages
{
    public class LvisitasModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;

        [BindProperty]
        public VisitaPyP visita { get; set; }
        [BindProperty]
        public Historia historia { get; set; }
        


        public IEnumerable<Dueno>  ListaDuenos {get; set;}
        public IEnumerable<Veterinario>  ListaVeterinarios {get; set;}
        public IEnumerable<Mascota>  ListaMascotas {get; set;}
        public IEnumerable<Historia>  ListaHistorias {get; set;}
        public IEnumerable<VisitaPyP>  ListaVisitasPyP {get; set;}

        public LvisitasModel(){
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
            historia = new Historia();
        }

        public void OnGet(int? historiaId )
        {
            historia = _repoHistoria.GetHistoria(historiaId.Value);
            ListaDuenos = _repoDueno.GetAllDuenos();
            ListaVeterinarios = _repoVeterinario.GetAllVeterinarios();
            ListaMascotas = _repoMascota.GetAllMascotas();
            ListaHistorias = _repoHistoria.GetAllHistorias();
            ListaVisitasPyP = _repoVisitaPyP.GetVisitasPorFiltro(historiaId.Value);



            
        }
    }
}
