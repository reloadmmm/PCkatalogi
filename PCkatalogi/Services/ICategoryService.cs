using PCkatalogi.DTOs;

namespace PCkatalogi.Services
{
    /// <summary>
    /// Сервис для работы с категориями компонентов
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Получить все категории
        /// </summary>
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        /// <summary>
        /// Получить категорию по ID
        /// </summary>
        Task<CategoryDto?> GetCategoryByIdAsync(int id);

        /// <summary>
        /// Создать новую категорию
        /// </summary>
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        /// <summary>
        /// Обновить категорию
        /// </summary>
        Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);

        /// <summary>
        /// Удалить категорию
        /// </summary>
        Task<bool> DeleteCategoryAsync(int id);
    }
}