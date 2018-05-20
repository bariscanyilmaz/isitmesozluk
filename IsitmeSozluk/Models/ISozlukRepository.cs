using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsitmeSozluk.Models
{
    public interface ISozlukRepository
    {
        IQueryable<Sozluk> GetAll();
        IQueryable<Sozluk> GetByName(string name);
        void AddSozluk(Sozluk sozluk);
        void Update(Sozluk sozluk);
        void Delete(int id);
        Sozluk GetById(int id);
        
    }
}
