using BAL.IRepository.MasterSetup;
using DAL.Models;
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
    public class TehsilService : ITehsil
    {
        private readonly ApplicationDbContext _context;

        public TehsilService(ApplicationDbContext context) => this._context = context;

        public void Remove(Tehsil tehsil)
        {
            this._context.Remove<Tehsil>(tehsil);
            this._context.SaveChanges();
        }

        public int Count(string name)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            //TehsilService.\u003C\u003Ec__DisplayClass3_0 cDisplayClass30 = new TehsilService.\u003C\u003Ec__DisplayClass3_0();
            // ISSUE: reference to a compiler-generated field
            //cDisplayClass30.name = name;
            //ParameterExpression parameterExpression;
            // ISSUE: method reference
            // ISSUE: field reference
            // ISSUE: method reference
            //return this._context.Tehsil.Count<Tehsil>(Expression.Lambda<Func<Tehsil, bool>>((Expression)Expression.Equal((Expression)Expression.Call(a.TehsilName, (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>()), (Expression)Expression.Call((Expression)Expression.Field((Expression)Expression.Constant((object)cDisplayClass30, typeof(TehsilService.\u003C\u003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle(__fieldref(TehsilService.\u003C\u003Ec__DisplayClass3_0.name))), (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>())), parameterExpression));
            return _context.Teshsils.Count(a => a.TehsilName.ToLower() == name.ToLower());
        }

     //   public async Task<List<Tehsil>> GetAll() => await this._context.Teshsils.Include<Tehsil, District>((Expression<Func<Tehsil, District>>)(a => a.District)).ToListAsync<Tehsil>();
            public async Task<List<Tehsil>> GetAll()
        {
            return await _context.Teshsils.ToListAsync();
        }
       // public async Task<List<District>> GetAllDistrict() => await this._context.District.ToListAsync<District>();

        //public async Task<Tehsil> GetById(int? Id) => await this._context.Tehsil.Include<Tehsil, District>((Expression<Func<Tehsil, District>>)(a => a.District)).FirstOrDefaultAsync<Tehsil>((Expression<Func<Tehsil, bool>>)(m => (int?)m.TehsilId == Id));
        public async Task<Tehsil> GetById(int Id)
        {
            return await _context.Teshsils.FindAsync(Id); 
        }
        public void Insert(Tehsil tehsil)
        {
            this._context.Add<Tehsil>(tehsil);
            this._context.SaveChanges();
        }

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }

        public bool Exist(int Id) => this._context.Teshsils.Any<Tehsil>((Expression<Func<Tehsil, bool>>)(e => e.TehsilId == Id));

        public void Update(Tehsil tehsil)
        {
            this._context.Update<Tehsil>(tehsil);
            this._context.SaveChanges();
        }
    }

}
