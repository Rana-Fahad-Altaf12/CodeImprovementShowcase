using Improvements.Common.Interfaces;
namespace Improvements._39_IActionResultVsGenericTypes.Good
{
    public class UsesIActionResult : IImprovementDemo
    {
        public interface IActionResult
        {
            void ExecuteResult();
        }

        public class OkResult : IActionResult
        {
            private readonly object _value;
            public OkResult(object value) => _value = value;

            public void ExecuteResult() => Console.WriteLine($"200 OK: {_value}");
        }

        public class NotFoundResult : IActionResult
        {
            public void ExecuteResult() => Console.WriteLine("404 Not Found");
        }

        public class UserController
        {
            public IActionResult GetUserName(int id)
            {
                if (id <= 0)
                    return new NotFoundResult();

                return new OkResult($"User-{id}");
            }
        }

        public void Run()
        {
            var controller = new UserController();
            controller.GetUserName(0).ExecuteResult();
            controller.GetUserName(7).ExecuteResult();
        }
    }
}