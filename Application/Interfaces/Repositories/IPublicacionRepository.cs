using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IPublicacionRepository
    {
        void CreatePublicacion(Publicacion publicacion);
        void UpdatePublicacion(Publicacion publicacion);
        void DeletePublicacion(Publicacion publicacion);
        Task<Publicacion> GetPublicacionAsync(Guid publicacionId);
    }
}
