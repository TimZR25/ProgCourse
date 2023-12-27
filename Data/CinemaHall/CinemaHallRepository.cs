using Microsoft.VisualBasic.ApplicationServices;
using ProgCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Data.CinemaHall
{
    public abstract class CinemaHallRepository : IBaseRepository<ICinemaHallEntity>
    {
        protected List<ICinemaHallEntity> _cinemaHalls = new();

        public bool Add(ICinemaHallEntity cinemaHall)
        {
            if (cinemaHall == null || Contains(cinemaHall)) return false;

            _cinemaHalls.Add(cinemaHall);

            return true;
        }

        public bool Remove(ICinemaHallEntity entity)
        {
            if (!_cinemaHalls.Contains(entity)) return false;

            _cinemaHalls.Remove(entity);

            return true;
        }

        public bool RemoveAll()
        {
            if (_cinemaHalls.Count <= 0) return false;

            _cinemaHalls.Clear();

            return true;
        }

        public IReadOnlyCollection<ICinemaHallEntity> GetAll()
        {
            return _cinemaHalls.AsReadOnly();
        }

        public bool Contains(ICinemaHallEntity entity)
        {
            if (_cinemaHalls.Count <= 0) return false;

            foreach (ICinemaHallEntity cinemaHall in _cinemaHalls)
            {
                if (entity.Number == cinemaHall.Number) return true;
            }

            return false;
        }

        public abstract bool Load();
        public abstract bool Save();
    }
}
