using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webBancoGeneroso.Data;
using webBancoGeneroso.Models;

namespace webBancoGeneroso.Controllers.Api
{
    [Route("api/[controller]")]
    public class TypeBankItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeBankItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Itens()
        {
            var requestFormData = Request.Form;
            List<TiposBancos> listaItens = await GetItens();
            var listaItensForm = ProcessarDadosForm(listaItens, requestFormData);

            dynamic response = new
            {
                Data = listaItensForm,
                Draw = requestFormData["draw"],
                RecordsFiltered = listaItens.Count,
                RecordsTotal = listaItens.Count
            };
            return Ok(response);
        }

        private List<TiposBancos> ProcessarDadosForm(List<TiposBancos> lstElements, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            try
            {
                if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
                {
                    var columnIndex = requestFormData["order[0][column]"].ToString();
                    var sortDirection = requestFormData["order[0][dir]"].ToString();
                    tempOrder = new[] { "" };
                    if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                    {
                        var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();
                        var prop = getProperty(columName);

                        if (pageSize > 0 && prop != null)
                        {
                            if (sortDirection == "asc")
                            {
                                return lstElements.OrderBy(prop.GetValue).Skip(skip)
                                    .Take(pageSize).ToList();
                            }
                            else
                                return lstElements.OrderByDescending(prop.GetValue)
                                    .Skip(skip).Take(pageSize).ToList();
                        }
                        else
                            return lstElements;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return null;
        }

        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(TiposBancos).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

        private async Task<List<TiposBancos>> GetItens()
        {
            var tiposBancos = await _context.TiposBancos.ToListAsync();
            return tiposBancos;
        }
    }
}
