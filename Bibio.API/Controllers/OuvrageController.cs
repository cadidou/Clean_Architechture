using APPLICATION.service.Adherent;
using APPLICATION.service.Ouvrages;
using AutoMapper;
using Bibio.API.DTO;
using DOMAIN.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bibio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OuvrageController : ControllerBase
    {
        private IouvrageService Ouvrageservice;
        private IMapper mapper;
        public OuvrageController(IouvrageService ouvrageservice, IMapper mapper)
        {
          this.Ouvrageservice = ouvrageservice;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("listouvrages")]
        public IActionResult GetAll()
        {

            //--get Models 
            var ouvrages = Ouvrageservice.GetAllouvrages();


            //--Mapp  models to DTOs and retrun it  

            var ouvragedto = mapper.Map<List<OuvrageDto>>(ouvrages);


            return Ok(ouvragedto);
        }

        [HttpGet]
        [Route("Countouvrage")]
        public IActionResult CountOuvrage()
        {
            var nbr = Ouvrageservice.Count<ouvrage>();




            return Ok(nbr);

        }

        [HttpPost]
        [Route("ajouter")]
        public IActionResult Ajouter(OuvrageDto ouvragedto)
        {

            //--get Models 
            var ouvrage = mapper.Map<ouvrage>(ouvragedto);

            //saving adhent entity into DATABASE
            Ouvrageservice.Add(ouvrage);
            //--Mapp  models to DTOs and retrun it  




            return Ok(ouvrage.Id);
        }
        [HttpPut]
       
        public IActionResult Modifier(string id, OuvrageDto ouvrageDto)
        {

            //--get Models 
            var ouvrage = Ouvrageservice.GetById<ouvrage>(id);

            if (ouvrage == null) return NotFound();
            else
            {

                ouvrage.auteur = ouvrageDto.auteur;
                ouvrage.auteur=ouvrageDto.auteur;
                ouvrage.consultable= ouvrageDto.consultable;
                ouvrage.domain = ouvrageDto.domain;
                ouvrage.auteur=ouvrageDto.auteur;
                ouvrage.titre = ouvrageDto.titre;
                
                Ouvrageservice.Update(ouvrage);

            }
            //return DTO



            return Ok(mapper.Map<AdherantDto>(ouvrage));
        }

        [HttpDelete]
        [Route("supprimer")]
        public IActionResult Delete(string id)
        {

            //--get Models 
            var ouvrage =Ouvrageservice.GetById<ouvrage>(id);

            if (ouvrage == null) return NotFound();
            else
            {
                //dalete adhent entity into DATABASE


                Ouvrageservice.Delete(ouvrage);
            }


            //--return DTO




            return Ok(mapper.Map<OuvrageDto>(ouvrage));
        }
    }
}
