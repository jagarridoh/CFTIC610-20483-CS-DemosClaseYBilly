using System;

namespace Extending06
{
    public class LoyaltyCardNotFoundException : Exception
    {
        public LoyaltyCardNotFoundException()
        {
            // This implicitly calls the base class constructor.
        }
        public LoyaltyCardNotFoundException(string message) 
        : base(message)
        {
        }
        public LoyaltyCardNotFoundException(string message, Exception inner) 
        : base(message, inner)
        {
        }
    }
}