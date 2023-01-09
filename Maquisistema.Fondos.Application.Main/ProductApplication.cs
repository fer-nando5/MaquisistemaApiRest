using AutoMapper;
using Maquisistema.Fondos.Application.DTO;
using Maquisistema.Fondos.Application.Interface;
using Maquisistema.Fondos.Dominio.Entity;
using Maquisistema.Fondos.Dominio.Interface;
using Maquisistema.Fondos.Transversal.Common;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;

namespace Maquisistema.Fondos.Application.Main
{
    public class ProductApplication:IProductApplication
    {
        private readonly IProductDominio _productDominio;
        private readonly IMapper _mapper;
        private readonly IDiscountProductDominio _discountProductDominio;
        private readonly IMemoryCache _memoryCache;
        private readonly IAppLogger<ProductApplication> _logger;

        public ProductApplication(IProductDominio productDominio, IMapper mapper, IDiscountProductDominio discountProductDominio, IMemoryCache memoryCache, IAppLogger<ProductApplication> logger)
        {
            this._productDominio = productDominio;
            this._mapper = mapper;         
            this._discountProductDominio = discountProductDominio;
            this._memoryCache = memoryCache;
             this._logger = logger;
        }

        #region Metodos Sincronos
        public Response<bool> Insert(ProductDto productDto)
        {
            var inicio = DateTime.Now;
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Product>(productDto);
                response.Data = _productDominio.Insert(product);
                var fin = DateTime.Now;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                    _logger.LogInformation("Registro Exitoso -" + " EndPoint: Insert - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message=ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: Insert - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public Response<bool> Update(ProductDto productDto)
        {
            var inicio = DateTime.Now;
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Product>(productDto);
                response.Data = _productDominio.Update(product);

                var fin = DateTime.Now;
                if (response.Data)
                {
                    response.IsSuccess=true;
                    response.Message = "Actualización Exitosa";
                    _logger.LogInformation("Actualización Exitosa -" + " EndPoint: Update - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message = ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: Update - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public Response<bool> Delete(string Id)
        {
            var inicio = DateTime.Now;
            var response = new Response<bool>();

            try
            {
                response.Data = _productDominio.Delete(Id);
                var fin = DateTime.Now;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                    _logger.LogInformation("Eliminación Exitosas -" + " EndPoint: Delete - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message=ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: Delete - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public Response<ProductDto> get(string Id)
        {
            var inicio = DateTime.Now;
            var response = new Response<ProductDto>();
            
            try
            {
                var product = _productDominio.get(Id);
                response.Data = _mapper.Map<ProductDto>(product);
                var _cache = new Cache(_memoryCache);
                _cache.SetCache();
                var discount = _discountProductDominio.GetDiscount(product.ProductId);
                discount.Wait();
                if (discount.IsCompleted)
                {
                    var discountVal = Convert.ToByte(discount.Result);
                    response.Data.StatusName = (string)_memoryCache.Get(product.Status);
                    response.Data.Discount = discountVal;
                    response.Data.FinalPrice = product.Price * (100 - discountVal) / 100;
                }
                var fin = DateTime.Now;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message= "Consulta Exitosa";
                    _logger.LogInformation("Consulta Exitosa -" + " EndPoint: get - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }

            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message=ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: get - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public Response<IEnumerable<ProductDto>> GetAll()
        {
            var inicio = DateTime.Now;
            var Response = new Response<IEnumerable<ProductDto>>();

            try
            {
                var product = _productDominio.GetAll();
                Response.Data = _mapper.Map<IEnumerable<ProductDto>>(product);

                var _cache = new Cache(_memoryCache);
                _cache.SetCache();

                foreach (var produc in Response.Data)
                {
                    produc.StatusName = (string)_memoryCache.Get(produc.Status);
                    var discount = _discountProductDominio.GetDiscount(produc.ProductId);
                    discount.Wait();
                    if (discount.IsCompleted)
                    {
                        var discountVal = Convert.ToByte(discount.Result);
                        produc.Discount = discountVal;
                        produc.FinalPrice = produc.Price * (100 - discountVal) / 100;
                    }
                }
                var fin = DateTime.Now;

                if(Response.Data != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Consultas Exitosas";
                    _logger.LogInformation("Consultas Exitosas -" + " EndPoint: GetAll - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                Response.Message=ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: GetAll - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return Response;
        }
        #endregion


        #region Metodos Asyncronos
        public async Task<Response<bool>> InsertAsync(ProductDto productDto)
        {
            var inicio = DateTime.Now;
            var response = new Response<bool>();
            try
            {
                var product = _mapper.Map<Product>(productDto);
                response.Data = await _productDominio.InsertAsync(product);
                var fin = DateTime.Now;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                    _logger.LogInformation("Registro Exitoso -" + " EndPoint: InsertAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message= ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: InsertAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(ProductDto productDto)
        {
            var inicio = DateTime.Now;
            var response = new Response<bool>();

            try
            {
                var product = _mapper.Map<Product>(productDto);
                response.Data = await _productDominio.UpdateAsync(product);

                var fin = DateTime.Now;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                    _logger.LogInformation("Actualización Exitosa -" + " EndPoint: UpdateAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message = ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: UpdateAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public async Task<Response<bool>> DeleteAsync(string Id)
        {
            var inicio = DateTime.Now;
            var response = new Response<bool>();

            try
            {
                response.Data = await _productDominio.DeleteAsync(Id);
                var fin = DateTime.Now;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa";
                    _logger.LogInformation("Eliminación Exitosa -" + " EndPoint: DeleteAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message = ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: DeleteAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public async Task<Response<ProductDto>> getAsync(string Id)
        {
            var inicio = DateTime.Now;
            var response = new Response<ProductDto>();

            try
            {
                var product = await _productDominio.getAsync(Id);
                response.Data = _mapper.Map<ProductDto>(product);

                var _cache = new Cache(_memoryCache);
                _cache.SetCache();
                var discount = _discountProductDominio.GetDiscount(product.ProductId);
                discount.Wait();
                if (discount.IsCompleted)
                {
                    var discountVal = Convert.ToByte(discount.Result);
                    response.Data.StatusName = (string)_memoryCache.Get(product.Status);
                    response.Data.Discount = discountVal;
                    response.Data.FinalPrice = product.Price * (100 - discountVal) / 100;
                }
                var fin = DateTime.Now;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                    _logger.LogInformation("Consultas Exitosas -" + " EndPoint: getAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }

            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                response.Message = ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: getAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return response;
        }

        public async Task<Response<IEnumerable<ProductDto>>> GetAllAsync()
        {
            var inicio = DateTime.Now;
            var Response = new Response<IEnumerable<ProductDto>>();

            try
            {
                var products = await _productDominio.GetAllAsync();
                Response.Data = _mapper.Map<IEnumerable<ProductDto>>(products);

                var _cache = new Cache(_memoryCache);
                _cache.SetCache();

                foreach (var product in Response.Data)
                {
                    product.StatusName = (string)_memoryCache.Get(product.Status);
                    var discount = _discountProductDominio.GetDiscount(product.ProductId);
                    discount.Wait();
                    if (discount.IsCompleted)
                    {
                        var discountVal = Convert.ToByte(discount.Result);
                        product.Discount = discountVal;
                        product.FinalPrice = product.Price * (100 - discountVal) / 100;
                    }
                }
                var fin = DateTime.Now;
                if (Response.Data != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Consultas Exitosas";
                    _logger.LogInformation("Consultas Exitosas -" + " EndPoint: GetAllAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
                }
            }
            catch (Exception ex)
            {
                var fin = DateTime.Now;
                Response.Message = ex.Message;
                _logger.LogError("Error: " + ex.Message + " - EndPoint: GetAllAsync - " + "Duración: " + (fin - inicio).TotalSeconds + " Seconds");
            }
            return Response;
        }
        #endregion
    }
}
