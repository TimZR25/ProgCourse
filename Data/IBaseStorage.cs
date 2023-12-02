using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Data
{
    internal interface IBaseStorage<T> where T : IEntity
    {
        public bool Add(T entity);
        public bool Remove(T entity);
        public ReadOnlyCollection<T> GetAll();
        public bool Contains(T entity);
    }
}
