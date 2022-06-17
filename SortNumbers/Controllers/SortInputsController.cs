using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SortNumbers.Data;
using SortNumbers.Helpers;
using SortNumbers.Models;

namespace SortNumbers.Controllers
{
    public class SortInputsController : Controller
    {
        private readonly SortNumbersContext _context;

        public SortInputsController(SortNumbersContext context)
        {
            _context = context;
        }

        // GET: SortInputs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SortInput.ToListAsync());
        }

        // GET: SortInputs/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sortInput = await _context.SortInput
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sortInput == null)
            {
                return NotFound();
            }

            return View(sortInput);
        }

        // GET: SortInputs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SortInputs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numbers,OrderedNumbers,OrderAscending,TimeToOrder")] SortInput sortInput)
        {
            if (SortNumbersHelper.ValidateNumbers(sortInput.Numbers)) // Validate the user input
            {
                //Start a new timer
                var timer = System.Diagnostics.Stopwatch.StartNew();
                //perform the sort method
                sortInput.OrderedNumbers = SortNumbersHelper.SortNumbers(sortInput.OrderAscending, sortInput.Numbers);
                //stop the timer
                timer.Stop();
                //set the TimeToOrder
                sortInput.TimeToOrder = $"{timer.ElapsedMilliseconds} ms";
            }
            else
            {
                ModelState.AddModelError("Numbers", "Please add your numbers and make sure they are sperated with a comma. Only integers are allowed");
            }

            //If the user input is valid then add the data to the database
            if (ModelState.IsValid)
            {
                _context.Add(sortInput);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sortInput);
        }

        // GET: SortInputs/Delete/id
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sortInput = await _context.SortInput
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sortInput == null)
            {
                return NotFound();
            }

            return View(sortInput);
        }

        // POST: SortInputs/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sortInput = await _context.SortInput.FindAsync(id);
            _context.SortInput.Remove(sortInput);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: SortInputs/Export
        public string Export()
        {
            var data = _context.SortInput;
            int count = data.Count();
            List<SortInput> sortInputList = new List<SortInput>();
            foreach(SortInput row in data)
            {
                sortInputList.Add(row);
            }

            string output = JsonConvert.SerializeObject(sortInputList);

            return output;
        }

        private bool SortInputExists(int id)
        {
            return _context.SortInput.Any(e => e.Id == id);
        }
    }
}
