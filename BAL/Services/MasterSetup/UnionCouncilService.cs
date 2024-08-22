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
    public class UnionCouncilService : IUnionCouncil
    {
        private readonly ApplicationDbContext _context;

        public UnionCouncilService(ApplicationDbContext context) => this._context = context;

        public void Remove(UnionCouncil unionCouncil)
        {
            this._context.Remove<UnionCouncil>(unionCouncil);
            this._context.SaveChanges();
        }

//        public async Task<List<UnionCouncil>> GetAll() => await this._context.UnionCouncils.Include<UnionCouncil, District>((Expression<Func<UnionCouncil, District>>)(a => a.Tehsil.District)).ToListAsync<UnionCouncil>();
            
        public async Task<List<UnionCouncil>> GetAll()
        {
            return await _context.UnionCouncils.ToListAsync();
        }

       public async Task<List<Tehsil>> GetAllTehsil() => await this._context.Tehsils.ToListAsync<Tehsil>();

       public async Task<List<District>> GetAllDistrict() => await this._context.Districts.ToListAsync<District>();

       //public async Task<UnionCouncil> GetById(int? Id) => await this._context.UnionCouncil.FindAsync((object)Id);
        public async Task<UnionCouncil> GetById(int? Id)
        {
            return await _context.UnionCouncils.FindAsync(Id);
        }
        public void Insert(UnionCouncil unionCouncil)
        {
            this._context.Add<UnionCouncil>(unionCouncil);
            this._context.SaveChanges();
        }

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }

        public bool Exist(int Id)
        {
            return _context.UnionCouncils.Any(v => v.UnionCouncilId == Id);
        }

        public void Update(UnionCouncil unionCouncil)
        {
            this._context.Update<UnionCouncil>(unionCouncil);
            this._context.SaveChanges();
        }

        public int Count(string name)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            //UnionCouncilService.\u003C\u003Ec__DisplayClass11_0 cDisplayClass110 = new UnionCouncilService.\u003C\u003Ec__DisplayClass11_0();
            // ISSUE: reference to a compiler-generated field
            //cDisplayClass110.name = name;
            //ParameterExpression parameterExpression;
            // ISSUE: method reference
            // ISSUE: field reference
            // ISSUE: method reference
            //return this._context.UnionCouncil.Count<UnionCouncil>(Expression.Lambda<Func<UnionCouncil, bool>>((Expression)Expression.Equal((Expression)Expression.Call(a.UnionCouncilName, (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>()), (Expression)Expression.Call((Expression)Expression.Field((Expression)Expression.Constant((object)cDisplayClass110, typeof(UnionCouncilService.\u003C\u003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle(__fieldref(UnionCouncilService.\u003C\u003Ec__DisplayClass11_0.name))), (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>())), parameterExpression));
            return _context.UnionCouncils.Count(a => a.UnionCouncilName.ToLower() == name.ToLower());
        }
    }
}
