using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsitmeSozluk.Models
{
    public class SozlukRepository : ISozlukRepository
    {
        
        private SozlukContext sozlukContext;

        public SozlukRepository(SozlukContext _sozlukContext)
        {
            sozlukContext = _sozlukContext;
        }
           
        public void AddSozluk(Sozluk sozluk)
        {
            sozlukContext.Sozluks.Add(sozluk);
            sozlukContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var sozluk = sozlukContext.Sozluks.FirstOrDefault(i => i.Id == id);
            sozlukContext.Sozluks.Remove(sozluk);
            sozlukContext.SaveChanges();
        }

        public IQueryable<Sozluk> GetAll()
        {
            return sozlukContext.Sozluks;
        }

        public Sozluk GetById(int id)
        {
            return sozlukContext.Sozluks.FirstOrDefault(i => i.Id == id);
        }

        public IQueryable<Sozluk> GetByName(string name)
        {
            return sozlukContext.Sozluks.Where(i => i.Name.Contains(name));
        }

        public void Update(Sozluk sozluk)
        {

            sozlukContext.Entry(sozluk).State = EntityState.Modified;
            sozlukContext.SaveChanges();

        }
    }
}
