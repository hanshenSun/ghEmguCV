using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace ghEmguCV
{
    public class ghEmguCVInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "ghEmguCV";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("c47a6d50-7a98-4bb0-8e0f-c3cbe4d71e22");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
