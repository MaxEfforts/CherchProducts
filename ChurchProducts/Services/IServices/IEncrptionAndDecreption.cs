using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IEncrptionAndDecreption
    {
        public string EncryptString(string Text, string Key);
        public string DecryptString(string Text, string Key);
    }
    
}
