
namespace ATOM.CAP.Model
{
    public abstract class Model
    {
        public Model() { }

        public int ID { get; set; }
        public Guid Guid { get; set; }


        public int RemoverID { get; set; }
        public DateTime? RemoveDate { get; set; }

        public int DisablerID { get; set; }
        public DateTime? DisableDate { get; set; }
    }
}
