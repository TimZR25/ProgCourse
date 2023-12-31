﻿namespace ProgCourse.Data
{
    public interface IBaseRepository<T> where T : IEntity
    {
        bool Load();
        bool Save();

        bool Add(T entity);
        bool Remove(T entity);
        bool RemoveAll();

        IReadOnlyCollection<T> GetAll();
        bool Contains(T entity);
    }
}
