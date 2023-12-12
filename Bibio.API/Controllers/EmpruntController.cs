using APPLICATION.service.Adherent;
using APPLICATION.service.emprunt;
using AutoMapper;
using Bibio.API.DTO;
using DOMAIN.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpruntController : ControllerBase
    {
        private IEmpruntService empruntService;
        private IMapper mapper;
        public EmpruntController(IEmpruntService empruntService, IMapper mapper)
        {
            this.empruntService = empruntService;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("listemprint")]
        public IActionResult GetAll()
        {

            //--get Models 
            var emprunt = empruntService.GetEmprunt();


            //--Mapp  models to DTOs and retrun it  

            var empruntdto = mapper.Map<List<EmpruntDto>>(emprunt);


            return Ok(empruntdto);
        }

        [HttpGet]
        [Route("Countemprunt")]
        public IActionResult CountAdhrent()
        {
            var nbr = empruntService.Count<emprunt>();

            return Ok(nbr);

        }

        [HttpPost]
        [Route("ajouter")]
        public IActionResult Ajouter(EmpruntDto empruntDto)
        {

            //--get Models 
            var emprunt = mapper.Map<emprunt>(empruntDto);

            //saving adhent entity into DATABASE
            empruntService.Add(emprunt);
            //--Mapp  models to DTOs and retrun it  




            return Ok(emprunt.Id);
        }
        [HttpPut]
        [Route("Modifier")]
        public IActionResult Modifier(string id, EmpruntDto empruntDto)
        {

            //--get Models 
            var emprunt = empruntService.GetById<emprunt>(id);

            if (emprunt == null) return NotFound();
            else
            {
                 
                emprunt.dateRetour=empruntDto.dateRetour;
                emprunt.dateEmprunt = empruntDto.dateEmprunt;

                emprunt.AdherantID = empruntDto.AdherantID;
                emprunt.OuvrageID = empruntDto.OuvrageID;


                empruntService.Update(emprunt);

            }
            //return DTO



            return Ok(mapper.Map<EmpruntDto>(emprunt));
        }

        [HttpDelete]
        [Route("supprimer")]
        public IActionResult Delete(string id)
        {

            //--get Models 
            var emprunt = empruntService.GetById<emprunt>(id);

            if (emprunt == null) return NotFound();
            else
            {
                //dalete adhent entity into DATABASE


                empruntService.Delete(emprunt);
            }


            //--return DTO




            return Ok(mapper.Map<EmpruntDto>(emprunt));
        }
    }
}
