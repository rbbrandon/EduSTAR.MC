using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduSTAR.MC.API.Validators
{
    internal static class SchoolValidator
    {
        internal static bool IsValidSchoolId(string schoolId) {
            return Globals.CurrentUserData.Schools.Contains(schoolId) ||
                   Globals.CurrentUserData.PwdAdminSchools.Contains(schoolId);
        }
    }
}
