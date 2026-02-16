namespace Services
{
    public class EntityServiceBase
    {
        private List<DomainError> _Errors = new List<DomainError>();
        public List<DomainError> Errors { get { return _Errors; } }
    
        public EntityServiceBase()
        {
            _Errors = new List<DomainError>();
        }

        public void AddError(DomainError error)
        {
            _Errors.Add(error);
        }
    }
}