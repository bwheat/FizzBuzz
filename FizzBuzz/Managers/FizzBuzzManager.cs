using FizzBuzz.Repositories;
using FizzBuzz.Model;

namespace FizzBuzz.Managers
{

    public interface IFizzBuzzManager
    {
        public List<FizzBuzzResult> Results(int start, int end);
    }
    public class FizzBuzzManager : IFizzBuzzManager
    {

        private readonly IFizzBuzzRepository _fizzBuzzRepository;

        public FizzBuzzManager(IFizzBuzzRepository fizzBuzzRepository)
        {
            _fizzBuzzRepository = fizzBuzzRepository;
        }

        public List<FizzBuzzResult> Results(int start, int end)
        {
            FizzBuzzResult result;
            List<FizzBuzzResult> results = new List<FizzBuzzResult>();
            for (int i = start; i <= end; i++)
            {
                result = new FizzBuzzResult()
                {
                    Result = ""
                };

                if (i % 3 == 0)
                {
                    result.Result += "Fizz";
                }
                if (i % 5 == 0)
                {
                    result.Result += "Buzz";
                }

                if (result.Result.Length == 0)
                {
                    result.Result = i.ToString();
                }
                results.Add(result);
            }

            _fizzBuzzRepository.Update(results);
            return results;
        }
    }
}