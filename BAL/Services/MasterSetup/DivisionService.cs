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
    public class DivisionService : IDivision
    {
        private readonly ApplicationDbContext _context;

        public DivisionService(ApplicationDbContext context) => this._context = context;

        public void Remove(Division division) => this._context.Remove<Division>(division);

        public async Task<List<Division>> GetAll() => await _context.Divisions.ToListAsync<Division>();
        public List<Provience> GetAllProvience() => this._context.Proviences.ToList<Provience>();    

        public async Task<Division> GetById(int? Id) => await this._context.Divisions.FindAsync((object)Id);

        public void Insert(Division division) => this._context.Add<Division>(division);

        public async Task Save()
        {
            int num = await this._context.SaveChangesAsync();
        }

        public bool Exist(int Id)
        {
            return _context.Divisions.Any(v => v.DivisionId == Id);
        }


        public void Update(Division division) => this._context.Update<Division>(division);

        public int Count(string name)
        {
            // ISSUE: object of a compiler-generated type is created
            // ISSUE: variable of a compiler-generated type
            //DivisionService.\u003C\u003Ec__DisplayClass10_0 cDisplayClass100 = new DivisionService.\u003C\u003Ec__DisplayClass10_0();
            // ISSUE: reference to a compiler-generated field
            //cDisplayClass100.name = name;
            //ParameterExpression parameterExpression;
            // ISSUE: method reference
            // ISSUE: field reference
            // ISSUE: method reference
            //return this._context.Division.Count<Division>(Expression.Lambda<Func<Division, bool>>((Expression)Expression.Equal((Expression)Expression.Call(a.Name, (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>()), (Expression)Expression.Call((Expression)Expression.Field((Expression)Expression.Constant((object)cDisplayClass100, typeof(DivisionService.\u003C\u003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle(__fieldref(DivisionService.\u003C\u003Ec__DisplayClass10_0.name))), (MethodInfo)MethodBase.GetMethodFromHandle(__methodref(string.ToLower)), Array.Empty<Expression>())), parameterExpression));
            return _context.Divisions.Count(a => a.Name.ToLower() == name.ToLower());
        }
    }

}
