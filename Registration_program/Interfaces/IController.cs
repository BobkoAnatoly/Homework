using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_program.Interfaces
{
    public interface IController
    {
        Task Delete(int id);
        Task Add<TEntity>(TEntity entity);
    }
}
