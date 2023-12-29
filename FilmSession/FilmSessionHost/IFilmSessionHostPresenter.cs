namespace ProgCourse.FilmSession.FilmSessionHost
{
    public interface IFilmSessionHostPresenter
    {
        IFilmSessionHostService FilmSessionHostService { get; }
        bool TryAddFilmSession();
        void Init(IFilmSessionHostView view);
    }
}