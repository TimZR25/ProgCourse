using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Data.FilmSession
{
    public interface IFilmSessionEntity : IEntity
    {
        int HallID { get; set; }
        string FilmName { get; set; }
        DateTime DateStart { get; set; }
        TimeOnly Duration { get; set; }
    }
}
