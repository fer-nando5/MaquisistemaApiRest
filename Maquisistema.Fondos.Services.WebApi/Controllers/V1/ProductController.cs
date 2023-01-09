using Maquisistema.Fondos.Application.DTO;
using Maquisistema.Fondos.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maquisistema.Fondos.Services.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductApplication _productApplication;
        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        #region "Metodo Sincronos"
        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] ProductDto productDto)
        {
            if(productDto == null)
            {
                return BadRequest();
            }

            var response = _productApplication.Insert(productDto);
            if(response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] ProductDto productDto)
        {
            if (productDto != null)
                return BadRequest();

            var response = _productApplication.Update(productDto);
            if(response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var response = _productApplication.Delete(id);
            if(response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var response=_productApplication.get(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var response = _productApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion


        #region "Metodo Asyncronos"
        [HttpPost]
        [Route("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            var response = await _productApplication.InsertAsync(productDto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpPut]
        [Route("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductDto productDto)
        {
            if (productDto != null)
                return BadRequest();

            var response = await _productApplication.UpdateAsync(productDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete]
        [Route("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var response = await _productApplication.DeleteAsync(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        [Route("GetAsync")]
        public async Task<IActionResult> GetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var response = await _productApplication.getAsync(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet]
        [Route("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _productApplication.GetAllAsync();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

    }
}
