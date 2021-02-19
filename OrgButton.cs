using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class OrgButton
    {
        gr691_baoEntities1 db = new gr691_baoEntities1();
        Organization Organization = new Organization();
        public bool Insert(string OrgName, int OrgFOA, string OrgAddress, string OrgWorkingHours)
        {
            Organization.Organization1 = OrgName;
            Organization.FieldOfActivityId = (OrgFOA);
            Organization.TheAddress = OrgAddress;
            Organization.WorkingHours = OrgWorkingHours;
            db.Organization.Add(Organization);
            db.SaveChanges();
            return true;
        }
        public bool Delete(string id)
        {
            int num = Convert.ToInt32(id);
            var dRow = db.Organization.Where(w => w.Id == num).FirstOrDefault();
            db.Organization.Remove(dRow);
            db.SaveChanges();
            return true;
        }
        public bool Update(string id, string OrgName, int OrgFOA, string OrgAddress, string OrgWorkingHours)
        {
            int num = Convert.ToInt32(id);
            var uRow = db.Organization.Where(w => w.Id == num).FirstOrDefault();
            uRow.Organization1 = OrgName;
            uRow.FieldOfActivityId = OrgFOA;
            uRow.TheAddress = OrgAddress;
            uRow.WorkingHours = OrgWorkingHours;
            db.SaveChanges();
            return true;
        }
    }
}
