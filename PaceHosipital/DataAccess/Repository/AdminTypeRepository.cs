using Microsoft.EntityFrameworkCore;
using PaceHosipital.DataAccess.IRepository;
using PaceHosipital.DatabaseContext;
using PaceHosipital.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaceHosipital.DataAccess.Repository
{
    public class AdminTypeRepository : IAdminTypeRepository
    {
        public DBContextt DbRepository;
        public AdminTypeRepository(DBContextt _DbRepository)
        {
            DbRepository = _DbRepository;
        }
        public async Task<List<AdminType>> AllAdminTypes()
        {
            return await DbRepository.AdminTypes.ToListAsync();
        }

        public async Task<int> DeleteAdminType(int AdminTypeId)
        {
            var adm = DbRepository.AdminTypes.Find(AdminTypeId);
            DbRepository.AdminTypes.Remove(adm);
            return await DbRepository.SaveChangesAsync();
        }

        public async Task<AdminType> GetAdminTypeById(int AdminTypeId)
        {
            return await DbRepository.AdminTypes.FindAsync(AdminTypeId);
        }

        public async Task<List<AdminType>> GetAdminTypeByName(string AdminTypeName)
        {
            return await DbRepository.AdminTypes.Where(x => x.AdminTypeName == AdminTypeName).ToListAsync();
        }

        public async Task<int> InsertAdminType(AdminType Adminty)
        {
            await DbRepository.AdminTypes.AddAsync(Adminty);
            return await DbRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateAdminType(AdminType Adminty)
        {
            DbRepository.AdminTypes.Update(Adminty);
            return await DbRepository.SaveChangesAsync();
        }
    }
}
