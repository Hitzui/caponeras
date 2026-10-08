namespace Caponeras.App.Helpers;

public interface ICrudViewModel
{
    Task DeleteAsync<TDto>(TDto? dto);

    Task SaveAsync<TDto>(TDto? dto);

    void EditAsync<TDto>(TDto? dto);

    void AddAsync();
}