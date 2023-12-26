using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Data
{
    public interface IBaseStorage<T> where T : IEntity
    {
        public bool Load();
        public bool Save();

        public bool Add(T entity);
        public bool Remove(T entity);

        public IReadOnlyCollection<T> GetAll();
        public bool Contains(T entity);
    }
}
