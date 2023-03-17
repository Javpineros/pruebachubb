using PruebaChubb.CI;
using PruebaChubb.CI.Actions;
using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.Business
{
    public class RuletaBL : IRuletaBusinessAction
    {
        private readonly IRuletaRepositoryAction _ruletaRepositoryAction;
        private readonly IApuestaDetalleRepositoryAction _apuestaDetalleRepositoryAction;
        Response<Ruleta> response;
        public RuletaBL(IRuletaRepositoryAction ruletaRepositoryAction, IApuestaDetalleRepositoryAction apuestaDetalleRepositoryAction) 
        {
            this._ruletaRepositoryAction = ruletaRepositoryAction;
            _apuestaDetalleRepositoryAction= apuestaDetalleRepositoryAction;
            response = new();
        }

        public async Task<Response<bool>> Cerrar(int idRuleta)
        {
            Response<DetalleApuesta> detalleApuestas=await _apuestaDetalleRepositoryAction.GetApuestas(idRuleta);
            CierreResult cierre = new();
            if (detalleApuestas.Entities.Any()) {
                 cierre = CerrarRuleta(detalleApuestas.Entities);
                await _apuestaDetalleRepositoryAction.UpdateApuestaDetalle(cierre.DetalleApuestas);
            }
            return await this._ruletaRepositoryAction.Cerrar(idRuleta, cierre.NumeroGanador,cierre.ColorGanador);
        }

        public CierreResult CerrarRuleta(List<DetalleApuesta> detalleApuestas)
        {
            Random rnd = new Random();
            CierreResult cierre=new();
            int num = rnd.Next(36);
            int color= rnd.Next(2);
            string colorName = color == 1 ? "ROJO" : "NEGRO";

            var apuestasNumero = detalleApuestas.Where(x => x.Tipo == 2);
            var apuestasColor = detalleApuestas.Where(x => x.Tipo == 1);

            foreach (var item in apuestasNumero)
            {
                if (item.Numero == num)
                    item.ValorGanado = item.Monto * 5;
                else
                    item.ValorGanado = 0;
            }

            foreach (var item in apuestasColor)
            {
                if(item.Color.ToUpper()== colorName)
                    item.ValorGanado = item.Monto * Convert.ToDecimal(1.8);
                else
                    item.ValorGanado = 0;
            }

            List<DetalleApuesta> detalleApuestas1= new List<DetalleApuesta>();
            detalleApuestas1.AddRange(apuestasNumero);
            detalleApuestas1.AddRange(apuestasColor);
            cierre.DetalleApuestas=detalleApuestas1;
            cierre.NumeroGanador=num;
            cierre.ColorGanador = colorName;
            return cierre;
        }

        public async Task<Response<Ruleta>> ChageStateRuleta(int idRuleta)
        {
            var ruleta= await this._ruletaRepositoryAction.GetRuleta(idRuleta);
            if (ruleta == null || ruleta.Entities.First().IdRuleta == 0)
            {
                response.Result = false;
                response.Messages.Add("No existe la ruleta");
                return response;
            }
            if (ruleta.Entities.First().IdRuleta!=0 && ruleta.Entities.First().Estado == true)
            {
                response.Result = false;
                response.Messages.Add("Apuesta ya abierta");
                return response;
            }

            return await this._ruletaRepositoryAction.ChageStateRuleta(idRuleta);
        }

        public Task<Response<Ruleta>> GetRuleta(int idRuleta)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<RuletaResult>> GetRuletas()
        {
            return await this._ruletaRepositoryAction.GetRuletas();
        }

        public async Task<Response<Ruleta>> SaveRuleta(RuletaParameter ruleta)
        {
            if (ruleta.Nombre == null || ruleta.Nombre == string.Empty)
            {
                response.Result = false;
                response.Messages.Add(rcMessages.NombreRuleta);
                return response;
            }
            response= await this._ruletaRepositoryAction.SaveRuleta(ruleta);
            response.Result = response.Entities.Any()?true:false;
            response.Messages.Add( response.Entities.Any() ? rcMessages.RegistroCreado : rcMessages.RegistroFallo);

            return response;
        }
    }
}
