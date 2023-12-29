namespace ProgCourse.Services
{
    public interface IFilmSessionHostService
    {
        bool ClearRepository();
        bool TryAddFilmSession(int hallID, string filmName, DateTime dateStart, TimeOnly duration);
    }
}