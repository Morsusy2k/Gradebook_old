using System;

namespace Gradebook.DataAccessLayer.Models
{
    public class MGradebook
    {
        public MGradebook() { }
        public MGradebook(int id, int pClassId, DateTime schoolYearStart, DateTime schoolYearEnd, bool editable)
        {
            Id = id;
            PClassId = pClassId;
            SchoolYearStart = schoolYearStart;
            SchoolYearEnd = schoolYearEnd;
            Editable = editable;
        }

        public int Id { get; set; }
        public int PClassId { get; set; }
        public DateTime SchoolYearStart { get; set; }
        public DateTime SchoolYearEnd { get; set; }
        public bool Editable { get; set; }
    }
}
