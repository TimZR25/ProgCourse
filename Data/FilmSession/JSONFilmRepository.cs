using Newtonsoft.Json;
using ProgCourse.Data.CinemaHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgCourse.Data.FilmSession
{
    public class JSONFilmRepository : FilmSessionRepository
    {
        private JsonSerializerSettings _settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

        private string _path;

        public JSONFilmRepository(string path)
        {
            _path = path;
        }

        public override bool Load()
        {
            var filmSession = File.Exists(_path)
                ? JsonConvert.DeserializeObject<List<IFilmSessionEntity>>(File.ReadAllText(_path), _settings)
                : null;

            if (filmSession == null) return false;

            _filmSessions = filmSession;

            return true;
        }
        public override bool Save()
        {
            if (_filmSessions.Count < 0) return false;

            File.WriteAllText(_path, JsonConvert.SerializeObject(_filmSessions, Formatting.Indented, _settings));

            return true;
        }
    }
}
