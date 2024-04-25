namespace Models.TrainingModel
{
    public abstract class Training : BaseEntity
    {
        public string Title { get; set; }
        public DateTime TrainingDuration { get; set; }

        protected Training(int id, string title, DateTime trainingDuration) : base(id)
        {
            Title = title;
            TrainingDuration = trainingDuration;
        }
    }
}
