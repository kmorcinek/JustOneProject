using System.Net;

namespace JustOneProject.VariousStuff
{
    public enum FailureType
    {
        GeneralProblem,
        Timeout,
        Unauthorized
    }

    public class User
    {
        
    }

    public class UsersResult : Either<User, FailureType>
    {
        public UsersResult(User success) : base(success)
        {
        }

        public UsersResult(FailureType failure) : base(failure)
        {
        }
    }

    public class NetworkFailure
    {
        //HttpStatusCode 
    }

    public class UserBetterResult
    {
        
    }
}