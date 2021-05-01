namespace AbsentProject.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Absent")]
    public partial class Absent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public int TecherId { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }

        public virtual Emp Emp { get; set; }
    }
}
