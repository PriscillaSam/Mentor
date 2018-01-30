using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMentor.Domain.Interfaces.Utilities
{
    public interface IEncryption
    {
        string Encrypt(string plainText);
    }
}
