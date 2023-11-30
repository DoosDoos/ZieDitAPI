using ZieDitAPI.Models;

namespace ZieDitAPI.Interfaces
{
    public interface IPresenterRepository
    {
        ICollection<Presenter> GetPresenters();
        Presenter GetPresenter(int id);
        bool PresenterExists(int id);
        bool CreatePresenter(Presenter presenter);
        bool UpdatePresenter(Presenter presenter);
        bool DeletePresenter(Presenter presenter);
        bool Save();
    }
}
