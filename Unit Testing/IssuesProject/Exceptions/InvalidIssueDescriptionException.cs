using System;
using System.Collections.Generic;
using System.Text;

namespace IssuesProject.Exceptions
{
    public class InvalidIssueDescriptionException : Exception
    {
        public InvalidIssueDescriptionException() : base("issue description cannot be null or whitespace")
        {
        }
    }

}
