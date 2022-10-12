using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.core.Entities;
using HardwareStore.Infrastructure.Data;
using HardwareStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;



namespace HardwareStore.Infrastructure.Repositories
{
    public class HardwareCategoryRepositorie : IHardwareCategoryRepositorie
    {
        private readonly HardwareHubContext _context;
        public HardwareCategoryRepositorie(HardwareHubContext context)
        {
            _context = context;
        }

        

        public async Task<List<HardwareCategoryDto>> GetAll()
        {
            List<HardwareCategoryDto> categoryListDto = new(); 
            var categoryListContext = await _context.HardwareCategory.ToListAsync();

            if (categoryListContext != null)
            {
                foreach (var category in categoryListContext)
                {
                    categoryListDto.Add(new HardwareCategoryDto
                    {
                        CategoryId = category.CategoryId,
                        HardwareCategory= category.Category,
                        Gaing= category.Gaing,

                    });
                }
                return categoryListDto;
            }
            else
            {
                return categoryListDto;
            }

        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        private async Task Insert(HardwareCategoryDto categoryDto)
        {
            
                _context.Add(new HardwareCategory
                {
                    CategoryId= categoryDto.CategoryId,
                    Category = categoryDto.HardwareCategory,
                    Gaing = categoryDto.Gaing,
                    
                    
                }) ;
            

          await  _context.SaveChangesAsync();
        }

        private async Task Update(HardwareCategoryDto CategoryDto)
        {
            var category = _context.HardwareCategory.FirstOrDefault(h=>h.CategoryId == CategoryDto.CategoryId);

            if (category != null & category.CategoryId != 0)
            {
                if (CategoryDto.HardwareCategory != null)
                    category.Category = CategoryDto.HardwareCategory;

                if (CategoryDto.Gaing != 0 & CategoryDto.Gaing != 0.0)
                category.Gaing = CategoryDto.Gaing;
            }

            await _context.SaveChangesAsync();
        }

      
        public async Task Save(HardwareCategoryDto categoryDto)
        {
            if (categoryDto.CategoryId > 0)
            {
                await Update(categoryDto);
            }
            else
            {
               await Insert(categoryDto);
            }

        }

       
    }
}
