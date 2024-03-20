using System;
using Atividade02.Proponent.API.Data.Common.Interfaces;
using Atividade02.Proponent.API.Models.Interfaces;

namespace Atividade02.Proponent.API.Data.Repositories
{
    public class ProponentRepository : BaseRepository<Atividade02.Proponent.API.Models.Proponent>, IProponentRepository
    {

        public ProponentRepository(IMongoContext context) : base(context)
        {
        }
         
    }
}

