using System;
using Akademik.API.Classes.DTO.AcademicanInfoSubs;

namespace Akademik.API.Classes.DTO
{
    public class AcademicanInfoDTO
    {
        public IdsDTO ids { get; set; }

        public string publishing_name { get; set; }

        public string publishing_names { get; set; }

        public string photo { get; set; }

        public AffiliationDTO affiliations { get; set; }

        public ReviewDTO reviews { get; set; }

        public PrePostDTO publications { get; set; }

        public PrePostDTO editorial_boards { get; set; }

        public PrePostDTO handling_editor_records { get; set; }

        public DateTime datetime_records_last_updated { get; set; }
        
        
    }
}