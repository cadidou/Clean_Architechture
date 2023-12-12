using APPLICATION.service.Adherent;
using AutoMapper;
using Bibio.API.DTO;
using DOMAIN.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APPLICATION.Services;

namespace Bibio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdherantController : ControllerBase
    {

        private IAdherentService AdherentService;
        private IMapper mapper; 
        public AdherantController(IAdherentService AdherentService, IMapper mapper)
        { 
            this.AdherentService = AdherentService;
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("listadherent")]
        public IActionResult  GetAll()
        {

            //--get Models 
            var adhrent=AdherentService.GetAdherants();
            

          //--Mapp  models to DTOs and retrun it  

            var adhrentdto = mapper.Map <List<AdherantDto>>(adhrent);


            return Ok(adhrentdto);
        }
        
        [HttpGet]
        [Route("CountAdhrent")]
        public  IActionResult CountAdhrent()
        {
            var nbr = AdherentService.Count<Adherant>();


           

            return Ok(nbr);

        }

        [HttpPost]
        [Route("ajouter")]
        public IActionResult Ajouter(AdherantDto adherantDto)
        {

            //--get Models 
            var adhrent = mapper.Map<Adherant>(adherantDto);

            //saving adhent entity into DATABASE
            AdherentService.Add(adhrent);
            //--Mapp  models to DTOs and retrun it  

             


            return Ok(adhrent.Id);
        }
        [HttpPut]
         
        public IActionResult Modifier(string id,AdherantDto adherantDto)
        {

            //--get Models 
            var adherent = AdherentService.GetById<Adherant>(id);

            if (adherent == null) return NotFound();
            else
            {
                adherent.Nom = adherantDto.Nom;
                adherent.prenom = adherent.prenom;
                adherent.date_inscription = adherantDto.date_inscription;
                adherent.date_sanction = adherantDto.date_sanction;
                adherent.nbr_emprunt = adherantDto.nbr_emprunt;
                adherent.sanctionne = adherantDto.sanctionne;
                adherent.date_sanction = adherantDto.date_sanction;
                AdherentService.Update(adherent);

            }
           //return DTO



            return Ok(mapper.Map<AdherantDto>(adherent));
        }

        [HttpDelete]
        [Route("supprimer")]
        public IActionResult Delete(string id)
        {

            //--get Models 
            var adherent = AdherentService.GetById<Adherant>(id);
            
            if (adherent == null) return NotFound();
            else
            {
                //dalete adhent entity into DATABASE
              
               
                AdherentService.Delete(adherent);
            }


            //--return DTO




            return Ok(mapper.Map<AdherantDto>(adherent));
        }
    }
}
