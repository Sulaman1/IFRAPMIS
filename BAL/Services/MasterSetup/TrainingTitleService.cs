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
    public class TrainingTitleService: ITrainingTitle
    {
        private readonly ApplicationDbContext _context;

        public TrainingTitleService(ApplicationDbContext context) => this._context = context;

        public bool Exist(int Id) => _context.TrainingTitles.Any<TrainingTitle>((Expression<Func<TrainingTitle, bool>>)(e => e.TitleId == Id));

        //public async Task<List<TrainingTitle>> GetAll() => await _context.TrainingTitles.Include<TrainingTitle, TrainingHead>((Expression<Func<TrainingTitle, TrainingHead>>)(a => a.TrainingHead)).ToListAsync<TrainingTitle>();
        public async Task<List<TrainingTitle>> GetAll() => await _context.TrainingTitles
                                                                         .Include(tt => tt.TrainingHead)
                                                                         .ToListAsync();

        public List<TrainingHead> GetAllTrainingHead() => _context.TrainingHeads.ToList<TrainingHead>();

        public async Task<TrainingTitle> GetById(int? Id) => await _context.TrainingTitles.Include<TrainingTitle, TrainingHead>((Expression<Func<TrainingTitle, TrainingHead>>)(a => a.TrainingHead)).FirstOrDefaultAsync<TrainingTitle>((Expression<Func<TrainingTitle, bool>>)(m => (int?)m.TitleId == Id));

        public void Insert(TrainingTitle trainingType)
        {
            this._context.Add<TrainingTitle>(trainingType);
            this._context.SaveChanges();
        }

        public void Remove(TrainingTitle trainingType)
        {
            this._context.Remove<TrainingTitle>(trainingType);
            this._context.SaveChanges();
        }

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }

        public int Count(string name)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            //TrainingTitleService.\u003C\u003Ec__DisplayClass9_0 cDisplayClass90 = new TrainingTitleService.\u003C\u003Ec__DisplayClass9_0();
            // ISSUE: reference to a compiler-generated field
            //cDisplayClass90.name = name;
            //ParameterExpression parameterExpression;
            // ISSUE: method reference
            // ISSUE: field reference
            // ISSUE: method reference
            //return _context.TrainingTitles.Count<TrainingTitle>(Expression.Lambda<Func<TrainingTitle, bool>>((Expression)Expression.Equal((Expression)Expression.Call(a.TrainingTitleName, (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>()), (Expression)Expression.Call((Expression)Expression.Field((Expression)Expression.Constant((object)cDisplayClass90, typeof(TrainingTitleService.\u003C\u003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle(__fieldref(TrainingTitleService.\u003C\u003Ec__DisplayClass9_0.name))), (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>())), parameterExpression));
            return _context.TrainingTitles.Count(a => a.TrainingName.ToLower() == name.ToLower());
        }

        public void Update(TrainingTitle trainingType)
        {
            this._context.Update<TrainingTitle>(trainingType);
            this._context.SaveChanges();
        }
    }

}
