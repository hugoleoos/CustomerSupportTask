using Arvato.Domain.Exceptions;
using Arvato.Domain.Models;
using Arvato.Domain.Services;
using Arvato.WebAPI.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Arvato.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerSupportController : ControllerBase
    {
        private readonly ICustomerSupportService customerSupportService;
        private readonly IMapper mapper;

        public CustomerSupportController(
            ICustomerSupportService customerSupportServices,
            IMapper mapper)
        {
            this.customerSupportService = customerSupportServices ??
                throw new ArgumentNullException(nameof(customerSupportServices));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        ///     Creates a Customer Support
        /// </summary>
        /// <param name="customerSupportPost">
        ///     Customer Support information
        /// </param>
        /// <returns>
        ///     Customer's id
        /// </returns>
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomerSupportAsync(
            [FromBody] CustomerSupportPost customerSupportPost)
        {
            try
            {
                var customerSupport = mapper.Map<CustomerSupportPost, CustomerSupport>(customerSupportPost);

                return Ok(await customerSupportService.CreateCustomerSupportAsync(customerSupport));
            }
            catch (CreateSupportCoreException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///     Gets customer's data by id
        /// </summary>
        /// <param name="id">
        ///     Customer's id
        /// </param>
        /// <returns>
        ///     Customer's data
        /// </returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CustomerSupportGet), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomerSupportAsync([FromRoute] int id)
        {
            try
            {
                var customerSuppport = await customerSupportService.GetCustomerSupportAsync(id);
               
                return Ok(mapper.Map<CustomerSupport, CustomerSupportGet>(customerSuppport));
            }
            catch (CreateSupportCoreException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
