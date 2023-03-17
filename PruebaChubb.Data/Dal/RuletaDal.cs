using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PruebaChubb.CI;
using PruebaChubb.CI.Actions;
using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;
using PruebaChubb.Data.Context;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.Data.Dal
{
    public class RuletaDal : IRuletaRepositoryAction
    {
        readonly private IMapper _mapper;
        Response<Ruleta> response;
        public RuletaDal(IMapper mapper)
        { _mapper = mapper;
            response = new();
        }

        public async Task<Response<bool>> Cerrar(int idRuleta, int numeroGanador, string colorGanador)
        {
            Response<bool> response= new();
            Ruleta ruleta1 = new();
            using (var context = new ChubbContext())
            {
                Ruletum ruletum = (from ruleta in context.Ruleta
                                   where ruleta.IdRuleta == idRuleta
                                   select ruleta).First();
                ruletum.Estado = false;
                ruletum.NumeroGanador = numeroGanador;
                ruletum.ColorGanador = colorGanador;
                await context.SaveChangesAsync();
                _mapper.Map(ruletum, ruleta1);
                response.Entities.Add(true);
            }
            return response;
        }

        public async Task<Response<Ruleta>> ChageStateRuleta(int idRuleta)
        {
            Ruleta ruleta1 = new();
            using (var context = new ChubbContext())
            {
                Ruletum ruletum = (from ruleta in context.Ruleta
                                  where ruleta.IdRuleta == idRuleta
                                  select ruleta).First();
                ruletum.Estado=true;
                await context.SaveChangesAsync();
                _mapper.Map(ruletum, ruleta1);
                response.Entities.Add(ruleta1);
            }
            return response;
        }

        public async Task<Response<Ruleta>> GetRuleta(int idRuleta)
        {
            Ruleta ruleta1 = new();
            using (var context = new ChubbContext())
            {
                Ruletum ruletum = await (from ruleta in context.Ruleta
                                   where ruleta.IdRuleta == idRuleta
                                   select ruleta).FirstOrDefaultAsync();

                _mapper.Map(ruletum, ruleta1);
                response.Entities.Add(ruleta1);
            }
            return response;
        }

        public async Task<Response<RuletaResult>> GetRuletas()
        {
            Response<RuletaResult> response=new Response<RuletaResult>();
            List<RuletaResult> ruletasResult = new List<RuletaResult>();
            List<DetalleApuestaResult> DetalleApuestas = new List<DetalleApuestaResult>();
            using (var context = new ChubbContext())
            {
                ruletasResult = await (from r in context.Ruleta
                                select new RuletaResult
                                { 
                                IdRuleta=r.IdRuleta,
                                Nombre=r.Nombre,
                                Estado=r.Estado==true?"Abierta":"Cerrada",
                                NumeroGanador=(int)r.NumeroGanador,
                                ColorGanador=r.ColorGanador
                                }).ToListAsync();
            }

            using (var context = new ChubbContext())
            {
                DetalleApuestas = await (from r in context.Ruleta
                                       join a in context.Apuesta on r.IdRuleta equals a.IdRuleta
                                       join d in context.DetalleApuesta on a.IdApuesta equals d.IdApuesta
                                       select new DetalleApuestaResult
                                       {
                                           IdRuleta=r.IdRuleta,
                                           IdUsuario=d.IdUsuario,
                                           Color=d.Color,
                                           Numero = d.Numero,
                                           Monto = d.Monto,
                                           ValorGanado = d.ValorGanado,
                                           Tipo=d.Tipo==1?"Color":"Número"
                                       }).ToListAsync();
            }

            foreach (var item in ruletasResult)
            {
                var det = DetalleApuestas.Where(x => x.IdRuleta == item.IdRuleta);

                if (det.Any())
                {
                    item.DetalleApuestas = new List<DetalleApuestaResult>();
                    item.DetalleApuestas.AddRange(det);
                }
            }

            response.Entities.AddRange(ruletasResult);
            return response;
        }

        public async Task<Response<Ruleta>> SaveRuleta(RuletaParameter ruleta)
        {
            Ruletum ruletum = new();
            Ruleta ruleta1 = new ();
            _mapper.Map( ruleta, ruletum);
            using (var context = new ChubbContext())
            {
                ruletum.Estado = false;
                ruletum.NumeroGanador= 0;
                ruletum.ColorGanador = string.Empty;
                context.Add(ruletum);
               await context.SaveChangesAsync();
            }
            _mapper.Map( ruletum, ruleta1);
            response.Entities.Add(ruleta1);
            return response;
        }
    }
}
