using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kolokwium2.DTOs;
using kolokwium2.Entities;
using kolokwium2.Services;

namespace kolokwium2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicianController
    {
        private readonly IMusicLabelService _musicLabelService;

        public MusicianController(IMusicLabelService musicLabelService)
        {
            _musicLabelService = musicLabelService;
        }
        [HttpGet]
        public Task<IActionResult> GetAll()
        {
            var musicians = await _musicLabelService.GetAllMusicians();
            var result = new List<Creator>();
            foreach (var musician in musicians)
            {
                result.Add(new Creator
                {
                    FirstName = musician.FirstName,
                    LastName = musician.LastName,
                    Nickname = musician.Nickname,
                });
            }
            return Ok(result);
        }
}
}