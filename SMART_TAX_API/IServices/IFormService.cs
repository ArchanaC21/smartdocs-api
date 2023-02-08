using SMART_TAX_API.Helpers;
using SMART_TAX_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_TAX_API.IServices
{
    public interface IFormService
    {
        Response<string> InsetForm(FORM form);
        Response<FORM> GetFormDetails(int SectionID);
    }
}
