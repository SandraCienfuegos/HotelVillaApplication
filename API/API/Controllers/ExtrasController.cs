using System.Collections.Generic;
using System.Threading.Tasks;
using API.Domain.Models;
using API.Domain.Services;
using API.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [CultureRoute("extras")]
    public class ExtrasController : CultureController
    {
        private readonly IExtraService extraService;
        private readonly IMapper mapper;

        public ExtrasController(IExtraService extraService, IMapper mapper)
        {
            this.extraService = extraService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ExtraResource>> ExtrasList()
        {
            var extras = await extraService.ListAsync(Language);

            return mapper.Map<IEnumerable<Extra>, IEnumerable<ExtraResource>>(extras);
        }

        [HttpGet("{id}")]
        public async Task<ExtraResource> Extra(int id)
        {
            var extra = await extraService.FindByIdAsync(id, Language);

            return mapper.Map<Extra, ExtraResource>(extra);
        }

        #region Translations Part

        [HttpGet("{id}/translations")]
        public async Task<IEnumerable<ExtraLanguageResource>> ExtraTranslation(int id)
        {
            var extrasLanguages = await extraService.FindTranslationsByIdAsync(id);
            return mapper.Map<IEnumerable<ExtraLanguage>, IEnumerable<ExtraLanguageResource>>(extrasLanguages);
        }

        #endregion
    }
}