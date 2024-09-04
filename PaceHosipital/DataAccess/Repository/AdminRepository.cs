using Microsoft.EntityFrameworkCore;
using PaceHosipital.DataAccess.IRepository;
using PaceHosipital.DatabaseContext;
using PaceHosipital.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaceHosipital.DataAccess.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public DBContextt AdmRep;
        public AdminRepository(DBContextt _AdmRep)
        {
            AdmRep = _AdmRep;
        }
        public async Task<Admin> AdminByAdminEmail(string Email)
        {
            return await AdmRep.Admins.Where(x => x.Email == Email).SingleOrDefaultAsync();
        }

        public async Task<int> AdminRegistration(Admin admin)
        {
            await AdmRep.Admins.AddAsync(admin);
            return await AdmRep.SaveChangesAsync();
        }

        public async Task<List<Admin>> AllOperationalAdmins()
        {
            return await AdmRep.Admins.ToListAsync();
        }

        public async Task<Admin> CheckLogin(string Email, string Password)
        {
            return await AdmRep.Admins.Where(x => x.Email == Email && x.Password == Password).SingleOrDefaultAsync();
        }

        public async Task<int> DeleteAdmin(int AdminId)
        {
            var admi = AdmRep.Admins.Find(AdminId);
            AdmRep.Admins.Remove(admi);
            return await AdmRep.SaveChangesAsync();
        }

        public async Task<int> UpdateAdmin(Admin admin)
        {
            AdmRep.Admins.Update(admin);
            return await AdmRep.SaveChangesAsync();
        }
    }
}
