using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaChubb.CI;
using PruebaChubb.CI.Actions;
using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;

namespace PruebaChubb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuletaController : ControllerBase
    {
        private readonly IRuletaBusinessAction _RuletaBusinessAction;
        private readonly IApuestaBusinessAction _apuestaBusinessAction;
        public RuletaController(IRuletaBusinessAction ruletaBusinessAction, IApuestaBusinessAction apuestaBusinessAction) {
            _RuletaBusinessAction=ruletaBusinessAction;
            _apuestaBusinessAction=apuestaBusinessAction;
        }

        [HttpGet]
        [Route("Ruletas")]
        public async Task<Response<RuletaResult>> GetRuletas()
        {

                return await _RuletaBusinessAction.GetRuletas();
        }

        [HttpPost]
        [Route("SaveRuleta")]
        public async Task<Response<Ruleta>> SaveRuleta(RuletaParameter ruleta)
        {

            return await _RuletaBusinessAction.SaveRuleta(ruleta);
        }

        [HttpPut]
        [Route("Abrir")]
        public async Task<Response<Ruleta>> ChageStateRuleta(int IdRuleta)
        {

            return await _RuletaBusinessAction.ChageStateRuleta(IdRuleta);
        }

        [HttpPut]
        [Route("Apuestas")]
        public async Task<Response<bool>> ChageStateRuleta(ApuestaParameter apuestaParameter)
        {

            return await _apuestaBusinessAction.SaveApuesta(apuestaParameter);
        }

        [HttpPut]
        [Route("Cerrar")]
        public async Task<Response<bool>> Cerrar(RuletaIdParameter IdRuleta)
        {

            return await _RuletaBusinessAction.Cerrar(IdRuleta.IdRuleta);
        }
    }
}
