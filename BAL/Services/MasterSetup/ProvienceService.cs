using BAL.IRepository.MasterSetup;
using DAL.Models.Domain.MasterSetup;
using IFRAPMIS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services.MasterSetup
{
    public class ProvienceService : IProvience
    {
        private readonly ApplicationDbContext _context;

        public ProvienceService(ApplicationDbContext context) => this._context = context;

        public void Remove(Provience provience) => this._context.Remove<Provience>(provience);

        public async Task<List<Provience>> GetAll() => await this._context.Proviences.ToListAsync<Provience>();

        public async Task<Provience> GetById(int? Id) => await this._context.Proviences.FindAsync((object)Id);

        public void Insert(Provience provience) => this._context.Add<Provience>(provience);

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }

       public bool Exist(int Id)
        {
            return _context.Proviences.Any(v => v.ProvienceId == Id);
        }
        public void Update(Provience provience) => this._context.Update<Provience>(provience);
    }
}
