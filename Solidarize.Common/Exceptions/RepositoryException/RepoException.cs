using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidarize.Common.Exceptions.RepositoryException
{
    public class RepoException: Exception
    {
        public RepoException(string message, Exception innerException = null) : base(message, innerException)
        {
            
        }
    }
}
