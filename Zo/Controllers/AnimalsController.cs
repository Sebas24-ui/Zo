using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Zo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ZoContext _context;

        public AnimalsController(ZoContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<ApiResult<List<Animal>>>> GetAnimal()
        {
            try
            {
                return ApiResult<List<Animal>>.Ok(await _context.Animals.ToListAsync());
            }
            catch (Exception ex)
            {
                return ApiResult<List<Animal>>.Fail(ex.Message);
            }
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResult<Animal>>> GetAnimal(int id)
        {
            try
            {

                var animal = await _context.Animals
                    .Include(a => a.Especie)
                    .Include(a => a.Raza)
                    .FirstOrDefaultAsync(a => a.Id == id);


                if (animal == null)
                {
                    return ApiResult<Animal>.Fail("Datos no encontrados");
                }

                return ApiResult<Animal>.Ok(animal);
            }
            catch (Exception ex)
            {
                return ApiResult<Animal>.Fail(ex.Message);
            }
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResult<Animal>>> PutAnimal(int id, Animal animal)
        {

            if (id != animal.Id)
            {
                return ApiResult<Animal>.Fail("ID no coincide");
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await AnimalExists(id))
                {
                    return ApiResult<Animal>.Fail("Datos no encontrados");
                }
                else
                {
                    return ApiResult<Animal>.Fail(ex.Message);
                }
            }


            return ApiResult<Animal>.Ok(animal);



        }

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApiResult<Animal>>> PostAnimal(Animal animal)
        {
            try
            {
                _context.Animals.Add(animal);
                await _context.SaveChangesAsync();

                return ApiResult<Animal>.Ok(animal);
            }
            catch (Exception ex)
            {
                return ApiResult<Animal>.Fail(ex.Message);
            }
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResult<Animal>>> DeleteAnimal(int id)
        {
            try
            {


                var animal = await _context.Animals.FindAsync(id);
                if (animal == null)
                {
                    return ApiResult<Animal>.Fail("Datos no encontrados");
                }

                _context.Animals.Remove(animal);
                await _context.SaveChangesAsync();
                return ApiResult<Animal>.Ok(animal);
            }
            catch (Exception ex)
            {
                return ApiResult<Animal>.Fail(ex.Message);
            }

        }

        private async Task<bool> AnimalExists(int id)
        {
            return await _context.Animals.AnyAsync(e => e.Id == id);
        }
    }
}
