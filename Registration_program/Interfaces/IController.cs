using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration_program.Interfaces
{
    public interface IController
    {
        void Delete(int id);
        void Add<TEntity>(TEntity entity);
        void Show();

    }
}
