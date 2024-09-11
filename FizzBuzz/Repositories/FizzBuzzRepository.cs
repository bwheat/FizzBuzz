using Microsoft.Data.SqlClient;
using FizzBuzz.Model;

namespace FizzBuzz.Repositories 
{
    public interface IFizzBuzzRepository
    {
        public List<FizzBuzzResult> Update(List<FizzBuzzResult> results);
    }
    public class FizzBuzzRepository : IFizzBuzzRepository 
    {
        private CapServicesDbContext _context;

        public FizzBuzzRepository(CapServicesDbContext context)
        {
            _context = context;
        }
        public List<FizzBuzzResult> Update(List<FizzBuzzResult> results)
        {
            using(var db = _context)
            {
                db.FizzBuzzResults.AddRange(results);              
                db.SaveChanges();
            }
            return results;


            // foreach (FizzBuzzResult fizzBuzzResult in results)
            // {
            //     var id = new SqlParameter("@id", fizzBuzzResult.Id);
            //     var result = new SqlParameter("@result", fizzBuzzResult.Result);    
            //     //var fizzbuzz = _context.FizzBuzzResults.FromSql($"EXECUTE dbo.AddFizzBuzzResults @id={id}, @result={result}").ToList();
            //     //_context.RunSql<FizzBuzzResult>("EXEC [dbo].[AddFizzBuzzResults] @id, @result", id, result);
            // }

            // int start = results[0].Id;
            // int end = results.Count;

            // var savedList = _context.FizzBuzzResults.("select * from dbo.FizzBuzzResult where Id between @start AND @end", start, end).ToList();

            // return savedList;            
        }
    }
}