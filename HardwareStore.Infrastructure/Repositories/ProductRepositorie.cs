using HardwareStore.core.DTOs.DTOSadmins;
using HardwareStore.core.Entities;
using HardwareStore.Infrastructure.Data;
using HardwareStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;



namespace HardwareStore.Infrastructure.Repositories
{
    public class ProductRepositorie : IProductRepositorie
    {
        private readonly HardwareHubContext _context;
        
        public ProductRepositorie(HardwareHubContext context)
        {
            _context = context;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            List<ProductDto> _products = new();
            var products = await _context.Product.Include(b => b.Brand).Include(c => c.HardwareCategory).Include(s => s.Supplier).AsNoTracking().ToListAsync();

            if (products != null)
            {
                foreach (var product in products)
                {

                    _products.Add(new ProductDto
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        BrandName = product.Brand.BrandName,
                        State = product.State,
                        SupplierName = product.Supplier.SupplierName,
                        HardwareCategory = product.HardwareCategory.Category,
                        ImgProduct = product.ImgProduct,



                    });
                }

            }
            else
            {
                return _products;
            }

            return _products;
        }

        public async Task<ProductFullDto> GetProductById(int Id)
        {
            ProductFullDto productDto = new();

            var product = await _context.Product.Include(s => s.Supplier).Include(p=>p.Brand).Include(p=>p.HardwareCategory).FirstOrDefaultAsync(p => p.ProductId == Id);

            if (product != null)
            {
                
                productDto.ProductId = product.ProductId;
                productDto.ProductName = product.ProductName;
                productDto.ImgProduct = product.ImgProduct;
                productDto.Description = product.Desciption;
                productDto.SupplierName = product.Supplier.SupplierName;
                productDto.BrandName = product.Brand.BrandName;
                productDto.HardwareCategory = product.HardwareCategory.Category;
                

            }

            return productDto;


        }


        public async Task<List<ProductDto>> GetProductsByCategory(int category)
        {
            var products = await _context.Product.Where(p=>p.HardwareCategoryId == category).ToListAsync();
            List<ProductDto> productsDto = new();


            if (products != null)
            {
                foreach (var product in products)
                {
                    productsDto.Add(new ProductDto
                    {

                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ImgProduct = product.ImgProduct,
                        SupplierName = product.Supplier.SupplierName,
                        BrandName = product.Brand.BrandName,
                        HardwareCategory = product.HardwareCategory.Category,

                    });

                }
            }

            return productsDto;
        }



        public async Task Save(ProductFullDto productDto)
        {
            if (productDto.ProductId >0)
            {
               await  Update(productDto);
            }
            else
            {
                Insert(productDto);
                InsertStock(productDto);
            }
               
             
        }

        private async Task Update(ProductFullDto productDto)
        {
    
            var product = _context.Product.FirstOrDefault(p=>p.ProductId == productDto.ProductId);
            var brand = _context.Brand.FirstOrDefault(b => b.BrandName == productDto.BrandName);
            var hardwareCategory = _context.HardwareCategory.FirstOrDefault(c => c.Category == productDto.HardwareCategory);
            var supplier = _context.Supplier.FirstOrDefault(c => c.SupplierName == productDto.SupplierName);


            if (product.ProductId == productDto.ProductId & productDto.ProductId != 0 & productDto != null &  await Exist(productDto.ProductId))
            {
                if (productDto.ProductName != null & productDto.ProductName != "string")
                    product.ProductName = productDto.ProductName;
                
                if (productDto.ImgProduct != null & productDto.ImgProduct != "string")
                    product.ImgProduct = productDto.ImgProduct;

                if (brand != null & productDto.BrandName != null)
                    product.BrandId = brand.BrandId;

                if (product.State != null & productDto.State != null)
                    product.State = productDto.State;

                if (productDto.Description != "string" & productDto.Description != null)
                    product.Desciption = productDto.Description;

                if (hardwareCategory != null & productDto.HardwareCategory != null)
                    product.HardwareCategoryId = hardwareCategory.CategoryId;

                if (supplier != null & productDto.SupplierName != null)
                    product.SupplierId = supplier.SupplierId;

            }


            if (_context.Entry(product).State == EntityState.Unchanged)
            {
                _context.Entry(product).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        private void Insert(ProductFullDto productDto)
        {
            var brand = _context.Brand.FirstOrDefault(b=>b.BrandName == productDto.BrandName);
            var hardwareCategory = _context.HardwareCategory.FirstOrDefault(c => c.Category == productDto.HardwareCategory);
            var supplier = _context.Supplier.FirstOrDefault(c => c.SupplierName == productDto.SupplierName);

         
            
                _context.Product.Add(new Product
                {
                    ProductId = productDto.ProductId,
                    ProductName = productDto.ProductName,
                    BrandId = brand.BrandId,
                    HardwareCategoryId = hardwareCategory.CategoryId,
                    ImgProduct = productDto.ImgProduct,
                    SupplierId = supplier.SupplierId,
                    Desciption = productDto.Description,
                    

                });

               
             _context.SaveChanges();

        }


        private  void InsertStock(ProductFullDto productDto)
        {
            var product = _context.Product.FirstOrDefault(p => p.ProductName == productDto.ProductName);
            _context.Stock.Add(new Stock
            {
                
                ProductId = product.ProductId,
                PublicPrice = 0,
                Quantitly = 0,
                DateUpdate = DateTime.Now,
            });

               _context.SaveChanges();
        }

        private async Task<bool> Exist(int Id)
        {
            bool answer = false;

            var product =  _context.Product.FirstOrDefault(p=>p.ProductId == Id);

            if (product != null)
            {
                answer = true;
            }

            return answer;

        }


        public async Task DeleteById(int id)
        {

            var product = _context.Product.FirstOrDefault(p=>p.ProductId == id);

            if (product != null)
            {
                _context.Remove(product);
            }

            await _context.SaveChangesAsync();
        }

        public Task ChangeState()
        {
            throw new NotImplementedException();
        }
    }
}
