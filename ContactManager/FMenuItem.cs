//Author Iliya Popov 12.12.2023; Custom menu data model
using System;

namespace ContactManager
{
    public class FMenuItem
    {
        //Slide menu
        //listviewItems name - general menu row
        public string Title { get; set; }
        //Image(id, filename) for listviewItems on each row of the general menu
        public string IconSource { get; set; }
        //Contains a type such as array, object, etc.the project will contain a page that we will visualize
        public Type TPage { get; set; }
    }
}
