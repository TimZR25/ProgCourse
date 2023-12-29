using Newtonsoft.Json;

namespace ProgCourse.Data.CinemaHall
{
    public class JSONCinemaHallRepository : CinemaHallRepository
    {
        private string _path;

        public JSONCinemaHallRepository(string path)
        {
            _path = path;
        }

        public override bool Load()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            var cinemaHalls = File.Exists(_path)
                ? JsonConvert.DeserializeObject<List<ICinemaHallEntity>>(File.ReadAllText(_path), settings)
                : null;

            if (cinemaHalls == null) return false;

            _cinemaHalls = cinemaHalls;

            return true;
        }
        public override bool Save()
        {
            if (_cinemaHalls.Count < 0) return false;

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };

            File.WriteAllText(_path, JsonConvert.SerializeObject(_cinemaHalls, Formatting.Indented, settings));

            return true;
        }
    }
}
