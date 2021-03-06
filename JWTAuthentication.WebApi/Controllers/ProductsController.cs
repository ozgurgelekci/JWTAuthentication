﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Entities.DTOs.Product;
using JWTAuthentication.Services.Abstract.Entity;
using JWTAuthentication.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// All Products
        /// </summary>
        /// <remarks>Ex: api/products</remarks>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet]
        [Authorize(Roles = "Admin,Member")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        /// <summary>
        /// Get product for 'id'
        /// </summary>
        /// <param name="id">productId</param>
        /// <returns></returns>
        [Produces("application/json")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductDto>(product));
        }

        /// <summary>
        /// Add product
        /// </summary>
        /// <remarks>
        /// Ex: {"Name":"Product Name"}
        /// </remarks>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ValidationFilter]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(ProductDto productDto)
        {
            var newProduct = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            return Created("", _mapper.Map<ProductDto>(newProduct));
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <remarks>
        /// Ex: {"Id":1, "Name":"Product Name"}
        /// </remarks>
        /// <param name="productDto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ValidationFilter]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(ProductDto productDto)
        {
            _productService.Update(_mapper.Map<Product>(productDto));
            return NoContent();
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id">productId</param>
        /// <returns></returns>
        [Produces("application/json")]
        [Consumes("application/json")]
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetByIdAsync(id).Result;
            _productService.Remove(product);
            return NoContent();
        }
    }
}
