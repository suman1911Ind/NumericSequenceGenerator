using System.Collections.Generic;
using System.Web.Mvc;
using NumericSequence.Web.Extensions;
using NumericSequence.Web.Models.Home;
using NumericSequence.Web.Services;

namespace NumericSequence.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string IntegerSequenceName = "All numbers up to and including the number entered";
        private const string OddSequenceName = "All odd numbers up to and including the number entered";
        private const string EvenSequenceName = "All even numbers up to and including the number entered";
        private const string CustomSequenceName = "All numbers up to and including the number entered, except when its multiple of 3, 5 or both";
        private const string FibonacciSequenceName = "All fibonacci numbers up to and including the number entered";

        private readonly IIntegerSequenceService _integerSequenceService;
        private readonly IOddSequenceService _oddSequenceService;
        private readonly IEvenSequenceService _evenSequenceService;
        private readonly ICustomSequenceService _customSequenceService;
        private readonly IFibonacciSequenceService _fibonacciSequenceService;

        public HomeController(
            IIntegerSequenceService integerSequenceService,
            IOddSequenceService oddSequenceService,
            IEvenSequenceService evenSequenceService,
            ICustomSequenceService customSequenceService,
            IFibonacciSequenceService fibonacciSequenceService)
        {
            _integerSequenceService = integerSequenceService;
            _oddSequenceService = oddSequenceService;
            _evenSequenceService = evenSequenceService;
            _customSequenceService = customSequenceService;
            _fibonacciSequenceService = fibonacciSequenceService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(new HomeViewModel());
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Sequences = MapAndGenerateSequences(model.UpperBound.Value);

            return View(model);
        }

        private List<SequenceViewModel> MapAndGenerateSequences(int upperBound)
        {
            return new List<SequenceViewModel>
            {
                MapSequenceToViewModel(IntegerSequenceName, _integerSequenceService, upperBound),
                MapSequenceToViewModel(OddSequenceName, _oddSequenceService, upperBound),
                MapSequenceToViewModel(EvenSequenceName, _evenSequenceService, upperBound),
                MapSequenceToViewModel(CustomSequenceName, _customSequenceService, upperBound),
                MapSequenceToViewModel(FibonacciSequenceName, _fibonacciSequenceService, upperBound)
            };
        }

        private static SequenceViewModel MapSequenceToViewModel<T>(string name, ISequenceService<T> service, int upperBound)
        {
            return new SequenceViewModel
            {
                Name = name,
                Value = service.GenerateSequence(upperBound)
                               .ToSequenceString()
            };
        }
    }
}