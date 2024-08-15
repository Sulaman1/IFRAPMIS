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
    public class TrainingHeadService : ITrainingHead
    {
        private readonly ApplicationDbContext _context;

        public TrainingHeadService(ApplicationDbContext context) => _context = context;

        public bool Exist(int Id)
        {
            return _context.TrainingHeads.Any(v => v.TrainingHeadId == Id);
        }

        public async Task<List<TrainingHead>> GetAll() => await _context.TrainingHeads.ToListAsync();

        public async Task<TrainingHead> GetById(int? Id) => await _context.TrainingHeads.FindAsync(Id);

        public void Insert(TrainingHead trainingHead)
        {
            _context.Add(trainingHead);
            _context.SaveChanges();
        }

        public void Remove(TrainingHead trainingHead)
        {
            _context.Remove(trainingHead);
            _context.SaveChanges();
        }

        public async Task Save()
        {
            int num = await _context.SaveChangesAsync();
        }

        public int Count(string name)
        {
            return _context.TrainingHeads.Count(a => a.TrainingHeadName.ToLower() == name.ToLower());
        }

        public void Update(TrainingHead trainingHead)
        {
            _context.Update(trainingHead);
            _context.SaveChanges();
        }
    }
}
