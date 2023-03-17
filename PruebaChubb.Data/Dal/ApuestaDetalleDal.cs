using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaChubb.CI;
using PruebaChubb.CI.Actions;
using PruebaChubb.CI.Entities.Parameter;
using PruebaChubb.CI.Entities.Repository;
using PruebaChubb.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PruebaChubb.Data.Dal
{
    public class ApuestaDetalleDal : IApuestaDetalleRepositoryAction
    {
        Response<bool> response;
        Response<DetalleApuesta> responsedet;
        readonly private IMapper _mapper;
        public ApuestaDetalleDal(IMapper mapper)
        { response = new();
            responsedet = new();
            _mapper = mapper;
        }
        public async Task<Response<bool>> SaveApuestaDetalle(int idApuesta, ApuestaParameter apuestaParameter)
        {
            try
            {
                DetalleApuestum detalle = new();
                _mapper.Map(apuestaParameter, detalle);
                using (var context = new ChubbContext())
                {
                    detalle.IdApuesta= idApuesta;
                    detalle.ValorGanado = 0;
                    context.Add(detalle);
                    await context.SaveChangesAsync();
                }
                response.Entities.Add(true);
                return response;
            }
            catch 
            {

                response.Entities.Add(false);
                return response;
            }
        }

        public async Task<Response<DetalleApuesta>> GetApuestas(int idRuleta)
        {
            
            using (var context = new ChubbContext())
            {
                List<DetalleApuesta> apuestas =await (from apuesta in context.Apuesta 
                             join apuestadet in context.DetalleApuesta on apuesta.IdApuesta equals apuestadet.IdApuesta
                             where apuesta.IdRuleta==idRuleta
                             select new DetalleApuesta
                             { 
                                IdDetalle= apuestadet.IdDetalle,
                                IdUsuario= apuestadet.IdUsuario,
                                Color= apuestadet.Color,
                                Monto= apuestadet.Monto,
                                Numero= apuestadet.Numero,
                                Tipo= apuestadet.Tipo
                             }).ToListAsync();

                responsedet.Entities.AddRange(apuestas);
            }
            return responsedet;
        }

        public async Task<Response<bool>> UpdateApuestaDetalle(List<DetalleApuesta> detalleApuestas)
        {
            using (var context = new ChubbContext())
            {
                foreach (var item in detalleApuestas)
                {
                    DetalleApuestum detalle = (from ruleta in context.DetalleApuesta
                                       where ruleta.IdDetalle == item.IdDetalle
                                       select ruleta).First();
                    detalle.ValorGanado= item.ValorGanado;
                    await context.SaveChangesAsync();
                }
   
            }
            response.Entities.Add(true);
            return response;
        }
    }
}
